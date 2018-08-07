//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EfWirelessMedia.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Proizvod
    {
        public int Id { get; set; }
        public int IdProizvodjac { get; set; }
        public int IdDobavljac { get; set; }
        public int IdKategorija { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public decimal Cena { get; set; }
        public System.DateTime VaziOd { get; set; }
        public Nullable<System.DateTime> VaziDO { get; set; }
    
        public virtual Dobavljac Dobavljac { get; set; }
        public virtual Kategorija Kategorija { get; set; }
        public virtual Proizvodjac Proizvodjac { get; set; }
    }
}
