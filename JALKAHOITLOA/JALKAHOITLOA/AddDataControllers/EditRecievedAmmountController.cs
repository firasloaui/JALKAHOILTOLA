using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JALKAHOITLOA.Models;

namespace JALKAHOITLOA.AddDataControllers
{
    public class EditRecievedAmmountController : Controller
    {
        private JalkahoitolaEntities db = new JalkahoitolaEntities();

        // GET: EditRecievedAmmount
        public ActionResult Index()
        {
            var recieved_ammounts = db.Recieved_ammounts.Include(r => r.Product);
            return View(recieved_ammounts.ToList());
        }

        // GET: EditRecievedAmmount/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recieved_ammount recieved_ammount = db.Recieved_ammounts.Find(id);
            if (recieved_ammount == null)
            {
                return HttpNotFound();
            }
            return View(recieved_ammount);
        }

        // GET: EditRecievedAmmount/Create
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Nmae");
            return View();
        }

        // POST: EditRecievedAmmount/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SaapumiseränId,ProductId,Date,ExpireDate,Price,VendorName,LocationCode")] Recieved_ammount recieved_ammount)
        {
            if (ModelState.IsValid)
            {
                db.Recieved_ammounts.Add(recieved_ammount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Nmae", recieved_ammount.ProductId);
            return View(recieved_ammount);
        }

        // GET: EditRecievedAmmount/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recieved_ammount recieved_ammount = db.Recieved_ammounts.Find(id);
            if (recieved_ammount == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Nmae", recieved_ammount.ProductId);
            return View(recieved_ammount);
        }

        // POST: EditRecievedAmmount/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SaapumiseränId,ProductId,Date,ExpireDate,Price,VendorName,LocationCode")] Recieved_ammount recieved_ammount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recieved_ammount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Nmae", recieved_ammount.ProductId);
            return View(recieved_ammount);
        }

        // GET: EditRecievedAmmount/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recieved_ammount recieved_ammount = db.Recieved_ammounts.Find(id);
            if (recieved_ammount == null)
            {
                return HttpNotFound();
            }
            return View(recieved_ammount);
        }

        // POST: EditRecievedAmmount/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recieved_ammount recieved_ammount = db.Recieved_ammounts.Find(id);
            db.Recieved_ammounts.Remove(recieved_ammount);
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
