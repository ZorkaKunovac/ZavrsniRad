using GamingHub2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamingHub2.Model.Requests;

namespace GamingHub2.Services
{
    public interface IProizvodService : ICRUDService<Proizvod, object, ProizvodInsertRequest, ProizvodUpdateRequest>
    {
        
    }
}
