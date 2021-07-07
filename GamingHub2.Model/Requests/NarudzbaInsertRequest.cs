using System;
using System.Collections.Generic;
using System.Text;

namespace GamingHub2.Model.Requests
{
    public class NarudzbaInsertRequest
    {
        //public decimal IznosBezPdv { get; set; }
        public DateTime Datum { get; set; }
        public bool Status { get; set; }
        public bool? Otkazano { get; set; }
        //public decimal IznosSaPdv { get; set; }

        public List<NarudzbaStavkaInsertRequest> NarudzbaStavke { get; set; } = new List<NarudzbaStavkaInsertRequest>();
    }
}
