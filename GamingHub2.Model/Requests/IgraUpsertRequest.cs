using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GamingHub2.Model.Requests
{
    public class IgraUpsertRequest
    {
        [Required(ErrorMessage = "Polje je obavezno")]
        [StringLength(50, ErrorMessage = "{0} mora biti izmedju {2} i {1} znakova.", MinimumLength = 5)]
        public string Naziv { get; set; }

        [Required(ErrorMessage = "Polje je obavezno")]
        [StringLength(50, ErrorMessage = "{0} mora biti izmedju {2} i {1} znakova.", MinimumLength = 3)]
        public string Developer { get; set; }

        [Required(ErrorMessage = "Polje je obavezno")]
        [StringLength(50, ErrorMessage = "{0} mora biti izmedju {2} i {1} znakova.", MinimumLength = 3)]
        public string Izdavac { get; set; }
        public DateTime? DatumIzlaska { get; set; }
        //public List<SelectListItem> IgraZarn { get; set; }
        //public List<SelectListItem> IgraKonzola { get; set; }
        public string VideoLink { get; set; }
        //public string SlikaLink { get; set; }
        public byte[] SlikaLink { get; set; }
        //public int KonzolaID { get; internal set; }
        public List<int> Konzole { get; set; } = new List<int>();
        public List<int> Zanrovi { get; set; } = new List<int>();

        //public List<IgraKonzola> Konzola { get; set; }
    }
}
