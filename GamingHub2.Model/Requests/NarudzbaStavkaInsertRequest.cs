using System;
using System.Collections.Generic;
using System.Text;

namespace GamingHub2.Model.Requests
{
    public class NarudzbaStavkaInsertRequest
    {
        public int NarudzbaId { get; set; }
        public int ProizvodlId { get; set; }
        public int Kolicina { get; set; }
        public decimal Cijena { get; set; }
        public decimal? Popust { get; set; }
    }
}
