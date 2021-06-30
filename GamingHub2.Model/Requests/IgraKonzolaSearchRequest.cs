using System;
using System.Collections.Generic;
using System.Text;

namespace GamingHub2.Model.Requests
{
    public class IgraKonzolaSearchRequest
    {
        public bool? IncludeIgra { get; set; }
        public bool? IncludeKonzola { get; set; }

        public string[] IncludeList { get; set; }
    }
}
