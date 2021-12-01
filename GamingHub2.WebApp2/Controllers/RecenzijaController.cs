using GamingHub2.Helpers;
using GamingHub2.Model;
using GamingHub2.Model.Requests;
using GamingHub2.WebApp2.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.Web.Mvc;

namespace GamingHub2.WebApp2.Controllers
{
    public class RecenzijaController : Controller
    {
        APIService _recenzijaService = new APIService("Recenzija");
        APIService _igraService = new APIService("Igra");
        APIService _korisniciService = new APIService("Korisnici");
        APIService _zanrService = new APIService("Zanr");
        APIService _konzolaService = new APIService("Konzola");

        public async Task<IActionResult> Index()
        {
            List<Recenzija> recenzijas = await _recenzijaService.Get<List<Recenzija>>(null);
            foreach (var item in recenzijas)
            {
                item.stringSlika = ImageHelper.GetImageBase64(item.Slika);
            }
            return View(recenzijas);
        }

        [HttpGet]
        public async Task<IActionResult> DodajAsync()
        {
            RecenzijaUpsertRequest m = new RecenzijaUpsertRequest();
            List<Igra> igras = await _igraService.Get<List<Igra>>(null);

            m.Igre = igras.Select(i => new SelectListItem
            {
                Value = i.Id.ToString(),
                Text = i.Naziv
            }).ToList();
            m.DatumObjave = DateTime.Now;
            return View(m);
        }

        [HttpPost]
        public async Task<IActionResult> DodajAsync(RecenzijaUpsertRequest recenzija, IFormFile file)
        {
            var korisniklist = await _korisniciService.Get<List<Model.Korisnici>>(new KorisnikSearchRequest() { KorisnickoIme = APIService.Username });
            var korisnik = korisniklist.Where(x => x.KorisnickoIme == APIService.Username).FirstOrDefault();
            if (ModelState.IsValid)
            {
                Recenzija novaRecenzija = new Recenzija
                {
                    Naslov = recenzija.Naslov,
                    DatumObjave = recenzija.DatumObjave,
                    Sadrzaj = recenzija.Sadrzaj,
                    IgraId = recenzija.IgraId,
                    Slika = ImageHelper.GetImageByteArray(file),
                    VideoRecenzija = recenzija.VideoRecenzija,
                    KorisnikId = korisnik.KorisnikId
                };

                await _recenzijaService.Insert<Model.Recenzija>(novaRecenzija);
            }
            else
            {
                return View(recenzija);
            }

            return Redirect("/Recenzija/Index");
        }

        [HttpGet]
        public async Task<IActionResult> Uredi(int id)
        {
            var recenzija = await _recenzijaService.GetById<Model.Recenzija>(id);
            List<Igra> igre = await _igraService.Get<List<Igra>>(null);

            RecenzijaUpsertRequest request = new RecenzijaUpsertRequest()
            {
                Naslov = recenzija.Naslov,
                DatumObjave = recenzija.DatumObjave,
                Sadrzaj = recenzija.Sadrzaj,
                IgraId = recenzija.IgraId,
                ImeIgre = igre.Where(i => i.Id == recenzija.IgraId).Select(i => i.Naziv).SingleOrDefault(),
                stringSlika = ImageHelper.GetImageBase64(recenzija.Slika),
                VideoRecenzija = recenzija.VideoRecenzija,
                KorisnikId = recenzija.KorisnikId
             };

            ViewBag.Id = id;
            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> Uredi(int id, RecenzijaUpsertRequest request, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                var novaSlika = ImageHelper.GetImageByteArray(file);
                if (novaSlika != null)
                {
                    request.Slika = novaSlika;
                }
                else
                {
                    var recenzija = await _recenzijaService.GetById<Model.Recenzija>(id);
                    request.Slika = recenzija.Slika;
                }
                await _recenzijaService.Update<Model.Recenzija>(id, request);
            }
            else
                return View(request);

            return Redirect("/Recenzija/Index");
        }

        public async Task<IActionResult> DetaljiAsync(int RecenzijaID)
        {
            var odredjenaRecenzija = await _recenzijaService.GetById<Model.Recenzija>(RecenzijaID);
            var listaRecenzija = await _recenzijaService.Get<List<Model.Recenzija>>();
            var igraIzRecenzije = await _igraService.GetById<Model.Igra>(odredjenaRecenzija.IgraId);

            var m = listaRecenzija.Where(r => r.ID == RecenzijaID)
                     .Select(r => new RecenzijaDetaljiVM
                     {
                         //  RecenzijaDetaljiVM recenzija = new RecenzijaDetaljiVM()
                         ID = r.ID,
                         Naslov = r.Naslov,
                         DatumObjaveRecenzije = r.DatumObjave,
                         Sadrzaj = r.Sadrzaj,
                         VideoLink = r.VideoRecenzija,
                         SlikaLink = ImageHelper.GetImageBase64(r.Slika),
                         Korisnik = r.Korisnik.KorisnickoIme,
                         Developer = r.Igra.Developer,
                         Izdavac = r.Igra.Izdavac,
                         DatumIzlaskaIgre = r.Igra.DatumIzlaska,
                         Naziv = r.Igra.Naziv,

                         Zarnovi = igraIzRecenzije.IgraZanr.Where(iz => iz.IgraID == r.IgraId).Select(iz => iz.Zanr.Naziv).ToList(),
                         Konzole = igraIzRecenzije.IgraKonzola.Where(ik => ik.IgraID == r.IgraId)
                         .Select(ik => ik.Konzola.Naziv).ToList(),
                         
                         NajnovijeRecenzije = listaRecenzija.OrderByDescending(r => r.DatumObjave)
                         .Select(rw => new RecenzijaDetaljiVM.RecenzijaRow
                         {
                             Id = rw.ID,
                             DatumObjaveRecenzije = rw.DatumObjave,
                             Naslov = rw.Naslov,
                             SlikaLink = ImageHelper.GetImageBase64(rw.Slika),
                         }).Take(3)
                         .ToList()
                     }).FirstOrDefault();

            return View(m);
        }

 
        public async Task<IActionResult> Obrisi(int RecenzijaID)
        {
            var recenzija = _recenzijaService.GetById<Model.Recenzija>(RecenzijaID);
            if (recenzija != null)
            {
                await _recenzijaService.Delete<Model.Recenzija>(RecenzijaID);
            }

            return Redirect("/Recenzija/Index");
        }

 
    }
}

