using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GamingHub2.Model;
using GamingHub2.Model.Requests;
using GamingHub2.Services;

namespace GamingHub2.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class KorisniciController : ControllerBase
    {
        private readonly IKorisnikService _service;
        public KorisniciController(
            IKorisnikService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<Model.Korisnici> Get([FromQuery] KorisnikSearchRequest request)
        {
            return _service.Get(request);
        }
        [HttpGet("{id}")]
        public Model.Korisnici GetById(int id)
        {
            return _service.GetById(id);
        }
        [HttpGet("MojProfil")]
        public Model.Korisnici MojProfil()
        {
            return _service.MojProfil();
        }
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public Model.Korisnici Insert(KorisniciUpsertRequest request)
        {
            return _service.Insert(request);
        }

        [AllowAnonymous]
        [HttpPost("Registracija")]
        public Model.Korisnici Registracija(KorisniciRegistracijaRequest request)
        {
            return _service.Registracija(request);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public Model.Korisnici Update(int id, [FromBody] KorisniciUpsertRequest request)
        {
            return _service.Update(id, request);
        }
        [HttpPut("UpdateProfile")]
        public Model.Korisnici UpdateProfile([FromBody] KorisniciUpdateProfileRequest request)
        {
            return _service.UpdateProfile(request);
        }
    }
}