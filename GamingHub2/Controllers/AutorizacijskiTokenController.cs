using GamingHub2.Model.Requests;
using GamingHub2.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingHub2.Controllers
{
    public class AutorizacijskiTokenController :BaseCRUDController<Model.AutorizacijskiToken, AutorizacijskiTokenSearchRequest, AutorizacijskiTokenInsertRequest, object>
    {
        public AutorizacijskiTokenController(IAutorizacijskiTokenService service) : base(service)
        {
        }

        [HttpDelete("{id}")]
        public virtual Model.AutorizacijskiToken Delete(int id)
        {
            return _crudService.Delete(id);
        }

    }
}
