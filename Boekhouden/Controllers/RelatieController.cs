using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Boekhouden;

namespace Boekhouden.Controllers
{
    [Authorize]
    public class RelatieController : Controller
    {
        private Entities db = new Entities();

        // GET: Relatie
        public ActionResult Index()
        {
            var relaties = db.Relaties.Where(x => x.TenantId == Tenant.CurrentId).Include(r => r.Boekhouding).Include(r => r.BTW).Include(r => r.Land).Include(r => r.RelatieType);
            return View(relaties.ToList());
        }

        // GET: Relatie/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Relatie relatie = Tenant.GetCurrent(db).Relaties.SingleOrDefault(x => x.Id == id);
            if (relatie == null)
            {
                return HttpNotFound();
            }
            return View(relatie);
        }

        // GET: Relatie/Create
        public ActionResult Create()
        {
            ViewBag.BoekhoudingId = new SelectList(Tenant.GetCurrent(db).Boekhoudingen, "Id", "Name");
            ViewBag.BTWId = new SelectList(db.BTWTypes, "Id", "Naam");
            ViewBag.LandId = new SelectList(db.Landen, "Id", "Naam");
            ViewBag.RelatieTypeId = new SelectList(db.RelatieTypes, "Id", "Naam");
            return View();
        }

        // POST: Relatie/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,BoekhoudingId,RelatieTypeId,Naam1,Naam2,Contactpersoon,Aanhef,Adres1,Adres2,Postcode,LandId,LandNaam,Plaats,BTWNr,Telefoon,Email,IBAN,BTWId,Kenmerk")] Relatie relatie)
        {
            if (ModelState.IsValid)
            {
                relatie.Id = Guid.NewGuid();
                relatie.TenantId = Tenant.CurrentId;
                db.Relaties.Add(relatie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BoekhoudingId = new SelectList(Tenant.GetCurrent(db).Boekhoudingen, "Id", "Name", relatie.BoekhoudingId);
            ViewBag.BTWId = new SelectList(db.BTWTypes, "Id", "Naam", relatie.BTWId);
            ViewBag.LandId = new SelectList(db.Landen, "Id", "Naam", relatie.LandId);
            ViewBag.RelatieTypeId = new SelectList(db.RelatieTypes, "Id", "Naam", relatie.RelatieTypeId);
            return View(relatie);
        }

        // GET: Relatie/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Relatie relatie = Tenant.GetCurrent(db).Relaties.SingleOrDefault(x => x.Id == x.Id);
            if (relatie == null)
            {
                return HttpNotFound();
            }
            ViewBag.BoekhoudingId = new SelectList(Tenant.GetCurrent(db).Boekhoudingen, "Id", "Name", relatie.BoekhoudingId);
            ViewBag.BTWId = new SelectList(db.BTWTypes, "Id", "Naam", relatie.BTWId);
            ViewBag.LandId = new SelectList(db.Landen, "Id", "Naam", relatie.LandId);
            ViewBag.RelatieTypeId = new SelectList(db.RelatieTypes, "Id", "Naam", relatie.RelatieTypeId);
            return View(relatie);
        }

        // POST: Relatie/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,BoekhoudingId,RelatieTypeId,Naam1,Naam2,Contactpersoon,Aanhef,Adres1,Adres2,Postcode,LandId,LandNaam,Plaats,BTWNr,Telefoon,Email,IBAN,BTWId,Kenmerk")] Relatie relatie)
        {
            if (ModelState.IsValid)
            {
                relatie.TenantId = Tenant.CurrentId;                
                db.Entry(relatie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BoekhoudingId = new SelectList(Tenant.GetCurrent(db).Boekhoudingen, "Id", "Name", relatie.BoekhoudingId);
            ViewBag.BTWId = new SelectList(db.BTWTypes, "Id", "Naam", relatie.BTWId);
            ViewBag.LandId = new SelectList(db.Landen, "Id", "Naam", relatie.LandId);
            ViewBag.RelatieTypeId = new SelectList(db.RelatieTypes, "Id", "Naam", relatie.RelatieTypeId);
            return View(relatie);
        }

        // GET: Relatie/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Relatie relatie = db.Relaties.Find(id);
            if (relatie == null)
            {
                return HttpNotFound();
            }
            return View(relatie);
        }

        // POST: Relatie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Relatie relatie = Tenant.GetCurrent(db).Relaties.SingleOrDefault(x => x.Id == id);
            db.Relaties.Remove(relatie);
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
