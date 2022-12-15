using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OgrenciBilgiSistemi.Models;

namespace OgrenciBilgiSistemi.Controllers
{
    public class ogretmenlayoutController : Controller
    {
        private nottakipEntities1 db = new nottakipEntities1();

        // GET: ogretmenlayout
        public ActionResult Index()
        {
            var ogretmen = db.ogretmen.Include(o => o.ogrenci);
            return View(ogretmen.ToList());
        }

        // GET: ogretmenlayout/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ogretmen ogretmen = db.ogretmen.Find(id);
            if (ogretmen == null)
            {
                return HttpNotFound();
            }
            return View(ogretmen);
        }

        // GET: ogretmenlayout/Create
        public ActionResult Create()
        {
            ViewBag.ogrenci_numara = new SelectList(db.ogrenci, "ogrenci_numara", "ogrenci_adı");
            return View();
        }

        // POST: ogretmenlayout/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,ogrenci_numara,Ders_Kodu,Ders_Adı,Vize_Notu,Final_Notu")] ogretmen ogretmen)
        {
            if (ModelState.IsValid)
            {
                db.ogretmen.Add(ogretmen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ogrenci_numara = new SelectList(db.ogrenci, "ogrenci_numara", "ogrenci_adı", ogretmen.ogrenci_numara);
            return View(ogretmen);
        }

        // GET: ogretmenlayout/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ogretmen ogretmen = db.ogretmen.Find(id);
            if (ogretmen == null)
            {
                return HttpNotFound();
            }
            ViewBag.ogrenci_numara = new SelectList(db.ogrenci, "ogrenci_numara", "ogrenci_adı", ogretmen.ogrenci_numara);
            return View(ogretmen);
        }

        // POST: ogretmenlayout/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,ogrenci_numara,Ders_Kodu,Ders_Adı,Vize_Notu,Final_Notu")] ogretmen ogretmen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ogretmen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ogrenci_numara = new SelectList(db.ogrenci, "ogrenci_numara", "ogrenci_adı", ogretmen.ogrenci_numara);
            return View(ogretmen);
        }

        // GET: ogretmenlayout/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ogretmen ogretmen = db.ogretmen.Find(id);
            if (ogretmen == null)
            {
                return HttpNotFound();
            }
            return View(ogretmen);
        }

        // POST: ogretmenlayout/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ogretmen ogretmen = db.ogretmen.Find(id);
            db.ogretmen.Remove(ogretmen);
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
