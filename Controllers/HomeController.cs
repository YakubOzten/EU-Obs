using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciBilgiSistemi.Models;

namespace OgrenciBilgiSistemi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult acilisekranı()
        {
            return View();
        }
        public ActionResult bakımdaekranı()
        {
            return View();
        }
        public ActionResult Ogretmenlayoutbakımdaekranı()
        {
            return View();
        }
        OgrenciOgretmenbaglanti model = new OgrenciOgretmenbaglanti();
        nottakipEntities1 db = new nottakipEntities1();
        baglanti cs = new baglanti();
        public ActionResult ogretmendropdown()
        {
            cs.ogrenciList = new SelectList(db.ogrenci, "ogrenci_numara", "ogrenci_adı");
            cs.ogretmenList = new SelectList(db.ogretmen, "id   ", "Ders_Adı");

            return View(cs);
        }
          
        public JsonResult GetogretmenList(int p)
        {
            var itemlist = (from x in db.ogretmen
                           join y in db.ogrenci on x.ogrenci.ogrenci_numara equals y.ogrenci_numara
                           where x.ogrenci.ogrenci_numara == p
                           select new
                           {
                               Text = x.Ders_Adı,
                               Value = x.id.ToString()
                           } ).ToList();
                         

            return Json(itemlist, JsonRequestBehavior.AllowGet);
        }
    }
}