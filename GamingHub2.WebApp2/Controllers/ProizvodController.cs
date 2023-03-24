using GamingHub2.Model;
using GamingHub2.Model.Requests;
using GamingHub2.WebApp2.Helper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using GamingHub2.WebApp2.Helpers;
//using System.Web.Mvc;

namespace GamingHub2.WebApp2.Controllers
{
    [Autorizacija(administrator: true, moderator: true/*, korisnik: true*/)]

    public class ProizvodController : Controller
    {
        APIService _service = new APIService("Proizvod");
        APIService _igraKonzolaService = new APIService("IgraKonzola");

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetProizvode()
        {
            List<Proizvod> proizvods = await _service.Get<List<Proizvod>>(null);

            return Json(new { data = proizvods });
        }


        [HttpGet]
        public async Task<IActionResult> Dodaj()
        {
            var proizvodi = await _service.Get<List<Proizvod>>(null);
            var igrakonzola = await _igraKonzolaService.Get<List<IgraKonzola>>(null);

            ProizvodInsertRequest request = new ProizvodInsertRequest()
            {
                IgraKonzola = igrakonzola.Where(ik => !proizvodi.Any(p => p.IgraKonzolaID == ik.ID))
                .Select(ik => new SelectListItem
                {
                    Value = ik.ID.ToString(),
                    Text = ik.Naziv
                })/*.Distinct()*/.ToList()
            };
            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> Dodaj(ProizvodInsertRequest request)
        {
            var igrakonzola = await _igraKonzolaService.Get<List<IgraKonzola>>(null);
            if (ModelState.IsValid)
            {
                request.NazivProizvoda = igrakonzola.Where(ik => ik.ID == request.IgraKonzolaID)
                 .Select(ik => ik.Naziv).SingleOrDefault();
                await _service.Insert<Model.Proizvod>(request);
            }

            return Redirect("/Proizvod/Index");
        }

        [HttpGet]
        public async Task<IActionResult> Uredi(int id)
        {
            var proizvod = await _service.GetById<Model.Proizvod>(id);
            ProizvodUpdateRequest request = new ProizvodUpdateRequest()
            {
                NazivProizvoda = proizvod.NazivProizvoda,
                ProdajnaCijena = proizvod.ProdajnaCijena,
                Popust = proizvod.Popust,
                Status = (bool)proizvod.Status 
            };

            ViewBag.Id = id;
            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> Uredi(int id, ProizvodUpdateRequest request)
        {
            if (ModelState.IsValid)
                await _service.Update<Model.Proizvod>(id, request);
            else
                return View(request);

            return Redirect("/Proizvod/Index");
        }

    }
}
