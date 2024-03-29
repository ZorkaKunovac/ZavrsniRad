﻿using GamingHub2.Helpers;
using GamingHub2.Model;
using GamingHub2.Model.Requests;
using GamingHub2.WebApp2.Helper;
using GamingHub2.WebApp2.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GamingHub2.WebApp2.Controllers
{
    [Autorizacija(administrator: true, moderator: true)]
    public class KorisniciController : Controller
    {
        APIService _service = new APIService("Korisnici");
        APIService _ulogeService = new APIService("Uloge");

        //-----------------------------------------------------------------------------------
        public static string GenerateSalt()
        {
            var buf = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buf);
            return Convert.ToBase64String(buf);
        }
        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetKorisnici()
        {
            List<Korisnici> list = await _service.Get<List<Korisnici>>(null);

            foreach (var item in list)
            {
                item.Uloge = "";
                foreach (var x in item.KorisniciUloge)
                {
                    item.Uloge += $"{x.Uloga.Naziv} ";
                }

                //if (item.Slika == null || item.Slika.Length == 0)
                //{
                //    item.Slika = ImageHelper.ImageToByteArray(Resources.default_profile);
                //}
            }

            return Json(new { data = list });
        }

        [Autorizacija(administrator: true/*, moderator: true, korisnik: true*/)]

        [HttpGet]
        public async Task<IActionResult> Manage(int id)
        {
            ViewBag.KorisnikId = id;
            var user = await _service.GetById<Model.Korisnici>(id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return NotFound();
            }


            KorisniciUpsertRequest request = new KorisniciUpsertRequest();
            await PrepareCheckboxData(user, request);
            ViewBag.UserName = user.KorisnickoIme;

            if (user != null && id != 0)
            {
                request.Ime = user.Ime;
                request.Prezime = user.Prezime;
                request.KorisnickoIme = user.KorisnickoIme;
                request.Telefon = user.Telefon;
                request.KorisnickoIme = user.KorisnickoIme;
                request.Email = user.Email;
                //request.SlikaLink = igra.SlikaLink;

                ViewBag.Id = id;
            }
            return View(request);

        }

        private async Task PrepareCheckboxData(Korisnici user, KorisniciUpsertRequest request)
        {
            var uloge = await _ulogeService.Get<List<Model.Uloge>>(null);//sve

            request.CheckBox = new List<CheckBoxHelper>();

            foreach (var item in uloge)
            {
                if (user.KorisniciUloge.Any(a => a.UlogaId == item.UlogaId))
                {
                    request.CheckBox.Add(new CheckBoxHelper { KonzolaId = item.UlogaId, Text = item.Naziv, IsChecked = true });
                }
                else
                {
                    request.CheckBox.Add(new CheckBoxHelper { KonzolaId = item.UlogaId, Text = item.Naziv, IsChecked = false });
                }
            }
        }

        [Autorizacija(administrator: true/*, moderator: true, korisnik: true*/)]

        [HttpPost]
        public async Task<IActionResult> Manage(int id, KorisniciUpsertRequest request)
        {
            foreach (var item in request.CheckBox)
            {
                if (item.IsChecked)
                {
                    request.Uloge.Add(item.KonzolaId);
                }
            }

            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                    return NotFound();
                }
                else
                    await _service.Update<Model.Korisnici>(id, request);
            }
            else
            {
                ViewBag.KorisnikId = id;
                var user = await _service.GetById<Model.Korisnici>(id);

                await PrepareCheckboxData(user, request);
                ViewBag.UserName = user.KorisnickoIme;

                return View(request);
            }
            return Redirect("/Korisnici/Index");
        }

        public  async Task<IActionResult> Profil()
        {
            //var korisniklist = await _service.Get<List<Model.Korisnici>>(new KorisnikSearchRequest() { KorisnickoIme = APIService.Username });
            //var korisnik = korisniklist.Where(x => x.KorisnickoIme == APIService.Username).FirstOrDefault();

            Korisnici korisnik = await HttpContext.GetLogiraniKorisnik();

            return View(korisnik);
        }

        public async Task<IActionResult> ChangePassword(KorisniciChangePasswordRequest request)
        {
            Korisnici korisnik = await HttpContext.GetLogiraniKorisnik();
            
            if (request.Password != request.PasswordPotvrda)
            {
                ModelState.AddModelError("Password", "Passwordi se ne slažu");
            }

            if (ModelState.IsValid)
            {
                var result = await _service.Update<Model.Korisnici>(korisnik.KorisnikId, new KorisniciUpdateProfileRequest
                {
                    Ime = korisnik.Ime,
                    Prezime = korisnik.Prezime,
                    Password = request.Password,
                    PasswordPotvrda = request.PasswordPotvrda,
                    Telefon = korisnik.Telefon
                }, "UpdateProfile");
                if (result != null)
                {
                    TempData["success_poruka"] = "Lozinka je uspješno izmijenjena.";
                    APIService.Password = request.Password;
                    return RedirectToAction("Profil", new { passwordChanged = true });
                }
                else
                    ModelState.AddModelError("Password", "Greška prilikom izmjene lozinke.");
            }
            TempData["error_count"] = ModelState.ErrorCount;
            return View("Profil", korisnik);
        }
        

        public async Task<IActionResult> ChangePhoneNumber(KorisniciChangePhoneNumberRequest request)
        {
            Korisnici korisnik = await HttpContext.GetLogiraniKorisnik();

            if (ModelState.IsValid)
            {
                var result = await _service.Update<Model.Korisnici>(korisnik.KorisnikId, new KorisniciUpdateProfileRequest
                {
                    Ime = korisnik.Ime,
                    Prezime = korisnik.Prezime,
                    Telefon = request.Telefon
                }, "UpdateProfile");
                if(result != null)
                {
                    TempData["success_poruka"] = "Broj telefona je uspješno izmijenjen.";
                    return RedirectToAction("Profil");
                }
                else
                    ModelState.AddModelError("Telefon", "Greška prilikom izmjene telefona.");
            }
            return View("Profil", korisnik);
        }

        [Autorizacija(administrator: true/*, moderator: true, korisnik: true*/)]

        [HttpGet]
        public async Task<IActionResult> NoviKorisnik()
        {
            var ulogeList = await _ulogeService.Get<List<Model.Uloge>>(null);

            List<CheckBoxHelper> listauloga = new List<CheckBoxHelper>();

            listauloga = ulogeList.Select(a => new CheckBoxHelper
            {
                Id = a.UlogaId,
                Text = a.Naziv,
                IsChecked = false,                
                KonzolaId = a.UlogaId
            }).ToList();

            KorisniciUpsertRequest request = new KorisniciUpsertRequest
            {
                CheckBox = listauloga
            };
            return View(request);
        }

        [Autorizacija(administrator: true/*, moderator: true, korisnik: true*/)]

        [HttpPost]
        public async Task<IActionResult> NoviKorisnik(KorisniciUpsertRequest request, IFormFile file)
        {
            foreach (var item in request.CheckBox)
            {
                if (item.IsChecked)
                {
                    request.Uloge.Add(item.KonzolaId);
                }
            }

            if (ModelState.IsValid)
            {
                request.Slika = ImageHelper.GetImageByteArray(file);

                await _service.Insert<Model.Korisnici>(request);
            } 
            else
            {
                return View(request);
            }

            return Redirect("/Korisnici/Index");
        }

    }
}
