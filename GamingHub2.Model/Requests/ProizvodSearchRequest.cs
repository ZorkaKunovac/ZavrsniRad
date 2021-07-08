using System;
using System.Collections.Generic;
using System.Text;

namespace GamingHub2.Model.Requests
{
    public class ProizvodSearchRequest
    {
        public string Naziv { get; set; }
        //public int? IgraId { get; set; }
        public int? IgraKonzolaId { get; set; }
        //public bool? IncludeKorisnik { get; set; }
        public bool? IncludeIgraKonzola { get; set; }

        //public string[] IncludeList { get; set; }
        public string NazivKonzole { get; set; }
    }
}
