using System;
using System.Collections.Generic;
using System.Text;

namespace GamingHub2.Model.Requests
{
    public class NarudzbaUpsertRequest
    {
        public int KlijentId { get; set; }
        public DateTime Datum { get; set; }
        public bool Status { get; set; }
        public bool? Otkazano { get; set; }
        public int KorisnikId { get; set; }
        //public decimal IznosBezPdv { get; set; }
        //public decimal IznosSaPdv { get; set; }

        public List<NarudzbaStavkaInsertRequest> stavke { get; set; } = new List<NarudzbaStavkaInsertRequest>();
    }
}
