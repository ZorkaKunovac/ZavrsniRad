using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GamingHub2.Database
{
    public partial class Igra
    {
        public Igra()
        {
            IgraKonzola = new HashSet<IgraKonzola>();
            IgraZanr = new HashSet<IgraZanr>();
        }
        public int ID { get; set; }
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
        public string VideoLink { get; set; }
        public byte[] SlikaLink { get; set; }
        public virtual ICollection<IgraKonzola> IgraKonzola { get; set; }
        public virtual ICollection<IgraZanr> IgraZanr { get; set; }
    }
}
