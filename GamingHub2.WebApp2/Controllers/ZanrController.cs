using GamingHub2.Model;
using GamingHub2.Model.Requests;
using GamingHub2.WebApp2.Helper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingHub2.WebApp2.Controllers
{
    public class ZanrController : Controller
    {
        APIService _service = new APIService("Zanr");

        public async Task<IActionResult> Index(ZanrSearchRequest search = null)
        {
            List<Zanr> zanrs = await _service.Get<List<Zanr>>(null);
            if (!string.IsNullOrWhiteSpace(search?.Naziv))
            {
                zanrs = zanrs.Where(x => x.Naziv.StartsWith(search.Naziv)).ToList();
            }

            return View(zanrs);
        }

        [HttpGet]
        public async Task<IActionResult> Uredi(int id)
        {
            ZanrUpsertRequest request = new ZanrUpsertRequest();
            if (id == 0)
            {
                request = new ZanrUpsertRequest() { };
            }
            else
            {
                var zanr = await _service.GetById<Model.Zanr>(id);
                request.Naziv = zanr.Naziv;
                request.Opis = zanr.Opis;
            }
            ViewBag.Id = id;
            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> Uredi(int id, ZanrUpsertRequest request)
        {
            Zanr zanr;
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    zanr = new Zanr();
                    await _service.Insert<Model.Zanr>(request);
                }
                else
                    await _service.Update<Model.Zanr>(id, request);
            }
            else
            {
                return View(request);
            }
            return Redirect("/Zanr/Index");
        }

    }
}
