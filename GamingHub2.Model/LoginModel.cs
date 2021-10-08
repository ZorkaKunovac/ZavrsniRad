using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Web.Mvc;

namespace GamingHub2.Model
{
    //class LoginModel
    //{
    //}
    [AllowAnonymous]
    public class LoginModel
    {
        //private readonly UserManager<Korisnik> _userManager;
        //private readonly SignInManager<Korisnik> _signInManager;
        //private readonly ILogger<LoginModel> _logger;
        //private readonly ApplicationDbContext _context;

        //public LoginModel(SignInManager<Korisnik> signInManager,
        //    ILogger<LoginModel> logger,
        //    UserManager<Korisnik> userManager, ApplicationDbContext context)
        //{
        //    _userManager = userManager;
        //    _signInManager = signInManager;
        //    _logger = logger;
        //    _context = context;
        //}

        [BindProperty]
        public InputModel Input { get; set; }

        //public IList<AuthenticationScheme> ExternalLogins { get; set; }

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
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }
    }
}
