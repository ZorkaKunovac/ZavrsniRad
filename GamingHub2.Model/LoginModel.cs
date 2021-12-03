using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GamingHub2.Model
{
    //class LoginModel
    //{
    //}
    public class LoginModel
    {
 
        [BindProperty]
        public InputModel Input { get; set; }
        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Korisnicko ime")]
            public string KorisnickoIme { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Lozinka")]

            public string Password { get; set; }

            [Display(Name = "Zapamti me?")]
            public bool RememberMe { get; set; }
        }
    }
}
