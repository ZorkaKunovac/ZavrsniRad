using System;
using System.Collections.Generic;
using System.Text;

namespace GamingHub2.Model
{
    public partial class IgraZanr
    {
        public int ID { get; set; }
        public int IgraID { get; set; }
        public virtual Igra Igra { get; set; }
        public int ZanrID { get; set; }
        public virtual Zanr Zanr { get; set; }
        public DateTime DatumIzmjene { get; set; }
    }
}
