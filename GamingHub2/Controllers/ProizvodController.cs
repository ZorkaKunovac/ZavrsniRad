using GamingHub2.Model.Requests;
using GamingHub2.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingHub2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProizvodController : BaseCRUDController<Model.Proizvod, ProizvodSearchRequest, ProizvodInsertRequest, ProizvodUpdateRequest>
    {
        public ProizvodController(IProizvodService service) : base(service)
        {
        }
    }
}
