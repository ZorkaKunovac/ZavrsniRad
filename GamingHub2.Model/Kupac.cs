using System;
using System.Collections.Generic;
using System.Text;

namespace GamingHub2.Model
{
    public class Kupac
    {
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string BrojTelefona { get; set; }
        public string Adresa1 { get; set; }

        public string Adresa2 { get; set; }
        public int DrzavaID { get; set; }
        public string Grad { get; set; }
        public string PostanskiBroj { get; set; }

        public int KorisnikId { get; set; }
    }
}
