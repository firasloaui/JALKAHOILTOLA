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
    public class EditStocksController : Controller
    {
        private JalkahoitolaEntities db = new JalkahoitolaEntities();

        // GET: EditStocks
        public ActionResult Index()
        {
            var stocks = db.Stocks.Include(s => s.Recieved_ammount);
            return View(stocks.ToList());
        }

        // GET: EditStocks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stock stock = db.Stocks.Find(id);
            if (stock == null)
            {
                return HttpNotFound();
            }
            return View(stock);
        }

        // GET: EditStocks/Create
        public ActionResult Create()
        {
            ViewBag.SaapumiseränId = new SelectList(db.Recieved_ammounts, "SaapumiseränId", "Price");
            return View();
        }

        // POST: EditStocks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UnitStock,LocationCode,SaapumiseränId,Id")] Stock stock)
        {
            if (ModelState.IsValid)
            {
                db.Stocks.Add(stock);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SaapumiseränId = new SelectList(db.Recieved_ammounts, "SaapumiseränId", "Price", stock.SaapumiseränId);
            return View(stock);
        }

        // GET: EditStocks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stock stock = db.Stocks.Find(id);
            if (stock == null)
            {
                return HttpNotFound();
            }
            ViewBag.SaapumiseränId = new SelectList(db.Recieved_ammounts, "SaapumiseränId", "Price", stock.SaapumiseränId);
            return View(stock);
        }

        // POST: EditStocks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UnitStock,LocationCode,SaapumiseränId,Id")] Stock stock)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stock).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SaapumiseränId = new SelectList(db.Recieved_ammounts, "SaapumiseränId", "Price", stock.SaapumiseränId);
            return View(stock);
        }

        // GET: EditStocks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stock stock = db.Stocks.Find(id);
            if (stock == null)
            {
                return HttpNotFound();
            }
            return View(stock);
        }

        // POST: EditStocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Stock stock = db.Stocks.Find(id);
            db.Stocks.Remove(stock);
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
