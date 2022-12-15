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
    public class kullanıcı_ogretmenController : Controller
    {
        private nottakipEntities1 db = new nottakipEntities1();

        // GET: kullanıcı_ogretmen
        public ActionResult Index()
        {
            return View(db.kullanıcı_ogretmen.ToList());
        }

        // GET: kullanıcı_ogretmen/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kullanıcı_ogretmen kullanıcı_ogretmen = db.kullanıcı_ogretmen.Find(id);
            if (kullanıcı_ogretmen == null)
            {
                return HttpNotFound();
            }
            return View(kullanıcı_ogretmen);
        }

        // GET: kullanıcı_ogretmen/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: kullanıcı_ogretmen/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,KullaniciAd,KullanıcıSifre")] kullanıcı_ogretmen kullanıcı_ogretmen)
        {
            if (ModelState.IsValid)
            {
                db.kullanıcı_ogretmen.Add(kullanıcı_ogretmen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kullanıcı_ogretmen);
        }

        // GET: kullanıcı_ogretmen/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kullanıcı_ogretmen kullanıcı_ogretmen = db.kullanıcı_ogretmen.Find(id);
            if (kullanıcı_ogretmen == null)
            {
                return HttpNotFound();
            }
            return View(kullanıcı_ogretmen);
        }

        // POST: kullanıcı_ogretmen/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,KullaniciAd,KullanıcıSifre")] kullanıcı_ogretmen kullanıcı_ogretmen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kullanıcı_ogretmen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kullanıcı_ogretmen);
        }

        // GET: kullanıcı_ogretmen/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kullanıcı_ogretmen kullanıcı_ogretmen = db.kullanıcı_ogretmen.Find(id);
            if (kullanıcı_ogretmen == null)
            {
                return HttpNotFound();
            }
            return View(kullanıcı_ogretmen);
        }

        // POST: kullanıcı_ogretmen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            kullanıcı_ogretmen kullanıcı_ogretmen = db.kullanıcı_ogretmen.Find(id);
            db.kullanıcı_ogretmen.Remove(kullanıcı_ogretmen);
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
