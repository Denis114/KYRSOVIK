using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MY_PROEKT.Models;

namespace MY_PROEKT.Controllers
{
    public class UslugaController : Controller
    {
        UsersContext db = new UsersContext();
        //
        // GET: /Usluga/
        [Authorize(Roles = "Admin, Agent, Client")]
        public ActionResult Index()
        {
            return View(db.Uslugas.ToList());
        }
        //
        // GET: /Usluga/Details/5

        public ActionResult Details(int id = 0)
        {
            Usluga usluga = db.Uslugas.Find(id);
            if (usluga == null)
            {
                return HttpNotFound();
            }
            return View(usluga);
        }
        //
        // GET: /Usluga/Create

        public ActionResult Create()
        {
                        return View();
        }

        //
        // POST: /Usluga/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usluga usluga)
        {
            if (ModelState.IsValid)
            {
                db.Uslugas.Add(usluga);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usluga);
        }

        //
        // GET: /Usluga/Edit/5

        public ActionResult Edit(int id = 0)
        {
           Usluga usluga = db.Uslugas.Find(id);
            if (usluga == null)
            {
                return HttpNotFound();
            }
            return View(usluga);
        }
        //
        // POST: /Usluga/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Usluga usluga)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usluga).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usluga);
        }
        //
        // GET: /Usluga/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Usluga usluga = db.Uslugas.Find(id);
            if (usluga == null)
            {
                return HttpNotFound();
            }
            return View(usluga);
        }
        //
        // POST: /Usluga/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usluga usluga = db.Uslugas.Find(id);
            db.Uslugas.Remove(usluga);
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