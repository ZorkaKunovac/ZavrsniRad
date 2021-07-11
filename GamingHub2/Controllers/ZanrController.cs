using GamingHub2.Model;
using GamingHub2.Model.Requests;
using GamingHub2.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GamingHub2.Controllers
{
    [Authorize(Roles = "Admin,Moderator")]
    [ApiController]
    [Route("api/[controller]")]
    public class ZanrController : BaseCRUDController<Model.Zanr, ZanrSearchRequest, ZanrUpsertRequest, ZanrUpsertRequest>
     {

        public ZanrController(IZanrService service) : base(service)
        {
        }


        //PRVE VJEZBE

        //public IZanrService _service { get; set; }
        ////private ApplicationDbContext db;
        //public ZanrController(IZanrService service)
        //{
        //    _service = service;
        //}

        //public IEnumerable<Zanr> Get()
        //{
        //    return _service.Get();
        //}

        //[HttpGet("{id}")]
        //public Zanr GetById(int id)
        //{
        //    return _service.GetById(id);
        //}

        //[HttpPost]
        //public Zanr Insert(Zanr zanr)
        //{
        //    return _service.Insert(zanr);
        //}


        //[HttpPut("{id}")]
        //public Zanr Update(int id, Zanr zanr)
        //{
        //    return _service.Update(id, zanr);
        //}

        //KRAJ PRVIH VJEZBI


        //DRUGE VJEZBE

        //[HttpGet]
        //public IList<Model.Zanr> Get()
        //{
        //    return _service.Get();
        //}

        //[HttpGet("{id}")]
        //public Model.Zanr GetById(int id)
        //{
        //    return _service.GetById(id);
        //}

        //[HttpPost]
        //public Model.Zanr Insert(Zanr zanr)
        //{
        //    return _service.Insert(zanr);
        //}

        //[HttpPut("{id}")]
        //public Model.Zanr Update(int id, Zanr zanr)
        //{
        //    return _service.Update(id, zanr);
        //}

    }
}

