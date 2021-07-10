using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GamingHub2.Model
{
    public class NarudzbaIzvjestaj
    {
        public int BrojNarudzbe { get; set; }
        public DateTime Datum { get; set; }

        [Column(TypeName = "decimal(8, 2)")]
        public decimal Iznos { get; set; }
        public string IznosStr => Iznos.ToString("$0.00");

    }
}
