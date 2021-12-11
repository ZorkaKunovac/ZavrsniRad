using GamingHub2.Helpers;
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
        [Display(Name = "Datum izlaska")]
        [DataType(DataType.Date)]
        public DateTime? DatumIzlaska { get; set; }
        public byte[] SlikaLink { get; set; }
        public List<int> Konzole { get; set; } = new List<int>();
        public List<int> Zanrovi { get; set; } = new List<int>();

        //Za WEB dio
        public int KonzolaId { get; set; }
        [Display(Name = "Konzole ")]
        public List<CheckBoxHelper> ListaKonzola { get; set; }
        [Display(Name = "Zanrovi ")]

        public List<CheckBoxHelper> ListaZanrova { get; set; }


        [Display(Name = "Slika")]
        public string stringSlika { get; set; }

    }
}
