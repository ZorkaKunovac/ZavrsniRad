using System;
using System.Collections.Generic;
using System.Text;

namespace GamingHub2.Model.Requests
{
    public class IgraSearchRequest
    {
        public string Naziv { get; set; }
        public bool IsKonzoleLoadingEnabled { get; set; }
        public bool IsZanroviLoadingEnabled { get; set; }
        public List<int> Konzole { get; set; } = new List<int>();
        public List<int> Zanrovi { get; set; } = new List<int>();

    }
}
