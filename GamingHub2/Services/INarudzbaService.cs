using GamingHub2.Model;
using GamingHub2.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingHub2.Services
{
    public interface INarudzbaService : ICRUDService<Narudzba, NarudzbaSearchRequest, NarudzbaUpsertRequest, NarudzbaUpsertRequest>
    {

    }
}
