using AutoMapper;
using GamingHub2.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingHub2.Services
{
    public class KupacService : BaseCRUDService<Model.Kupac, Database.Kupac, KupacSearchRequest, KupacUpsertRequest, KupacUpsertRequest>
    {
        public KupacService(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }


        public override IEnumerable<Model.Kupac> Get(KupacSearchRequest search)
        {
            var entity = Context.Set<Database.Kupac>().AsQueryable();
            if(search.KorisnikId.HasValue)
            {
                entity = entity.Where(x => x.KorisnikId == search.KorisnikId.Value);
            }

            var list = entity.ToList();
            return _mapper.Map<List<Model.Kupac>>(list);
        }
    }
}
