using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GamingHub2.Model.Requests
{
    public class KupacInsertRequest
    {
        [Required(ErrorMessage = "Polje je obavezno")]
        [StringLength(50, ErrorMessage = "{0} mora biti izmedju {2} i {1} znakova.", MinimumLength = 2)]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Polje je obavezno")]
        [StringLength(50, ErrorMessage = "{0} mora biti izmedju {2} i {1} znakova.", MinimumLength = 2)]
        public string Prezime { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Polje je obavezno")]
        [Phone]
        public string BrojTelefona { get; set; }

        [Required(ErrorMessage = "Polje je obavezno")]
        [StringLength(70, ErrorMessage = "{0} mora biti izmedju {2} i {1} znakova.", MinimumLength = 5)]
        public string Adresa1 { get; set; }

        [StringLength(70, ErrorMessage = "{0} mora biti izmedju {2} i {1} znakova.", MinimumLength = 2)]
        public string Adresa2 { get; set; }

        [Required(ErrorMessage = "Polje je obavezno")]
        public int DrzavaID { get; set; }

        [Required(ErrorMessage = "Polje je obavezno")]
        [StringLength(70, ErrorMessage = "{0} mora biti izmedju {2} i {1} znakova.", MinimumLength = 5)]
        public string Grad { get; set; }

        [Required(ErrorMessage = "Polje je obavezno")]
        [StringLength(20, ErrorMessage = "{0} mora biti izmedju {2} i {1} znakova.", MinimumLength = 3)]
        public string PostanskiBroj { get; set; }

        public int KorisnikId { get; set; }
    }
}
