using System;
using System.Collections.Generic;
using System.Text;

namespace GamingHub2.Model
{
    public class Korisnici
    {
        public int KorisnikId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string KorisnickoIme { get; set; }
        public bool Status { get; set; }

        public ICollection<KorisniciUloge> KorisniciUloge { get; set; }
        public string Uloge { get; set; }

        public override string ToString()
        {
            return $"{Ime} {Prezime} - {KorisnickoIme}";
        }
    }
}
