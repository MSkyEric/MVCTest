using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCTest;

namespace MVCTest.Controllers
{
    public class AGENCYController : Controller
    {
        private AGISEntities db = new AGISEntities();

        // GET: AGENCY
        public ActionResult Index()
        {
            return View(db.AGENCies.ToList());
        }

        // GET: AGENCY/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AGENCY aGENCY = db.AGENCies.Find(id);
            if (aGENCY == null)
            {
                return HttpNotFound();
            }
            return View(aGENCY);
        }

        // GET: AGENCY/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AGENCY/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317AGENCies598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AGENCYID,AGENCYNAME,STATUS,CREATEDTIME,CREATEDBY,UPDATEDTIME,UPDATEDBY")] AGENCY aGENCY)
        {
            if (ModelState.IsValid)
            {
                db.AGENCies.Add(aGENCY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aGENCY);
        }

        // GET: AGENCY/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AGENCY aGENCY = db.AGENCies.Find(id);
            if (aGENCY == null)
            {
                return HttpNotFound();
            }
            return View(aGENCY);
        }

        // POST: AGENCY/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AGENCYID,AGENCYNAME,STATUS,CREATEDTIME,CREATEDBY,UPDATEDTIME,UPDATEDBY")] AGENCY aGENCY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aGENCY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aGENCY);
        }

        // GET: AGENCY/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AGENCY aGENCY = db.AGENCies.Find(id);
            if (aGENCY == null)
            {
                return HttpNotFound();
            }
            return View(aGENCY);
        }

        // POST: AGENCY/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AGENCY aGENCY = db.AGENCies.Find(id);
            db.AGENCies.Remove(aGENCY);
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
