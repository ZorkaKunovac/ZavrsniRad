using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GamingHub2.Model.Requests
{
    public class KorisnikUpdateRequest
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Telefon { get; set; }
        public string Password { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string PasswordPotvrda { get; set; }

     //   public bool? Status { get; set; }
    }
}
