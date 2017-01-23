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
    public class ZayvkaController : Controller
    {
        private UsersContext db = new UsersContext();
        [Authorize(Roles = "Admin, Agent, Client")]
        //
        // GET: /Zayvka/
        public ActionResult Index()
        {
           var zayvk = db.Zayvkas.Include(t => t.usluga);
            var zayvkass = zayvk.Include(n => n.userp);
            return View(zayvkass.ToList());

                 }

        //
        // GET: /Zayvka/Details/5
        public ActionResult Details(int id = 0)
        {
            SelectList usl = new SelectList(db.Uslugas, "UslugaId", "Name");
            ViewBag.dog = usl;
            SelectList Puser = new SelectList(db.UserProfiles, "UserId", "UserName");
            ViewBag.user2 = Puser;
            Zayvka zayvka = db.Zayvkas.Find(id);
            if (zayvka == null)
            {
                return HttpNotFound();
            }
            return View(zayvka);
        }

        //
        // GET: /Zayvka/Create
        public ActionResult Create()
        {
            SelectList usl = new SelectList(db.Uslugas, "UslugaId", "Name");
            ViewBag.usln = usl;

            SelectList puser = new SelectList(db.UserProfiles.Where(item => item.UserId == WebSecurity.CurrentUserId), "UserId", "UserName");
            ViewBag.user2 = puser;
            DateTime dd = DateTime.Now;
            Zayvka zav = new Zayvka();
            zav.Datazayvka = dd;
            zav.Status = "На рассмотрении";
             return View(zav);
                   }

        //
        // POST: /Zayvka/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Zayvka zayvka)
        {
            if (ModelState.IsValid)
            {
                zayvka.Datazayvka = DateTime.Now;
                zayvka.Status = "На рассмотрении";
                db.Zayvkas.Add(zayvka);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(zayvka);
        }

        //
        // GET: /Zayvka/Edit/5

        public ActionResult Edit(int id = 0)
        {
            SelectList uslug = new SelectList(db.Uslugas, "UslugaId", "Name");
            ViewBag.usl = uslug;
            SelectList puser = new SelectList(db.UserProfiles.Where(item => item.UserId == WebSecurity.CurrentUserId), "UserId", "UserName");
            ViewBag.user2 = puser;
            Zayvka zayvka = db.Zayvkas.Find(id);
            zayvka.Datazayvka = DateTime.Now;
            zayvka.Status = "На рассмотрении";
            if (zayvka == null)
            {
              return HttpNotFound();
            }
            return View(zayvka);
        }

        //
        // POST: /Zayvka/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Zayvka zayvka)
        {
            zayvka.Datazayvka = DateTime.Now;
           // zayvka.Status = "На рассмотрении";  
            if (ModelState.IsValid)
            {
                              db.Entry(zayvka).State = EntityState.Modified;
                               db.SaveChanges();
                
                return RedirectToAction("Index");

            }
            return View(zayvka);
        }
        //
        // GET: /Zayvka/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Zayvka zayvka = db.Zayvkas.Find(id);
            if (zayvka == null)
            {
                return HttpNotFound();
            }
            return View(zayvka);
        }
        //
        // POST: /Zayvka/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Zayvka zayvka = db.Zayvkas.Find(id);
            db.Zayvkas.Remove(zayvka);
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