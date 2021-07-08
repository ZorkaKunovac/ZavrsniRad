using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GamingHub2.Model.Requests
{
    public class KorisniciRegistracijaRequest
    {
        [Required(ErrorMessage = "Polje je obavezno")]
        [StringLength(50, ErrorMessage = "{0} mora biti izmedju {2} i {1} znakova.", MinimumLength = 2)]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Polje je obavezno")]
        [StringLength(50, ErrorMessage = "{0} mora biti izmedju {2} i {1} znakova.", MinimumLength = 2)]
        public string Prezime { get; set; }

        [RegularExpression(@"^[+]?\d{3}[ ]?\d{2}[ ]?\d{3}[ ]?\d{3,4}$", ErrorMessage = "Telefonski broj mora biti u formatu +387 61 000 111")]
        public string Telefon { get; set; }

        [Required(ErrorMessage = "Polje je obavezno")]

        public string Password { get; set; }

        [Required(ErrorMessage = "Polje je obavezno")]
        public string PasswordPotvrda { get; set; }

        [Required(ErrorMessage = "Polje je obavezno")]
        public string KorisnickoIme { get; set; }

        [Required(ErrorMessage = "Polje je obavezno")]
        [EmailAddress(ErrorMessage = "Email adresa nije u ispravnom formatu.")]
        public string Email { get; set; }
    }
}
