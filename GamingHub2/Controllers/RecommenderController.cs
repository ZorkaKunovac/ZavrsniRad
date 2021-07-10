using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamingHub2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamingHub2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecommenderController : ControllerBase
    {
        private readonly IRecommenderService _service;

        public RecommenderController(IRecommenderService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{ProizvodID}")]
        public List<Model.Proizvod> GetSlicneProizvode(int ProizvodID)
        {
            return _service.GetSlicneProizvode(ProizvodID);
        }
    }
}