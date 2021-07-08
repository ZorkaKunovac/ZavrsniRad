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
        public string Telefon { get; set; }
        public string Password { get; set; }
        public string PasswordPotvrda { get; set; }
        public byte[] Slika { get; set; }

        [Required]
        public string KorisnickoIme { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public List<int> Uloge { get; set; } = new List<int>();

    }
}
