//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hastane.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Randevular
    {
        public int Id { get; set; }
        public string HastaAdi { get; set; }
        public string DoktorAdi { get; set; }
        public string Bolum { get; set; }
        public string RandevuSaati { get; set; }
        public string HastaTc { get; set; }
        public string DoktorTc { get; set; }
    }
}