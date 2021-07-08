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

            if (!string.IsNullOrWhiteSpace(search?.NazivKonzole))
            {
                entity = entity.Where(x => x.NazivProizvoda.Contains(search.NazivKonzole));
            }

            if (search.IncludeIgraKonzola.HasValue && search.IncludeIgraKonzola == true)
            {
                entity = entity.Include(x => x.IgraKonzola);
            }

            //if (search.IgraKonzolaId != 0 && search.IgraKonzolaId.HasValue)
            //{
            //    entity = entity.Where(x => x.IgraKonzolaID == search.IgraKonzolaId);
            //}

            var list = entity.ToList();
            var mappedList = _mapper.Map<List<Model.Proizvod>>(list);

            if (search.IncludeIgraKonzola.HasValue && search.IncludeIgraKonzola == true)
            {
                foreach (var item in mappedList)
                {
                    item.Slika = Context.Igra.Find(item.IgraKonzola.IgraID).SlikaLink;
                }
            }

            return mappedList;
        }
    }
}
