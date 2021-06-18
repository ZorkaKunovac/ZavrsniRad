using System;
using System.Collections.Generic;
using System.Text;

namespace GamingHub2.Model
{
    public class Proizvod
    {
        //public int ID { get; set; }
        //public string NazivProizvoda { get; set; }
        //public float ProdajnaCijena { get; set; }
        //public float Popust { get; set; }
        //public bool? Status { get; set; }
        //////public int IgraKonzolaID { get; set; }
        ////public IgraKonzola IgraKonzola { get; set; }


        public int ID { get; set; }

        public string NazivProizvoda { get; set; }
        public string Opis { get; set; }
        public float ProdajnaCijena { get; set; }
        public float Popust { get; set; }
        public bool? Status { get; set; }
        //public int IgraKonzolaID { get; set; }
        //public virtual IgraKonzola IgraKonzola { get; set; }

    }
}
