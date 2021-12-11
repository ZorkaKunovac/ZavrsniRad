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
using System.Threading.Tasks;

namespace GamingHub2.WebApp2.Controllers
{
    [Autorizacija(administrator: true, moderator: true/*, korisnik: true*/)]

    public class IgraController : Controller
    {
        APIService _service = new APIService("Igra");
        //APIService _igrakonzolaservice = new APIService("IgraKonzola");
        APIService _konzolaService = new APIService("Konzola");
        APIService _proizvodService = new APIService("Proizvod");
        APIService _zanrService = new APIService("Zanr");

        public async Task<IActionResult> Index(IgraSearchRequest search = null)
        {
            List<Igra> igras = await _service.Get<List<Igra>>(null);
            if (!string.IsNullOrWhiteSpace(search?.Naziv))
            {
                igras = igras.Where(x => x.Naziv.StartsWith(search.Naziv)).ToList();
            }

            return View(igras);
        }

        public async Task<IActionResult> GetIgre(IgraSearchRequest search = null)
        {
            List<Igra> igras = await _service.Get<List<Igra>>(null);
            if (!string.IsNullOrWhiteSpace(search?.Naziv))
            {
                igras = igras.Where(x => x.Naziv.StartsWith(search.Naziv)).ToList();
            }

            return Json(new { data = igras });
        }

 
        [HttpGet]
        public async Task<IActionResult> Uredi(int id)
        {
            var igra = await _service.GetById<Model.Igra>(id);//postojece
            var konzole = await _konzolaService.Get<List<Model.Konzola>>(null);//sve
            IgraUpsertRequest request = new IgraUpsertRequest();
            request.ListaKonzola = new List<CheckBoxHelper>();
            foreach (var item in konzole)
            {
                if (igra!=null && igra.IgraKonzola.Any(a => a.KonzolaID == item.ID))
                {
                    request.ListaKonzola.Add(new CheckBoxHelper { KonzolaId = item.ID, Text = item.Naziv, IsChecked = true });
                }
                else
                {
                    request.ListaKonzola.Add(new CheckBoxHelper { KonzolaId = item.ID, Text = item.Naziv, IsChecked = false });
                }
            }
            var zanrovi = await _zanrService.Get<List<Model.Zanr>>(null);//sve
            request.ListaZanrova = new List<CheckBoxHelper>();

            foreach (var item in zanrovi)
            {
                if (igra != null && igra.IgraZanr.Any(a => a.ZanrID == item.ID))
                {
                    request.ListaZanrova.Add(new CheckBoxHelper { KonzolaId = item.ID, Text = item.Naziv, IsChecked = true });
                }
                else
                {
                    request.ListaZanrova.Add(new CheckBoxHelper { KonzolaId = item.ID, Text = item.Naziv, IsChecked = false });
                }
            }


            if (igra != null && id != 0)
            {
                request.Naziv = igra.Naziv;
                request.Developer = igra.Developer;
                request.Izdavac = igra.Izdavac;
                request.DatumIzlaska = igra.DatumIzlaska;
                request.SlikaLink = igra.SlikaLink;
                request.stringSlika = ImageHelper.GetImageBase64(igra.SlikaLink);

                ViewBag.Id = id;
            }
            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> Uredi(int id, IgraUpsertRequest request, IFormFile file)
        {
            foreach (var item in request.ListaKonzola)
            {
                if (item.IsChecked)
                {
                    request.Konzole.Add(item.KonzolaId);
                }
            }

            foreach (var item in request.ListaZanrova)
            {
                if (item.IsChecked)
                {
                    request.Zanrovi.Add(item.KonzolaId);
                }
            }

            Igra igra;
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    request.SlikaLink = ImageHelper.GetImageByteArray(file);
                    await _service.Insert<Model.Igra>(request);
                }
                else
                {
                    var novaSlika = ImageHelper.GetImageByteArray(file);
                    if (novaSlika != null)
                    {
                        request.SlikaLink = novaSlika;
                    }
                    else
                    {
                        igra = await _service.GetById<Model.Igra>(id);
                        request.SlikaLink = igra.SlikaLink;
                    }
                    await _service.Update<Model.Igra>(id, request);
                }
            }
            else
            {
                return View(request);
            }
            return Redirect("/Igra/Index");
        }
 
    }
}
