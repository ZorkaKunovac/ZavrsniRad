using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GamingHub2.Model.Requests
{
    public class RecenzijaUpsertRequest
    {
        public int KorisnikId { get; set; }
        [DisplayName("Igra")]

        public int IgraId { get; set; }

        [Required(ErrorMessage = "Obavezno polje")]
        [StringLength(250, ErrorMessage = "{0} mora biti izmedju {2} i {1} znakova.", MinimumLength = 5)]
        public string Naslov { get; set; }
        [DisplayName("Datum objave")]
        public DateTime DatumObjave { get; set; }

        [Required(ErrorMessage = "Obavezno polje")]
        [StringLength(20000, ErrorMessage = "{0} mora biti izmedju {2} i {1} znakova.", MinimumLength = 400)]
        public string Sadrzaj { get; set; }
        public byte[] Slika { get; set; }

        [MaxLength(100, ErrorMessage = "Maksimalno {1} znakova")]
        [DisplayName("Video recenzija")]
        public string VideoRecenzija { get; set; }

        //Za web dio
        public List<SelectListItem> Igre { get; set; }
        [DisplayName("Igra")]
        public string ImeIgre { get; set; }

        [DisplayName("Slika")]
        public string stringSlika { get; set; }


    }
}
