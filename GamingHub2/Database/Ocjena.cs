using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GamingHub2.Database
{
    public class Ocjena
    {
        [Key]
        public int OcjenaId { get; set; }
        public int ProizvodId { get; set; }
        public int KupacId { get; set; }
        public DateTime Datum { get; set; }
        public int OcjenaProizvoda { get; set; }

        public Proizvod Proizvod { get; set; }
         public Kupac Kupac { get; set; }
    }
}
