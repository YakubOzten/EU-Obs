using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OgrenciBilgiSistemi.Models
{
    public class baglanti
    {
        public IEnumerable<SelectListItem> ogretmenList{get;set;}
        public IEnumerable<SelectListItem> ogrenciList { get; set; }
    }
}