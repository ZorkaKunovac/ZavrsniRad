using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingHub2.Database
{
    public class Uloga
    {
        public int UlogaId { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }

        public virtual ICollection<KorisnikUloga> KorisnikUloga { get; set; }
    }
}
