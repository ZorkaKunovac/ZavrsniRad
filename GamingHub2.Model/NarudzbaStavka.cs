using System;
using System.Collections.Generic;
using System.Text;

namespace GamingHub2.Model
{
    public class NarudzbaStavka
    {
        public int NarudzbaStavkaId { get; set; }
        public int NarudzbaId { get; set; }
        public int ProizvodId { get; set; }
        public int Kolicina { get; set; }
        public decimal Cijena { get; set; }
        public decimal? Popust { get; set; }

        public virtual Proizvod Proizvod { get; set; }
        //public string NazivProizvoda { get; set; } //NazivProizvoda?
        public string NazivProizvoda => $"{Proizvod?.NazivProizvoda}";

    }
}
