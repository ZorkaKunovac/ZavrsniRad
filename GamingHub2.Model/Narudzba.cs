using System;
using System.Collections.Generic;
using System.Text;

namespace GamingHub2.Model
{
    public class Narudzba
    {
        public int NarudzbaId { get; set; }
        public DateTime Datum { get; set; }
        public bool Status { get; set; }
        public int KorisnikID { get; set; }
        public string KorisnikKorisnickoIme { get; set; }
        public decimal Iznos { get; set; }
    }
}
