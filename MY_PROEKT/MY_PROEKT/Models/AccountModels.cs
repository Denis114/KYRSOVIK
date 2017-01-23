using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace MY_PROEKT.Models
{
    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("DefaultConnection") {}
        
       

        public DbSet<UserProfile> UserProfiles { get; set; }

        public DbSet<Dogovor> Dogovors { get; set; }

        public DbSet<Usluga> Uslugas { get; set; }
       
        public DbSet<Zayvka> Zayvkas { get; set; }
        public DbSet<Rolesil> Roless { get; set; }
        public DbSet<UsersInRoles> InRoles { get; set; }
    }


    [Table("UserProfile")]
    public class UserProfile
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
         
        [Display(Name = "Имя пользователя")]
        public string UserName { get; set; }
        
               public virtual ICollection<Dogovor> dog1 { get; set; }

        public virtual ICollection<Zayvka> zav { get; set; }
    }



    public class RegisterExternalLoginModel
    {
        [Required]
        [Display(Name = "Имя пользователя")]
        public string UserName { get; set; }

        public string ExternalLoginData { get; set; }
    }

     [Table("[webpages_UsersInRoles]")]
    public class UsersInRoles
    {
          [Key]
        [Required]
        [Display(Name = "Идентификатор пользователя")]
        public int UserId { get; set; }
      
           [Display(Name = "Индентификатор роли")]
        public int RoleId { get; set; }
     
    }
     [Table("[webpages_Roles]")]
     public class Rolesil
      {
          [Key]
        [Required]
        [Display(Name = "Идентификатор пользователя")]
        public int RoleId { get; set; }

           [Display(Name = "Название роли")]
        public string RoleName { get; set; }
        
     
    }
     public class agn
      {
        [Required]
        [Display(Name = "Идентификатор пользователя")]
        public int UserId { get; set; }

          [Display(Name = "ФИО пользователя")]
          public string UserName{ get; set; }
         
         
       public List<agn> Agents { get; set; }
     }

    public class LocalPasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Текущий пароль")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Значение \"{0}\" должно содержать не менее {2} символов.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Новый пароль")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Подтверждение пароля")]
        [Compare("NewPassword", ErrorMessage = "Новый пароль и его подтверждение не совпадают.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginModel
    {
        [Required]
        [Display(Name = "Имя пользователя")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Запомнить меня")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [Display(Name = "Имя пользователя")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Электронная почта")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Принадлежность")]
        public string WillAttend { get; set; }    
        
        [Required]
        [Display(Name = "Дата рождения")]
        public  DateTime Data1 { get; set; }


        [Required]
        [StringLength(100, ErrorMessage = "Значение \"{0}\" должно содержать не менее {2} символов.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Подтверждение пароля")]
        [Compare("Password", ErrorMessage = "Пароль и его подтверждение не совпадают.")]
        public string ConfirmPassword { get; set; }

    }

    public class ExternalLogin
    {
        public string Provider { get; set; }
        public string ProviderDisplayName { get; set; }
        public string ProviderUserId { get; set; }
    }
}
