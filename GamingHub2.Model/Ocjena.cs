using System;
using System.Collections.Generic;
using System.Text;

namespace GamingHub2.Model
{
    public class Ocjena
    {
        public int OcjenaId { get; set; }
        public int ProizvodId { get; set; }
        public int KupacId { get; set; } 
        public DateTime Datum { get; set; }
        public int OcjenaProizvoda { get; set; }
    }
}
