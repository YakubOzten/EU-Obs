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
    public class kullanıcı_ogrenciController : Controller
    {
        private nottakipEntities1 db = new nottakipEntities1();

        // GET: kullanıcı_ogrenci
        public ActionResult Index()
        {
            return View(db.kullanıcı_ogrenci.ToList());
        }

        // GET: kullanıcı_ogrenci/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kullanıcı_ogrenci kullanıcı_ogrenci = db.kullanıcı_ogrenci.Find(id);
            if (kullanıcı_ogrenci == null)
            {
                return HttpNotFound();
            }
            return View(kullanıcı_ogrenci);
        }

        // GET: kullanıcı_ogrenci/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: kullanıcı_ogrenci/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,OgrenciNo,KullanıcıSifre")] kullanıcı_ogrenci kullanıcı_ogrenci)
        {
            if (ModelState.IsValid)
            {
                db.kullanıcı_ogrenci.Add(kullanıcı_ogrenci);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kullanıcı_ogrenci);
        }

        // GET: kullanıcı_ogrenci/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kullanıcı_ogrenci kullanıcı_ogrenci = db.kullanıcı_ogrenci.Find(id);
            if (kullanıcı_ogrenci == null)
            {
                return HttpNotFound();
            }
            return View(kullanıcı_ogrenci);
        }

        // POST: kullanıcı_ogrenci/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,OgrenciNo,KullanıcıSifre")] kullanıcı_ogrenci kullanıcı_ogrenci)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kullanıcı_ogrenci).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kullanıcı_ogrenci);
        }

        // GET: kullanıcı_ogrenci/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kullanıcı_ogrenci kullanıcı_ogrenci = db.kullanıcı_ogrenci.Find(id);
            if (kullanıcı_ogrenci == null)
            {
                return HttpNotFound();
            }
            return View(kullanıcı_ogrenci);
        }

        // POST: kullanıcı_ogrenci/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            kullanıcı_ogrenci kullanıcı_ogrenci = db.kullanıcı_ogrenci.Find(id);
            db.kullanıcı_ogrenci.Remove(kullanıcı_ogrenci);
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
