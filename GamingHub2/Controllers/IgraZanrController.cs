using GamingHub2.Model;
using GamingHub2.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingHub2.Controllers
{
    public class IgraZanrController : Controller
    {
        //private ApplicationDbContext db;
        //public IgraZanrController(ApplicationDbContext _db)
        //{
        //    db = _db;
        //}
        //public IActionResult Index(int IgraID)
        //{
        //    IgraZanrPrikazVM m = new IgraZanrPrikazVM();
        //    m.rows = db.IgraZanr.Where(iz => iz.IgraID == IgraID)
        //     .Select(iz => new IgraZanrPrikazVM.Rows
        //     {
        //         IgraZanrID = iz.ID,
        //         Zanr = iz.Zanr.Naziv
        //     }).ToList();
        //    m.IgraID = IgraID;
        //    return View(m);
        //}
        private readonly IIgraZanrService2 _service;
        public IgraZanrController(IIgraZanrService2 service)
        {
            _service = service;
        }

        //[HttpGet]
        //public List<Model.Korisnici> Get()
        //{
        //    return _service.Get(request);
        //}

        [HttpGet]
        public IgraZanrPrikazVM Get(int IgraID)
        {
            return _service.GetIZ(IgraID);
        }

        [HttpGet("GetIZ")]
        //[Authorize]
        public IgraZanrPrikazVM GetIZ(int IgraID)
        {
            return _service.GetIZ(IgraID);
        }
    }
}
