using System;
using System.Collections.Generic;
using System.Text;

namespace GamingHub2.Model
{
    public partial class IgraKonzola
    {
        public int ID { get; set; }
        public int IgraID { get; set; }
        public virtual Igra Igra { get; set; }
        public int KonzolaID { get; set; }
        public virtual Konzola Konzola { get; set; }
        //  public bool IsChecked { get; set; }
        public virtual Proizvod Proizvod { get; set; }
        public DateTime DatumIzmjene { get; set; }
    }
}
