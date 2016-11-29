using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Boekhouden;
using Microsoft.AspNet.Identity;

namespace Boekhouden.Controllers
{
    [Authorize]
    public class BoekhoudingsController : Controller
    {
        private Entities db = new Entities();

        // GET: Boekhoudings
        public ActionResult Index()
        {
            // var boekhoudingen = db.Boekhoudingen.Where(x => x.TenantId == Tenant.CurrentId) ;
            var boekhoudingen = Tenant.GetCurrent(db).Boekhoudingen;
            return View(boekhoudingen.ToList());
        }

        // GET: Boekhoudings/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Boekhouding boekhouding = Tenant.GetCurrent(db).Boekhoudingen.SingleOrDefault(x => x.Id == id);
            if (boekhouding == null)
            {
                return HttpNotFound();
            }
            return View(boekhouding);
        }

        // GET: Boekhoudings/Create
        public ActionResult Create()
        {            
            return View();
        }

        // POST: Boekhoudings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Boekhouding boekhouding)
        {
            if (ModelState.IsValid)
            {
                boekhouding.Id = Guid.NewGuid();
                boekhouding.TenantId = Tenant.CurrentId; // Bind to Tenant
                db.Boekhoudingen.Add(boekhouding);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(boekhouding);
        }

        // GET: Boekhoudings/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Boekhouding boekhouding = Tenant.GetCurrent(db).Boekhoudingen.SingleOrDefault(x => x.Id == id);
            if (boekhouding == null)
            {
                return HttpNotFound();
            }
            return View(boekhouding);
        }

        // POST: Boekhoudings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Boekhouding boekhouding)
        {
            if (ModelState.IsValid)
            {
                db.Entry(boekhouding).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }            
            return View(boekhouding);
        }

        // GET: Boekhoudings/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Boekhouding boekhouding = Tenant.GetCurrent(db).Boekhoudingen.SingleOrDefault(x => x.Id == id);
            if (boekhouding == null)
            {
                return HttpNotFound();
            }
            return View(boekhouding);
        }

        // POST: Boekhoudings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Boekhouding boekhouding = Tenant.GetCurrent(db).Boekhoudingen.SingleOrDefault(x => x.Id == id);
            db.Boekhoudingen.Remove(boekhouding);
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
