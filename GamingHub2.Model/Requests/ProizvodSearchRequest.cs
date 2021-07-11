using System;
using System.Collections.Generic;
using System.Text;

namespace GamingHub2.Model.Requests
{
    public class ProizvodSearchRequest
    {
        public string Naziv { get; set; }
        public bool? IncludeIgraKonzola { get; set; }
        public string NazivKonzole { get; set; }
    }
}
