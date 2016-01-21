using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Projekt.Models;

namespace Projekt.Controllers
{
    public class LekcjaController : Controller
    {
        private UczenLekcjaContext.SzkolaDBContext db = new UczenLekcjaContext.SzkolaDBContext();

        // GET: Lekcja
        public ActionResult Index()
        {
            return View(db.Lekcje.ToList());
        }

        // GET: Lekcja/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lekcja lekcja = db.Lekcje.Find(id);
            if (lekcja == null)
            {
                return HttpNotFound();
            }
            return View(lekcja);
        }

        // GET: Lekcja/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lekcja/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Typ,IloscGodzin")] Lekcja lekcja)
        {
            if (ModelState.IsValid)
            {
                db.Lekcje.Add(lekcja);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lekcja);
        }

        // GET: Lekcja/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lekcja lekcja = db.Lekcje.Find(id);
            if (lekcja == null)
            {
                return HttpNotFound();
            }
            return View(lekcja);
        }

        // POST: Lekcja/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Typ,IloscGodzin")] Lekcja lekcja)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lekcja).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lekcja);
        }

        // GET: Lekcja/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lekcja lekcja = db.Lekcje.Find(id);
            if (lekcja == null)
            {
                return HttpNotFound();
            }
            return View(lekcja);
        }

        // POST: Lekcja/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lekcja lekcja = db.Lekcje.Find(id);
            db.Lekcje.Remove(lekcja);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
