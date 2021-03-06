﻿using System;
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
    public class UczenController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Uczen
        public ActionResult Index()
        {
            return View(db.Uczens.ToList());
        }
        public ActionResult SortByNazwisko()
        {
            var uczniowie = from u in db.Uczens
                            orderby u.Nazwisko ascending
                           select u;
            return View(uczniowie);
        }

        // GET: Uczen/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uczen uczen = db.Uczens.Find(id);
            if (uczen == null)
            {
                return HttpNotFound();
            }
            return View(uczen);
        }

        // GET: Uczen/Create
        [Authorize(Roles = "Admin" )]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Uczen/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "ID,Imie,Nazwisko,DataZapisu,Stopien,Preferencje")] Uczen uczen)
        {
            if (ModelState.IsValid)
            {
                db.Uczens.Add(uczen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(uczen);
        }

        // GET: Uczen/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uczen uczen = db.Uczens.Find(id);
            if (uczen == null)
            {
                return HttpNotFound();
            }
            return View(uczen);
        }

        // POST: Uczen/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "ID,Imie,Nazwisko,DataZapisu,Stopien,Preferencje")] Uczen uczen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uczen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uczen);
        }

        // GET: Uczen/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Uczen uczen = db.Uczens.Find(id);
            if (uczen == null)
            {
                return HttpNotFound();
            }
            return View(uczen);
        }

        // POST: Uczen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Uczen uczen = db.Uczens.Find(id);
            db.Uczens.Remove(uczen);
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
