using AutoMapper;
using GamingHub2.Model;
using GamingHub2.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingHub2.Services
{
    public class NarudzbaService : BaseCRUDService<Model.Narudzba, Database.Narudzba, NarudzbaSearchRequest, NarudzbaUpsertRequest, NarudzbaUpsertRequest>, INarudzbaService
    {
        public NarudzbaService(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IEnumerable<Narudzba> Get(NarudzbaSearchRequest search = null)
        {
            var entity = Context.Set<Database.Narudzba>().AsQueryable();

            if (search?.NarudzbaID !=null)
            {
                entity = entity.Where(x => x.NarudzbaId == search.NarudzbaID);
            }

            var list = entity.ToList();

            return _mapper.Map<List<Model.Narudzba>>(list);
        }
    }
}
