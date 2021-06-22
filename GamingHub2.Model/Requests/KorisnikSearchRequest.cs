using System;
using System.Collections.Generic;
using System.Text;

namespace GamingHub2.Model.Requests
{
    public class KorisnikSearchRequest
    {
        public string Ime { get; set; }
        public bool IsUlogeLoadingEnabled { get; set; }

        public List<int> Uloge { get; set; } = new List<int>();

    }
}
