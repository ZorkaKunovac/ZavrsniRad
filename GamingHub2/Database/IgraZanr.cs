using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingHub2.Database
{
    public class IgraZanr
    {
        public int ID { get; set; }
        public int IgraID { get; set; }
        public virtual Igra Igra { get; set; }
        public int ZanrID { get; set; }
        public virtual Zanr Zanr { get; set; }
        public DateTime DatumIzmjene { get; set; }

    }
}
