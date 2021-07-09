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
    public class NarudzbaStavkaController : BaseCRUDController<Model.NarudzbaStavka, object, NarudzbaStavkaInsertRequest, object>
    {
        public NarudzbaStavkaController(INarudzbaStavkaService service) : base(service)
        {
        }
    }
}
