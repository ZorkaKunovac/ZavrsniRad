using AutoMapper;
using GamingHub2.Model.Requests;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingHub2.Services
{
    public class NarudzbaStavkaService : BaseCRUDService<Model.NarudzbaStavka, Database.NarudzbaStavka, object, NarudzbaStavkaInsertRequest, object>, INarudzbaStavkaService
    {
        public NarudzbaStavkaService(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IEnumerable<Model.NarudzbaStavka> Get(object search = null)
        {
            var entity = Context.Set<Database.NarudzbaStavka>().Include(x => x.Proizvod);
            var list = entity.ToList();
            return _mapper.Map<List<Model.NarudzbaStavka>>(list);
        }

    }
}
