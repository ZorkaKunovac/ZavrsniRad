using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GamingHub2.Model.Requests
{
    public class OcjenaInsertRequest
    {
        [Required(ErrorMessage = "Polje je obavezno")]
        public int ProizvodId { get; set; }
        [Required(ErrorMessage = "Polje je obavezno")]
        public int KupacId { get; set; }
        [Required(ErrorMessage = "Polje je obavezno")]
        public DateTime Datum { get; set; }
        [Required(ErrorMessage = "Polje je obavezno")]
        public int OcjenaProizvoda { get; set; }

    }
}
