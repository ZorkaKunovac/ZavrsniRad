using GamingHub2.Model;
using GamingHub2.Model.Requests;
using GamingHub2.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingHub2.Controllers
{
    public class NarudzbaController : BaseCRUDController<Model.Narudzba, NarudzbaSearchRequest, NarudzbaUpsertRequest, NarudzbaUpsertRequest>
    {
        public NarudzbaController(INarudzbaService service) : base(service)
        {
        }
    }
}
