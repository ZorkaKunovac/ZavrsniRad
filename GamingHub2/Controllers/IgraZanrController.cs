using GamingHub2.Model;
using GamingHub2.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingHub2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        private readonly IIgraZanrService _service;
        public IgraZanrController(IIgraZanrService service)
        {
            _service = service;
        }

        [HttpGet("GetIgraZanr")]
        //[HttpGet]
        //[Route("{IgraID}")]

        //[Authorize]
        public IgraZanrPrikazVM GetIgraZanr(int IgraID)
        {
            return _service.GetIgraZanr(IgraID);
        }
    }
}
