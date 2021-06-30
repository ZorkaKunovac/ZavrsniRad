using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GamingHub2.Model
{
    public class Proizvod
    {
        public int ID { get; set; }
        public string NazivProizvoda { get; set; }

        [Column(TypeName = "decimal(8, 2)")]
        public decimal ProdajnaCijena { get; set; }
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Popust { get; set; }
        public bool? Status { get; set; }
        public int IgraKonzolaID { get; set; }
        public virtual IgraKonzola IgraKonzola { get; set; }

        public string IgraKonzolaNaziv => $"{IgraKonzola?.Igra.Naziv} - {IgraKonzola?.Konzola.Naziv}";

    }
}
