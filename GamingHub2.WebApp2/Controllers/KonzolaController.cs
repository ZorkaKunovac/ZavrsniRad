using GamingHub2.Model;
using GamingHub2.Model.Requests;
using GamingHub2.WebApp2.Helper;
using GamingHub2.WebApp2.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingHub2.WebApp2.Controllers
{
    [Autorizacija(administrator: true/*, moderator: true, korisnik: true*/)]
    public class KonzolaController : Controller
    {
        APIService _service = new APIService("Konzola");

        public async Task<IActionResult> Index()
        {
            List<Konzola> konzolas = await _service.Get<List<Konzola>>(null);

            return View(konzolas);
        }

        [HttpGet]
        public async Task<IActionResult> Uredi(int id)
        {
            KonzolaUpsertRequest request = new KonzolaUpsertRequest();
            if (id == 0)
            {
                request = new KonzolaUpsertRequest() { };
            }
            else
            {
                var konzola = await _service.GetById<Model.Konzola>(id);

                request.Naziv = konzola.Naziv;
                request.Detalji = konzola.Detalji;
            }
            ViewBag.Id = id;
            return View(request);
        }


        [HttpPost]
        public async Task<IActionResult> Uredi(int id, KonzolaUpsertRequest request)
        {
            Konzola konzola;

            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    konzola = new Konzola();
                    await _service.Insert<Model.Konzola>(request);
                }
                else
                {
                    var t = await _service.Update<Model.Konzola>(id, request);
                }
            }
            else
            {
                return View(request);
            }
            return Redirect("/Konzola/Index");
        }

    }
}
