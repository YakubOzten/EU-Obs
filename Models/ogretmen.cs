//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OgrenciBilgiSistemi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    
    public partial class ogretmen
    {
        public int id { get; set; }
        [DisplayName("Öğrenci numara")]
        public Nullable<int> ogrenci_numara { get; set; }
        [DisplayName("Ders Kodu")]
        public Nullable<int> Ders_Kodu { get; set; }
        [DisplayName("Ders Adı")]
        public string Ders_Adı { get; set; }
        [DisplayName(" Vize Notu")]
        public Nullable<byte> Vize_Notu { get; set; }
        [DisplayName(" Final Notu")]
        public byte Final_Notu { get; set; }
    
        public virtual ogrenci ogrenci { get; set; }
    }
}
