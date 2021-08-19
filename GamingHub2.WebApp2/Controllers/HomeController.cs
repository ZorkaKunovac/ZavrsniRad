using GamingHub2.Model;
using GamingHub2.Model.Requests;
using GamingHub2.WebApp2.Helper;
using GamingHub2.WebApp2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GamingHub2.WebApp2.Controllers
{
 
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        APIService _service = new APIService("Konzola");
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            List<Konzola> konzolas = await _service.Get<List<Konzola>>(null);

            return View(konzolas);
        }


        //public ActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Create(KonzolaUpsertRequest konzola)
        //{
        //    KonzolaUpsertRequest request = new KonzolaUpsertRequest()
        //    {
        //        Naziv = konzola.Naziv,
        //        Detalji = konzola.Detalji
        //    };

        //    await _service.Insert<Model.Konzola>(request);

        //    return Redirect("/Igra/Index");
        //}


        [HttpGet]
        public async Task<IActionResult> Uredi(int KonzolaID)
        {
            //KonzolaUrediVM m;
            //if (KonzolaID == 0)
            //{
            //    m = new KonzolaUrediVM() { };
            //}
            //else
            //{
            //    m= await _service.GetById<Model.Konzola>(KonzolaID);
            //    m = db.Konzola.Where(k => k.ID == KonzolaID)
            //    .Select(k => new KonzolaUrediVM
            //    {
            //        Id = k.ID,
            //        Naziv = k.Naziv,
            //        Detalji = k.Detalji,
            //    }).Single();
            //}
            //return View(m);

            KonzolaUpsertRequest request = new KonzolaUpsertRequest();
            if (KonzolaID == 0)
            {
                request = new KonzolaUpsertRequest() { };
            }
            else
            {
                var konzola = await _service.GetById<Model.Konzola>(KonzolaID);

                request.Naziv = konzola.Naziv;
                request.Detalji = konzola.Detalji;
            }

            return View(request);
        }


        //[HttpGet]
        //public async Task<IActionResult> Uredi(int KonzolaID)
        //{
        //    //KonzolaUrediVM m;
        //    //if (KonzolaID == 0)
        //    //{
        //    //    m = new KonzolaUrediVM() { };
        //    //}
        //    //else
        //    //{
        //    //    m= await _service.GetById<Model.Konzola>(KonzolaID);
        //    //    m = db.Konzola.Where(k => k.ID == KonzolaID)
        //    //    .Select(k => new KonzolaUrediVM
        //    //    {
        //    //        Id = k.ID,
        //    //        Naziv = k.Naziv,
        //    //        Detalji = k.Detalji,
        //    //    }).Single();
        //    //}
        //    //return View(m);

        //    KonzolaUpsertRequest request;
        //    if (KonzolaID == 0)
        //    {
        //        request = new KonzolaUpsertRequest() { };
        //    }
        //    else
        //    {
        //        var konzola = await _service.GetById<Model.Konzola>(KonzolaID);

        //        request.Naziv = konzola.Naziv;
        //        request.Detalji = konzola.Detalji;
        //    }

        //    return View(request);
        //}

        //public async Task<IActionResult> Index()
        //{
        //    List<Model.Konzola> konzolas = new List<Model.Konzola>();
        //    konzolas = await service.Get<List<Model.Konzola>>(null);

        //    return View(konzolas);
        //}
        //public async Task<IActionResult> Index()
        //{
        //    List<KonzolaViewModel> konzolas = new List<KonzolaViewModel>();
        //    //neki tekst

        //    HttpClient client = service.Initial();
        //    HttpResponseMessage res = await client.GetAsync("api/konzola");
        //    if (res.IsSuccessStatusCode)
        //    {
        //        var results = res.Content.ReadAsStringAsync().Result;
        //        konzolas = JsonConvert.DeserializeObject<List<KonzolaViewModel>>(results);
        //    }

        //    return View(konzolas);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Create()
        //{
        //    HttpClient client = service.Initial();
        //    List<KonzolaViewModel> konzolas = new List<KonzolaViewModel>();
        //    //neki tekst

        //    HttpResponseMessage res = await client.GetAsync("api/konzola");
        //    if (res.IsSuccessStatusCode)
        //    {
        //        var results = res.Content.ReadAsStringAsync().Result;
        //        konzolas = JsonConvert.DeserializeObject<List<KonzolaViewModel>>(results);
        //    }

        //    return View(konzolas);
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
