using System;
using System.Collections.Generic;
using System.Text;


namespace GamingHub2.Model
{
    public partial class IgraKonzolaNoRelations
    {
        public int ID { get; set; }
        public int IgraID { get; set; }
        public int KonzolaID { get; set; }
        public DateTime DatumIzmjene { get; set; }

        public virtual Konzola Konzola { get; set; }
        public string Naziv { get; set; }
    }
}
