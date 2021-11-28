using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GamingHub2.Model.Requests
{
    public class KorisniciChangePhoneNumberRequest
    {
        [Required]
        public string Telefon { get; set; }
    }
}
