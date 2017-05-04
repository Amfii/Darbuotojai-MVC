using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Darbuotojai.Models;

namespace Darbuotojai.Controllers
{
    public class DarbuotojaiController : Controller
    {
        private DarbuotojasDBContext db = new DarbuotojasDBContext();

        // GET: Darbuotojai
        public ActionResult Index(string searchString)
        {
            var darbuotojai = from d in db.Darbuotojai select d;
            if (!String.IsNullOrEmpty(searchString))
            {
                darbuotojai = darbuotojai.Where(s => s.Vardas.Contains(searchString) || s.Pavardė.Contains(searchString));
            }

            return View(darbuotojai);
        }

        // GET: Darbuotojai/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Darbuotojas darbuotojas = db.Darbuotojai.Find(id);
            if (darbuotojas == null)
            {
                return HttpNotFound();
            }
            return View(darbuotojas);
        }

        // GET: Darbuotojai/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Darbuotojai/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Vardas,Pavardė,GimimoMetai,Telefonas")] Darbuotojas darbuotojas)
        {
            if (ModelState.IsValid)
            {
                db.Darbuotojai.Add(darbuotojas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(darbuotojas);
        }

        // GET: Darbuotojai/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Darbuotojas darbuotojas = db.Darbuotojai.Find(id);
            if (darbuotojas == null)
            {
                return HttpNotFound();
            }
            return View(darbuotojas);
        }

        // POST: Darbuotojai/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Vardas,Pavardė,GimimoMetai,Telefonas")] Darbuotojas darbuotojas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(darbuotojas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(darbuotojas);
        }

        // GET: Darbuotojai/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Darbuotojas darbuotojas = db.Darbuotojai.Find(id);
            if (darbuotojas == null)
            {
                return HttpNotFound();
            }
            return View(darbuotojas);
        }

        // POST: Darbuotojai/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Darbuotojas darbuotojas = db.Darbuotojai.Find(id);
            db.Darbuotojai.Remove(darbuotojas);
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
