using GamingHub2.WebApp2.Helper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamingHub2.Model;
using GamingHub2.WebApp2.Helpers;
// @model GamingHub2.Model.LoginModel
namespace GamingHub2.WebApp2.Controllers
{
    public class LoginController : Controller
    {
        APIService _korisniciService = new APIService("Korisnici");

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            Korisnici k = await HttpContext.GetLogiraniKorisnik();
            if (k != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginModel loginModel)
        {
            var TrenutniKorisnik = await Autentifikacija.Authenticiraj(loginModel.Input.KorisnickoIme, loginModel.Input.Password);

            if (TrenutniKorisnik != null)
            {
                bool isAdmin = TrenutniKorisnik.KorisniciUloge.Any(x => x.Uloga.Naziv == "Administrator");
                bool isModerator = TrenutniKorisnik.KorisniciUloge.Any(x => x.Uloga.Naziv == "Moderator");
                if (!isAdmin && !isModerator)
                {
                    await HttpContext.SetLogiraniKorisnik(null);
                    return View("/Login/AccessDenied");
                }

                APIService.TrenutniKorisnik = TrenutniKorisnik;
                await HttpContext.SetLogiraniKorisnik(TrenutniKorisnik);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["error_message"] = "Neispravno korisničko ime ili lozinka.";
                return View("Index");
            }

        }

        public async Task<IActionResult> Odjava()
        {
            await HttpContext.SetLogiraniKorisnik(null);
            return RedirectToAction("Index");
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }

}
