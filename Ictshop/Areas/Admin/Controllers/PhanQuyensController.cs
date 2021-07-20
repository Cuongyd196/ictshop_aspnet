using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ictshop.Models;

namespace Ictshop.Areas.Admin.Controllers
{
    public class PhanQuyensController : Controller
    {
        private Qlbanhang db = new Qlbanhang();

        // GET: Admin/PhanQuyens
        public ActionResult Index()
        {
            return View(db.PhanQuyens.ToList());
        }

        // GET: Admin/PhanQuyens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhanQuyen phanQuyen = db.PhanQuyens.Find(id);
            if (phanQuyen == null)
            {
                return HttpNotFound();
            }
            return View(phanQuyen);
        }

        // GET: Admin/PhanQuyens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/PhanQuyens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDQuyen,TenQuyen")] PhanQuyen phanQuyen)
        {
            if (ModelState.IsValid)
            {
                db.PhanQuyens.Add(phanQuyen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(phanQuyen);
        }

        // GET: Admin/PhanQuyens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhanQuyen phanQuyen = db.PhanQuyens.Find(id);
            if (phanQuyen == null)
            {
                return HttpNotFound();
            }
            return View(phanQuyen);
        }

        // POST: Admin/PhanQuyens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDQuyen,TenQuyen")] PhanQuyen phanQuyen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phanQuyen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(phanQuyen);
        }

        // GET: Admin/PhanQuyens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhanQuyen phanQuyen = db.PhanQuyens.Find(id);
            if (phanQuyen == null)
            {
                return HttpNotFound();
            }
            return View(phanQuyen);
        }

        // POST: Admin/PhanQuyens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PhanQuyen phanQuyen = db.PhanQuyens.Find(id);
            db.PhanQuyens.Remove(phanQuyen);
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
