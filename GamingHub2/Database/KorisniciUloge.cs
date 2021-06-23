using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GamingHub2.Database
{
    public partial class KorisniciUloge
    {
        [Key]
        public int KorisnikUlogaId { get; set; }
        public int KorisnikId { get; set; }
        public int UlogaId { get; set; }
        public DateTime DatumIzmjene { get; set; }

        public virtual Korisnik Korisnik { get; set; }
        public virtual Uloge Uloga { get; set; }
    }
}

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace GamingHub2.Database
//{
//    public class KorisniciUloge
//    {
//        public int ID { get; set; }
//        public int KorisnikId { get; set; }
//        public int UlogaId { get; set; }
//        public DateTime DatumIzmjene { get; set; }

//        public virtual Korisnik Korisnik { get; set; }
//        public virtual Uloga Uloga { get; set; }
//    }
//}
