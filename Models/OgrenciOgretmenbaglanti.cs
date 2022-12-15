using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OgrenciBilgiSistemi.Models
{
    public class OgrenciOgretmenbaglanti
    {
        public int ogrenci_numara { get; set; }
        public int ogretmenID { get; set; }
        public List<SelectListItem> ogrenciList { get; set; }
        public List<SelectListItem> ogretmenList { get; set; }
    }
}