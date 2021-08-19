﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GamingHub2.Model
{
    public class Proizvod
    {
        public int ID { get; set; }
        [Display(Name = "Naziv proizvoda")]
        public string NazivProizvoda { get; set; }

        [Column(TypeName = "decimal(8, 2)")]
        [Display(Name = "Cijena")]
        public decimal ProdajnaCijena { get; set; }
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Popust { get; set; }
        public bool? Status { get; set; }
        public int IgraKonzolaID { get; set; }
        public virtual IgraKonzola IgraKonzola { get; set; }
        public byte[] Slika { get; set; }
        public decimal ProsjecnaOcjena { get; set; }
        public decimal CijenaSaPopustom => ProdajnaCijena * (1 - Popust / 100);
        public bool ImaPopust => Popust > 0;

    }
}
