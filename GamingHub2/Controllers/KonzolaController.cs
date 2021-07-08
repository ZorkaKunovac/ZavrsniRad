using GamingHub2.Model;
using GamingHub2.Model.Requests;
using GamingHub2.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingHub2.Controllers
{
    [Authorize]
    public class KonzolaController : BaseCRUDController<Model.Konzola, object, KonzolaUpsertRequest, KonzolaUpsertRequest>
    {
        public KonzolaController(IKonzolaService service) : base(service)
        {
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public override Model.Konzola Insert([FromBody] KonzolaUpsertRequest request) //virtual?
        {
            return _crudService.Insert(request);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator")]
        public override Model.Konzola Update(int id, [FromBody] KonzolaUpsertRequest request)
        {
            return _crudService.Update(id, request);
        }


    }
}