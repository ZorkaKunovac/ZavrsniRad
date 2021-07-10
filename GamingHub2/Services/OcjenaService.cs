using AutoMapper;
using GamingHub2.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingHub2.Services
{
    public class OcjenaService : BaseCRUDService<Model.Ocjena, Database.Ocjena, OcjenaSearchRequest, OcjenaUpsertRequest, OcjenaUpsertRequest>
    {
        public OcjenaService(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IEnumerable<Model.Ocjena> Get(OcjenaSearchRequest search)
        {
            var entity = Context.Set<Database.Ocjena>().AsQueryable();
            if(search.KupacId != null)
            {
                entity = entity.Where(x => x.KupacId == search.KupacId);
            }

            if(search.ProizvodId != null)
            {
                entity = entity.Where(x => x.ProizvodId == search.ProizvodId);
            }

            var list = entity.ToList();
            return _mapper.Map<List<Model.Ocjena>>(list);
        }

    }
}
