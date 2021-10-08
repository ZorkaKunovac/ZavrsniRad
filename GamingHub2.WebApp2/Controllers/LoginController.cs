using GamingHub2.WebApp2.Helper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamingHub2.Model;
// @model GamingHub2.Model.LoginModel
namespace GamingHub2.WebApp2.Controllers
{
    public class LoginController : Controller
    {
        APIService _korisniciService = new APIService("Korisnici");


        /*
         *  APIService.Username = txtUsername.Text;
            APIService.Password = txtPassword.Text;
            try
            {
                var TrenutniKorisnik = await _korisniciService.Get<Model.Korisnici>(null, "MojProfil");

                if (TrenutniKorisnik != null)
                {
                    bool isAdmin = TrenutniKorisnik.KorisniciUloge.Any(x => x.Uloga.Naziv == "Administrator");
                    bool isModerator = TrenutniKorisnik.KorisniciUloge.Any(x => x.Uloga.Naziv == "Moderator");
                    if(!isAdmin && !isModerator)
                    {
                        MessageBox.Show("Pristup aplikaciji je dozovljen samo administratorima i moderatorima.", "Pristup zabranjen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    APIService.TrenutniKorisnik = TrenutniKorisnik;
                    DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {

            }
         */

 
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index( LoginModel loginModel)
        {

            //if (ModelState.IsValid)
            //{
            APIService.Username = loginModel.Input.KorisnickoIme;  //viewbag
            APIService.Password = loginModel.Input.Password;
            try
            {
                var TrenutniKorisnik = await _korisniciService.Get<Model.Korisnici>(null, "MojProfil");

                if (TrenutniKorisnik != null)
                {
                    bool isAdmin = TrenutniKorisnik.KorisniciUloge.Any(x => x.Uloga.Naziv == "Administrator");
                    bool isModerator = TrenutniKorisnik.KorisniciUloge.Any(x => x.Uloga.Naziv == "Moderator");
                    if (!isAdmin && !isModerator)
                    {
                        //MessageBox.Show("Pristup aplikaciji je dozovljen samo administratorima i moderatorima.", "Pristup zabranjen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return View("/Login/AccessDenied");
                    }
                }
                APIService.TrenutniKorisnik = TrenutniKorisnik;
            }
            catch (Exception ex)
            {

            }

            return RedirectToAction("Index", "Home");
        }
    }

}
