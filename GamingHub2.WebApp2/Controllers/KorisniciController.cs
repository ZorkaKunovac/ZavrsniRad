using GamingHub2.Helpers;
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

        public async Task<IActionResult> Index(KorisnikSearchRequest request = null)
        {
            List<Korisnici> query = await _service.Get<List<Korisnici>>(null);

            if (!string.IsNullOrWhiteSpace(request?.Ime))
            {
                query = query.Where(x => x.Ime.StartsWith(request.Ime)).ToList();
            }

            if (!string.IsNullOrWhiteSpace(request?.Prezime))
            {
                query = query.Where(x => x.Prezime.StartsWith(request.Prezime)).ToList();
            }

            if (!string.IsNullOrWhiteSpace(request?.KorisnickoIme))
            {
                query = query.Where(x => x.KorisnickoIme.StartsWith(request.KorisnickoIme)).ToList();
            }

            var list = query.ToList();

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

            return View(list);
        }

        public async Task<IActionResult> GetKorisnici(KorisnikSearchRequest request = null)
        {
            List<Korisnici> query = await _service.Get<List<Korisnici>>(null);

            if (!string.IsNullOrWhiteSpace(request?.Ime))
            {
                query = query.Where(x => x.Ime.StartsWith(request.Ime)).ToList();
            }

            if (!string.IsNullOrWhiteSpace(request?.Prezime))
            {
                query = query.Where(x => x.Prezime.StartsWith(request.Prezime)).ToList();
            }

            if (!string.IsNullOrWhiteSpace(request?.KorisnickoIme))
            {
                query = query.Where(x => x.KorisnickoIme.StartsWith(request.KorisnickoIme)).ToList();
            }

            var list = query.ToList();

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

            ViewBag.UserName = user.KorisnickoIme;

            var uloge = await _ulogeService.Get<List<Model.Uloge>>(null);//sve
            KorisniciUpsertRequest request = new KorisniciUpsertRequest();
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
                return View(request);
            }
            return Redirect("/Korisnici/Index");
        }

        public  async Task<IActionResult> Profil()
        {
            //var korisniklist = await _service.Get<List<Model.Korisnici>>(new KorisnikSearchRequest() { KorisnickoIme = APIService.Username });
            //var korisnik = korisniklist.Where(x => x.KorisnickoIme == APIService.Username).FirstOrDefault();

            //var entity = _service
            //    _context.Korisnik.Include("KorisniciUloge").Where(x => x.KorisnikId == TrenutniKorisnik.KorisnikId).FirstOrDefault();
            //return _mapper.Map<Model.Korisnici>(entity);

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
                return View("Profil", korisnik);
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
                    return RedirectToAction("Profil", new { passwordChanged = true });
                }
                else
                    ModelState.AddModelError("Password", "Greška prilikom izmjene lozinke.");
            }
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
                    return RedirectToAction("Profil", new { phoneChanged = true });
                else
                    ModelState.AddModelError("Password", "Greška prilikom izmjene telefona.");
            }
            return View("Profil", korisnik);
        }


        [HttpGet]
        public async Task<IActionResult> NoviKorisnik()
        {
            var ulogeList = await _ulogeService.Get<List<Model.Uloge>>(null);

            //var konzole = await _konzolaService.Get<List<Model.Konzola>>(null);//sve

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

            //KorisniciUpsertRequest request = new KorisniciUpsertRequest();
            //request.CheckBox = new List<CheckBoxHelper>();
            //foreach (var item in ulogeList)
            //{
            //    if (igra != null && igra.IgraKonzola.Any(a => a.KonzolaID == item.ID))
            //    {
            //        request.CheckBox.Add(new CheckBoxHelper { KonzolaId = item.ID, Text = item.Naziv, IsChecked = true });
            //    }
            //    else
            //    {
            //        request.CheckBox.Add(new CheckBoxHelper { KonzolaId = item.ID, Text = item.Naziv, IsChecked = false });
            //    }
            //}


            //ProizvodInsertRequest request = new ProizvodInsertRequest()
            //{
            //    IgraKonzola = igrakonzola.Where(ik => !proizvodi.Any(p => p.IgraKonzolaID == ik.ID))
            //    .Select(ik => new SelectListItem
            //    {
            //        Value = ik.ID.ToString(),
            //        Text = ik.Naziv
            //    })/*.Distinct()*/.ToList()
            //};
            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> NoviKorisnik(KorisniciUpsertRequest request, IFormFile file)
        {
            var ulogeList = await _ulogeService.Get<List<Model.Uloge>>(null);

            foreach (var item in request.CheckBox)
            {
                if (item.IsChecked)
                {
                    request.Uloge.Add(item.KonzolaId);
                }
            }
            //if (ModelState.IsValid)
            //{
            //    request.Ime =
            //}

            //var igrakonzola = await _igraKonzolaService.Get<List<IgraKonzola>>(null);
            //if (ModelState.IsValid)
            //{
            //    request.NazivProizvoda = igrakonzola.Where(ik => ik.ID == request.IgraKonzolaID)
            //     .Select(ik => ik.Naziv).SingleOrDefault();
            //    await _service.Insert<Model.Proizvod>(request);
            //}
            ////else
            ////    return View(request);
            ///       Igra igra;

            Korisnici novikorisnik;
            if (ModelState.IsValid)
            {
                novikorisnik = new Korisnici();
                novikorisnik.Slika = ImageHelper.GetImageByteArray(file);
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
