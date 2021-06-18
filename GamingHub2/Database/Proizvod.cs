using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamingHub2.Database
{
    public class Proizvod
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Polje je obavezno")]
        public string NazivProizvoda { get; set; }

        [StringLength(100, ErrorMessage = "Maksimalno 100 znakova.")]
        public string Opis { get; set; }

        [Column(TypeName = "decimal(8, 2)")]
        public float ProdajnaCijena { get; set; }
        [Column(TypeName = "decimal(8, 2)")]
        public float Popust { get; set; }
        public bool? Status { get; set; }
        public int IgraKonzolaID { get; set; }
        public IgraKonzola IgraKonzola { get; set; }


    }
}
