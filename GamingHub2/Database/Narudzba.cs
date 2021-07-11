using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GamingHub2.Database
{
    public class Narudzba
    {
        public Narudzba()
        {
            NarudzbaStavke = new HashSet<NarudzbaStavka>();
        }
        [Key]
        public int NarudzbaId { get; set; }
        public int KorisnikID { get; set; }

        public DateTime Datum { get; set; } 
        public bool Status { get; set; }

        public virtual Korisnik Korisnik { get; set; }
        public virtual ICollection<NarudzbaStavka> NarudzbaStavke { get; set; }
    }
}
