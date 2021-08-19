using GamingHub2.Helpers;
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
    public class IgraController : Controller
    {
        APIService _service = new APIService("Igra");
        APIService _igrakonzolaservice = new APIService("IgraKonzola");
        APIService _konzolaService = new APIService("Konzola");
        APIService _proizvodService = new APIService("Proizvod");



        public async Task<IActionResult> Index(IgraSearchRequest search = null)
        {
            List<Igra> igras = await _service.Get<List<Igra>>(null);
            if (!string.IsNullOrWhiteSpace(search?.Naziv))
            {
                igras = igras.Where(x => x.Naziv.StartsWith(search.Naziv)).ToList();
            }

            return View(igras);
        }

         [HttpGet]
        public async Task<IActionResult> Uredi(int id)
        {
            var igra = await _service.GetById<Model.Igra>(id);//postojece
            var konzole = await _konzolaService.Get<List<Model.Konzola>>(null);//sve
            IgraUpsertRequest request = new IgraUpsertRequest();
            request.CheckBox = new List<CheckBoxHelper>();
            foreach (var item in konzole)
            {
                if (igra.IgraKonzola.Any(a => a.KonzolaID == item.ID))
                {
                    request.CheckBox.Add(new CheckBoxHelper { KonzolaId = item.ID, Text = item.Naziv, IsChecked = true });
                }
                else
                {
                    request.CheckBox.Add(new CheckBoxHelper { KonzolaId = item.ID, Text = item.Naziv, IsChecked = false });
                }
            }
            request.Naziv = igra.Naziv;
            request.Developer = igra.Developer;
            request.Izdavac = igra.Izdavac;
            request.DatumIzlaska = igra.DatumIzlaska;
            request.SlikaLink = igra.SlikaLink;



            //var igrekonzole = await _igrakonzolaservice.Get<List<IgraKonzola>>(null);
            //var proizvodi = await _proizvodService.Get<List<Proizvod>>(null);

            //IgraUpsertRequest request = new IgraUpsertRequest();
            //if (id == 0)
            //{
            //    request = new IgraUpsertRequest() { };
            //}
            //else
            //{
            //    var igra = await _service.GetById<Model.Igra>(id);
            //    request.Naziv = igra.Naziv;
            //    request.Developer = igra.Developer;
            //    request.Izdavac = igra.Izdavac;
            //    request.DatumIzlaska = igra.DatumIzlaska;
            //    var konzoleList = await _konzolaService.Get<List<Model.Konzola>>(null);

            //    //foreach (var item in igra.IgraKonzola)
            //    //{
            //    //    for (int i = 0; i < konzoleList.Items.Count; i++)
            //    //    {
            //    //        Model.Konzola trenutni = (Model.Konzola)clbKonzole.Items[i];
            //    //        if (trenutni.ID == item.KonzolaID)
            //    //        {
            //    //            clbKonzole.SetItemCheckState(i, CheckState.Checked);
            //    //        }
            //    //    }
            //    //}

            //    var listIgraKonzola = igrekonzole.Where(x => x.IgraID == id).ToList();
            //    //var listProizvodi  = proizvodi.Where
            //    foreach (var item in listIgraKonzola)
            //    {
            //        // Brisanje svih IgraKonzola objekata koji nisu sadrzani  u request.Konzole
            //        if (!request.Konzole.Contains(item.KonzolaID))
            //        {
            //            if (proizvodi.Any(x => x.IgraKonzolaID == item.ID))
            //            {
            //                throw new Exception("Nije dozvoljeno brisanje igre na konzoli za koju ima kreiran proizvod.");
            //            }

            //            listIgraKonzola.Remove(item);

            //        }
            //    }
            //    //Context.SaveChanges();


            //    //foreach (var konzola in request.Konzole)
            //    //{
            //    //    if (konzola != 0)
            //    //    {
            //    //        // IgraKonzola vec postoji, ne treba kreirati isti zapis ponovo

            //    //        if (Context.IgraKonzola.Any(x => x.KonzolaID == konzola && x.IgraID == entity.ID))
            //    //            continue;

            //    //        Database.IgraKonzola igrakonzola = new Database.IgraKonzola
            //    //        {
            //    //            IgraID = entity.ID,
            //    //            KonzolaID = konzola,
            //    //            DatumIzmjene = DateTime.Now
            //    //        };
            //    //        Context.IgraKonzola.Add(igrakonzola);
            //    //    }
            //    //}
            //    //Context.SaveChanges();

            //    // request.CheckBox =igrekonzole
            //    //.Where(ik => ik.IgraID == id)
            //    //.Select(ik => new CheckBoxHelper
            //    //{
            //    //    Id = ik.ID,
            //    //    Text = ik.Konzola.Naziv,
            //    //    IsChecked = ik.IsChecked,
            //    //    KonzolaId = ik.KonzolaID
            //    //}).ToList()
            //}
            ViewBag.Id = id;
            return View(request);
            //return View();
        }

        [HttpPost]
        public async Task<IActionResult> Uredi(int id, IgraUpsertRequest request)
        {
            foreach (var item in request.CheckBox)
            {
                if (item.IsChecked)
                {
                    request.Konzole.Add(item.KonzolaId);
                }
            }
            Igra igra;
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    igra = new Igra();
                    await _service.Insert<Model.Igra>(request);
                }
                else
                    await _service.Update<Model.Igra>(id, request);
            }
            else
            {
                return View(request);
            }
            return Redirect("/Igra/Index");
        }

    }
}
