using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;
using MY_PROEKT.Models;
using System.Web.Security;

namespace MY_PROEKT.Controllers
{
    public class DogovorController : Controller
    {
        private UsersContext db = new UsersContext();
        [Authorize(Roles = "Admin, Agent, Client")]
        //
        // GET: /Dogovor/

       
        public ActionResult Index()
        {
           var user = db.Dogovors.Include(p => p.usluga1);
           var dogovor = user.Include(c => c.user1);
          
                  return View(dogovor.ToList());
         
        }

        //
        // GET: /Dogovor/Details/5

         [Authorize(Roles = "Admin, Client")]
        public ActionResult Details(int id = 0)
        {
            SelectList dogovor1 = new SelectList(db.Uslugas, "UslugaId", "Name");
            ViewBag.dog = dogovor1;
            SelectList Puser = new SelectList(db.UserProfiles, "UserId", "UserName");
            ViewBag.user2 = Puser;
            Dogovor dogovor = db.Dogovors.Find(id);
            if (dogovor == null)
            {
                return HttpNotFound();
            }
            return View(dogovor);
        }

        //
        // GET: /Dogovor/Create

         [Authorize(Roles = "Admin, Agent")]
        public ActionResult Create()
                     {
            
                SelectList dogovor = new SelectList(db.Uslugas, "UslugaId", "Name");
            ViewBag.dog = dogovor;
     //      SelectList Puser = new SelectList(db.UserProfiles, "UserId", "UserName");
                    List <agn> aa = new List<agn>();

                    foreach (var userk in db.UserProfiles)
                    {

                        if (Roles.GetRolesForUser(userk.UserName).Contains("Client"))
                        {
                            agn prom = new agn();
                            prom.UserId = userk.UserId;
                            prom.UserName = userk.UserName;
                            aa.Add(prom);
                        }
                    }

                    SelectList Puser = new SelectList(aa, "UserId", "UserName");
                    ViewBag.us = Puser;
                    Dogovor dogovor2 = new Dogovor();
               dogovor2.Data= DateTime.Now;
               dogovor2.AgentFio = User.Identity.Name;

          //   db.Dogovors.AgentFio=

               //   ViewBag.AgentFio = User.Identity.Name;


                    return View(dogovor2);
                    }

        //
        // POST: /Dogovor/Create
         [Authorize(Roles = "Admin, Agent")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Dogovor dogovor)
        {
            if (ModelState.IsValid)
            {
                dogovor.AgentFio = User.Identity.Name;
                dogovor.Data = DateTime.Now;
                db.Dogovors.Add(dogovor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dogovor);
        
         }

        //
        // GET: /Dogovor/Edit/5

         [Authorize(Roles = "Admin, Agent")]
        public ActionResult Edit(int id = 0)
        {
            SelectList dogovor1 = new SelectList(db.Uslugas, "UslugaId", "Name");
            ViewBag.dog = dogovor1;
            SelectList Puser = new SelectList(db.UserProfiles, "UserId", "UserName");
            ViewBag.user2 = Puser;
            Dogovor dogovor2 = new Dogovor();
            dogovor2.AgentFio = User.Identity.Name;
            Dogovor dogovor = db.Dogovors.Find(id);
            if (dogovor == null)
            {
                return HttpNotFound();
            }
            return View(dogovor);
        }

        //
        // POST: /Dogovor/Edit/5
        [Authorize(Roles = "Admin, Agent")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Dogovor dogovor)
        {
            SelectList dogovor1 = new SelectList(db.Uslugas, "UslugaId", "Name");
            ViewBag.dog = dogovor1;
            SelectList Puser = new SelectList(db.UserProfiles, "UserId", "UserName");
            ViewBag.user2 = Puser;

            if (ModelState.IsValid)
            {
                db.Entry(dogovor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dogovor);
        }

        //
        // GET: /Dogovor/Delete/5

         [Authorize(Roles = "Admin, Agent")]
        public ActionResult Delete(int id = 0)
        {
            Dogovor dogovor = db.Dogovors.Find(id);
            if (dogovor == null)
            {
                return HttpNotFound();
            }
            return View(dogovor);
        }

        //
        // POST: /Dogovor/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dogovor dogovor = db.Dogovors.Find(id);
            db.Dogovors.Remove(dogovor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}