using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingHub2.Database
{
    public class IgraKonzola
    {
        public int ID { get; set; }
        public int IgraID { get; set; }
        public int KonzolaID { get; set; }
        public DateTime DatumIzmjene { get; set; }
     //  public bool IsChecked { get; set; }
        
        public virtual Igra Igra { get; set; }
        public virtual Konzola Konzola { get; set; }
        public virtual Proizvod Proizvod { get; set; }
    }
}
