using System;
using System.Collections.Generic;
using System.Text;

namespace GamingHub2.Model
{
    public class Korisnik
    {
        //public int KorisnikId { get; set; }
        //public DateTime? DatumRodjenja { get; set; }
        //public string LozinkaHash { get; set; }
        //public string LozinkaSalt { get; set; }
        //public bool? Status { get; set; }

        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string KorisnickoIme { get; set; }
        public byte[] Slika { get; set; }
        public ICollection<KorisnikUloga> KorisnikUloga { get; set; }
      //  public string Uloga { get; set; }


        // public virtual Kupac Kupac { get; set; }
    }
}
