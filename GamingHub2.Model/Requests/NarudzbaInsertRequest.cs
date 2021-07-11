using System;
using System.Collections.Generic;
using System.Text;

namespace GamingHub2.Model.Requests
{
    public class NarudzbaInsertRequest
    {
        public DateTime Datum { get; set; }
        public bool Status { get; set; }
        public List<NarudzbaStavkaInsertRequest> NarudzbaStavke { get; set; } = new List<NarudzbaStavkaInsertRequest>();
    }
}
