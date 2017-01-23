using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading;
using System.Web.Mvc;
using WebMatrix.WebData;
using MY_PROEKT.Models;
using System.Web.Security;

namespace MY_PROEKT.Filters
{
            [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
        public sealed class InitializeSimpleMembershipAttribute : ActionFilterAttribute
        {
            private static SimpleMembershipInitializer _initializer;
            private static object _initializerLock = new object();
            private static bool _isInitialized;

            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                // Обеспечение однократной инициализации ASP.NET Simple Membership при каждом запуске приложения
                LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized, ref _initializerLock);
            }

            public class SimpleMembershipInitializer
            {
                public SimpleMembershipInitializer()
                {
                    Database.SetInitializer<UsersContext>(null);

                    try
                    {
                        using (var context = new UsersContext())
                        {
                            if (!context.Database.Exists())
                            {
                                // Создание базы данных SimpleMembership без схемы миграции Entity Framework
                                ((IObjectContextAdapter)context).ObjectContext.CreateDatabase();
                            }
                        }

                        WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);

                        // получаем провайдер ролей на сайте.
                        var roles = (SimpleRoleProvider)Roles.Provider;

                        //Получаем провайдер членства
                        var membership = (SimpleMembershipProvider)Membership.Provider;

                        // проверяю наличие роли Administrator

                        bool isExists = roles.GetAllRoles().Equals("Admin");


                        // добавляю, если роли нет
                        if ((!isExists) == false)
                        {
                            Roles.CreateRole("Admin");
                        }

                        // проверяю наличие зарегистрированного пользователя
                        MembershipUser user = membership.GetUser("Admin", false);

                        //создаю, если пользователя не найдено
                        if (user == null)
                        {
                            membership.CreateUserAndAccount("Admin", "den123");


                            //добавляю пользователю права администратора
                            bool st = Roles.GetRolesForUser("Admin").Equals("Admin");
                            if (st == false)
                            {
                                roles.AddUsersToRoles(
                                    new string[] { "Admin" },
                                    new string[] { "Admin" });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new InvalidOperationException(
              @"The ASP.NET Simple Membership database could 
                not be initialized. 
                For more information, 
                please see http://go.microsoft.com/fwlink/?LinkId=256588", ex);

                    }
                }
            }
        }
    }


  

