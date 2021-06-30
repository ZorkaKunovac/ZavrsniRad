using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GamingHub2.Model
{
    public class Igra
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Polje je obavezno")]
        [StringLength(50, ErrorMessage = "{0} mora biti izmedju {2} i {1} znakova.", MinimumLength = 5)]
        public string Naziv { get; set; }

        [Required(ErrorMessage = "Polje je obavezno")]
        [StringLength(50, ErrorMessage = "{0} mora biti izmedju {2} i {1} znakova.", MinimumLength = 3)]

        public string Developer { get; set; }
        [Required(ErrorMessage = "Polje je obavezno")]
        [StringLength(50, ErrorMessage = "{0} mora biti izmedju {2} i {1} znakova.", MinimumLength = 3)]
        public string Izdavac { get; set; }
        public DateTime? DatumIzlaska { get; set; }
        public byte[] SlikaLink { get; set; }

        public ICollection<IgraKonzola> IgraKonzola { get; set; }
        public ICollection<IgraZanr> IgraZanr { get; set; }

        //public string Konzola { get; set; }

    }
}
