using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GamingHub2.Database
{
    public class NarudzbaStavka
    {
        [Key]
        public int NarudzbaStavkaId { get; set; }
        public int ProizvodID { get; set; }
        public int NarudzbaID { get; set; }// bez ? ?
        public decimal Cijena { get; set; }
        public int Kolicina { get; set; }
        public decimal? Popust { get; set; }
        //public bool IsKompletirano { get; set; }
        //public string KorisnikId { get; set; }
        //public Korisnik Korisnik { get; set; }

        public virtual Proizvod Proizvod { get; set; }
        public virtual Narudzba Narudzba { get; set; }

    }
}
