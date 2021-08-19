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
            //_servic.getbjid
            //    mapiraj request na taj objekat koji ti vrati 
            //    var vraceniObjekat;
            //vracenobjekat.nesti = request.nest1;
            //itd.
            //ovako je na winui de mi da vidim vie
            // meni prima akcija post objekat koji saljem sa forme
            //KonzolaUpsertRequest request = new KonzolaUpsertRequest()
            //{
            //    Naziv = txtNaziv.Text,
            //    Detalji = rtbDetalji.Text
            //};

            //Model.Konzola entity = null;
            //if (!_id.HasValue)
            //    entity = await _service.Insert<Model.Konzola>(request);
            //else
            //    entity = await _service.Update<Model.Konzola>(_id, request);

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
                    var t = await _service.Update<Model.Konzola>(id, request);//samo ovo ti je dovoljno
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
