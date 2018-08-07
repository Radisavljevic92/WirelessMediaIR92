using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WirelessMediaApplication.Models
{
    public class ListaProizvoda
    {
        public string NazivProizvoda { get; set; }
        public string OpisProizvoda { get; set; }
        public decimal CenaProizvoda { get; set; }
        public string NazivDobavljaca { get; set; }
        public string NazivProizvodjaca { get; set; }
        public string NazivKategorije { get; set; }
        public int Id { get; set; }
    }
}