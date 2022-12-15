using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OgrenciBilgiSistemi.Models;
using System.Linq.Dynamic.Core;

namespace OgrenciBilgiSistemi.Controllers
{

    public class ogretmenController : Controller
    {
        private nottakipEntities1 db = new nottakipEntities1();
       
        

        // GET: ogretmen

        public ActionResult Index()
        {
            var ogretmen = db.ogretmen.Include(o => o.ogrenci);
            return View(ogretmen.ToList());
        }

        // GET: ogretmen/Details/5
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

        // GET: ogretmen/Create
        public ActionResult Create()
        {
            ViewBag.ogrenci_numara = new SelectList(db.ogrenci, "ogrenci_numara", "ogrenci_adı");
            return View();
        }

        // POST: ogretmen/Create
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

        // GET: ogretmen/Edit/5
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

        // POST: ogretmen/Edit/5
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

        // GET: ogretmen/Delete/5
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

        // POST: ogretmen/Delete/5
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


            public ActionResult ogrencifiltrele(int id)
            {
                string ogrenciismi = (from k in db.ogrenci
                                      where k.ogrenci_numara == id
                                      select k.ogrenci_adı).FirstOrDefault();
                ViewBag.Title = ogrenciismi + " dersler ve notlar ";
                ViewBag.Id = id;
                List<ogretmen> filtreliogrenci = (from u in db.ogretmen
                                                  where u.ogrenci_numara == id
                                                  select u).ToList();
                return View(filtreliogrenci);
            }
        public ActionResult ogretmenilkekran()

        {
            ViewBag.OnlineUyeSayisi = HttpContext.Application["OnlineUyeSayisi"];
            return View();
        }
        public ActionResult ogrenciilkekran()

        {
            ViewBag.OnlineUyeSayisi = HttpContext.Application["OnlineUyeSayisi"];
            return View();
        }
        public ActionResult cokkieolustur()

        {
            HttpCookie cookiekullanıcı = new HttpCookie("kullanici", "zeynep");
            HttpContext.Response.Cookies.Add(cookiekullanıcı);
            ViewBag.Kullanici = HttpContext.Request.Cookies["kullanici"].Value;
            
            return View();
        }
        public ActionResult cokkiesil()
        {
            HttpContext.Request.Cookies.Remove("kullanici"); 
            return View();
        }

        public ActionResult webgrid()
        {
            var info = new List<ogretmen>();
            using(nottakipEntities1 db = new nottakipEntities1())
            {
                info = db.ogretmen.ToList();
            }
            return View(info);
        }
        public ActionResult gridsearch(string sort= "Ders_Adı",string sortdir="asc",string search="")
        {
            int totalRecord = 0;
            var data = Getsıralama(search, sort, sortdir, out totalRecord);
            ViewBag.Totalrows = totalRecord;
            ViewBag.search = search;

            return View(data);
        }
        public List<ogretmen> Getsıralama(string search, string sort, string sortdir, out
int totalRecord)
        {
            //burada AlbümEntities veritabanı içeriğini oluşturmaktadır
            using (nottakipEntities1 db = new nottakipEntities1())
            {
                var v = (from a in db.ogretmen
                         where

                         a.Ders_Adı.Contains(search)  
                         


                         select a
                );
                totalRecord = v.Count();
                v = v.OrderBy(sort + " " + sortdir);
                return v.ToList();
            }
        }
        OgrenciOgretmenbaglanti model = new OgrenciOgretmenbaglanti();
        public ActionResult ogretmendropdown()
        {
            List<ogrenci> ogrenciList = db.ogrenci.OrderBy(f => f.ogrenci_adı).ToList();
            model.ogrenciList = (from u in ogrenciList
                              select new SelectListItem
                              {
                                  Text = u.ogrenci_adı,
                                  Value = u.ogrenci_numara.ToString()

                              }
                            ).ToList();
            return View(model);
        }
        [HttpPost]
        public JsonResult GetogretmenList(int id)
        {
            List<ogretmen> ogretmenList = db.ogretmen.Where(f => f.ogrenci_numara == id).OrderBy(f => f.Ders_Adı).ToList();
            List<SelectListItem> itemlist = (from s in ogretmenList
                                             select new SelectListItem
                                             {
                                                 Text = s.Ders_Adı,
                                                 Value = s.id.ToString()

                                             }).ToList();
            return Json(itemlist, JsonRequestBehavior.AllowGet);
        }
    }
}
