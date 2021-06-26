using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GamingHub2.Database
{
    public partial class Uloge
    {
        public Uloge()
        {
            KorisniciUloge = new HashSet<KorisniciUloge>();
        }

        [Key]
        public int UlogaId { get; set; }
        //[Required(ErrorMessage = "Polje je obavezno")]
        //[StringLength(40, ErrorMessage = "{0} mora biti izmedju {2} i {1} znakova.", MinimumLength = 3)]
        public string Naziv { get; set; }

        public virtual ICollection<KorisniciUloge> KorisniciUloge { get; set; }
    }
}