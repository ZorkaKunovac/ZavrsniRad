using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamingHub2.Model
{
    public class IgraDetaljiVM
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Developer { get; set; }
        public string Izdavac { get; set; }
        public DateTime? DatumIzlaska { get; set; }
        public List<SelectListItem> IgraZarn { get; set; }
        public List<SelectListItem> IgraKonzola { get; set; }
        public string SlikaLink { get; set; }
     }
}
