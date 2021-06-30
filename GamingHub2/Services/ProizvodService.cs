using AutoMapper;
using GamingHub2.Model.Requests;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingHub2.Services
{
    public class ProizvodService : BaseCRUDService<Model.Proizvod, Database.Proizvod, ProizvodSearchRequest, ProizvodInsertRequest, ProizvodUpdateRequest>, IProizvodService
    {
        public ProizvodService(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IEnumerable<Model.Proizvod> Get(ProizvodSearchRequest search = null)
        {
            var entity = Context.Set<Database.Proizvod>().AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.Naziv))
            {
                entity = entity.Where(x => x.NazivProizvoda.StartsWith(search.Naziv));
            }

            if (search.IgraKonzolaId != 0 && search.IgraKonzolaId.HasValue)
            {
                entity = entity.Where(x => x.IgraKonzolaID == search.IgraKonzolaId);
            }

            //var list = entity.Include(x => x.IgraKonzola.Igra).Include(x => x.IgraKonzola.Konzola).ToList();
            var list = entity.ToList();

            return _mapper.Map<List<Model.Proizvod>>(list);
        }
    }
}
