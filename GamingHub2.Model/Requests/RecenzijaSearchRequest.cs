using System;
using System.Collections.Generic;
using System.Text;

namespace GamingHub2.Model.Requests
{
    public class RecenzijaSearchRequest
    {
        public string Naslov { get; set; }
        public int? KorisnikId { get; set; }
        public int? IgraId { get; set; }
        public bool? IncludeKorisnik { get; set; }

        public string[] IncludeList { get; set; }
    }
}
