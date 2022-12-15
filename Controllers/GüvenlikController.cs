using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciBilgiSistemi.Models;
using System.ComponentModel;

namespace OgrenciBilgiSistemi.Controllers
{
    public class GüvenlikController : Controller
    {
        // GET: Güvenlik
        nottakipEntities1 db = new nottakipEntities1();
        public ActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GirisYap(kullanıcı_ogretmen r)
        {
            var bilgiler = db.kullanıcı_ogretmen
                .FirstOrDefault(x => x.KullaniciAd == r.KullaniciAd && x.KullanıcıSifre == r.KullanıcıSifre);
            if (bilgiler != null)
            {
                Session["KullaniciAd"] = bilgiler.KullaniciAd.ToString();
                Session["KullanıcıSifre"] = bilgiler.KullanıcıSifre.ToString();
                return RedirectToAction("ogretmenilkekran", "ogretmen");
            }
            else
            {
              
               return Content("<script language='javascript' type='text/javascript'>" +   
                    "alert('Kullanıcı Adınızı veya Sifrenizi yanliş girdiniz.');</script>");
            }

        }

        public ActionResult OgrenciGirisYap()
        {
            return View();
        }
        [HttpPost]
       

        public ActionResult OgrenciGirisYap(kullanıcı_ogrenci t)
        {
            var bilgiler1 = db.kullanıcı_ogrenci
                .FirstOrDefault(x => x.OgrenciNo == t.OgrenciNo && x.KullanıcıSifre == t.KullanıcıSifre);
            ViewBag.OgrenciNo = t.OgrenciNo;
            if (bilgiler1 != null)
            {
                Session["OgrenciNo"] = bilgiler1.OgrenciNo.ToString();
                Session["KullanıcıSifre"] = bilgiler1.KullanıcıSifre.ToString();
               

                return RedirectToAction("ogrencifiltrele", "ogretmen",new { id=ViewBag.OgrenciNo}); 
              
            }
            else
            {
                return Content("<script language='javascript' type='text/javascript'>" +
                   "alert('Kullanıcı Adınızı veya Sifrenizi yanliş girdiniz.');</script>");
            }

        }

    }
}