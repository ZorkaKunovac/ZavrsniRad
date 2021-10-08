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
    public class RecenzijaController : Controller
    {
        APIService _service = new APIService("Recenzija");

        public async Task<IActionResult> Index()
        {
            List<Recenzija> recenzijas = await _service.Get<List<Recenzija>>(null);

            return View(recenzijas);
        }

        [HttpGet]
        public async Task<IActionResult> Uredi(int id)
        {
            RecenzijaUpsertRequest request = new RecenzijaUpsertRequest();
            if (id == 0)
            {
                request = new RecenzijaUpsertRequest() { };
            }
            else
            {
                var konzola = await _service.GetById<Model.Konzola>(id);

                //request.Naziv = konzola.Naziv;
                //request.Detalji = konzola.Detalji;
            }
            ViewBag.Id = id;
            return View(request);
        }


    }
}
