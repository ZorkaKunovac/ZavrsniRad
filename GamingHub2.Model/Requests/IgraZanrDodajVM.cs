using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GamingHub2.Model.Requests
{
    public class IgraZanrDodajVM
    {
        public int IgraID { get; set; }

        [DisplayName("Zanr")]
        public int ZarnID { get; set; }
        public List<SelectListItem> Zarnovi { get; set; }

    }
}
