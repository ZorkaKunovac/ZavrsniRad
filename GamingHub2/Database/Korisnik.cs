using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GamingHub2.Database
{
    public partial class Korisnik
    {
        public Korisnik()
        {
            KorisniciUloge = new HashSet<KorisniciUloge>();
        }

        public int KorisnikId { get; set; }

        [Required(ErrorMessage = "Polje je obavezno")]
        [StringLength(50, ErrorMessage = "{0} mora biti izmedju {2} i {1} znakova.", MinimumLength = 2)]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Polje je obavezno")]
        [StringLength(50, ErrorMessage = "{0} mora biti izmedju {2} i {1} znakova.", MinimumLength = 2)]
        public string Prezime { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Telefon { get; set; }
        [Required]
        public string KorisnickoIme { get; set; }
        [Required]
        public string LozinkaHash { get; set; }
        [Required]
        public string LozinkaSalt { get; set; }
        public byte[] Slika { get; set; }

        public virtual Kupac Kupac { get; set; }

        public virtual ICollection<KorisniciUloge> KorisniciUloge { get; set; }
    }
}