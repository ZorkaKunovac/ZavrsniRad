using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GamingHub2.Database
{
    public class Uloga
    {
        public Uloga()
        {
            KorisnikUloga = new HashSet<KorisnikUloga>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Polje je obavezno")]
        [StringLength(40, ErrorMessage = "{0} mora biti izmedju {2} i {1} znakova.", MinimumLength = 3)]
        public string Naziv { get; set; }

        public virtual ICollection<KorisnikUloga> KorisnikUloga { get; set; }
    }
}
