using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GamingHub2.Database
{
    public class Recenzija
    {
        public int ID { get; set; }
        public int KorisnikId { get; set; }
        public virtual Korisnik Korisnik { get; set; }
        public int IgraId { get; set; }
        public virtual Igra Igra { get; set; }

        [Required(ErrorMessage = "Obavezno polje")]
        [StringLength(250, ErrorMessage = "{0} mora biti izmedju {2} i {1} znakova.", MinimumLength = 5)]
        public string Naslov { get; set; }
        public DateTime? DatumObjave { get; set; }

        //public DateTime DatumIzmjene { get; set; } ??

        [Required(ErrorMessage = "Obavezno polje")]
        [StringLength(20000, ErrorMessage = "{0} mora biti izmedju {2} i {1} znakova.", MinimumLength = 400)]
        public string Sadrzaj { get; set; }
        public byte[] Slika { get; set; }

        [MaxLength(100, ErrorMessage = "Maksimalno {1} znakova")]
        public string VideoRecenzija { get; set; }
    }
}
