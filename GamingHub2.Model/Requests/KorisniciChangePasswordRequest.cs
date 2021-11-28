using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GamingHub2.Model.Requests
{
    public class KorisniciChangePasswordRequest
    {
        [Required]
        public string Password { get; set; }
        [Required]
        public string PasswordPotvrda { get; set; }
    }
}
