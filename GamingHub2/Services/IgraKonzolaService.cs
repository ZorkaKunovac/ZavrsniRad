using AutoMapper;
using GamingHub2.Database;
using GamingHub2.Model.Requests;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingHub2.Services
{
    public class IgraKonzolaService : BaseReadService<Model.IgraKonzola, Database.IgraKonzola, IgraKonzolaSearchRequest>, IIgraKonzolaService
    {
        public IgraKonzolaService(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IEnumerable<Model.IgraKonzola> Get(IgraKonzolaSearchRequest search = null)
        {
            var entity = Context.Set<Database.IgraKonzola>().AsQueryable();

            if (search?.IncludeList?.Length > 0)
            {
                foreach (var item in search.IncludeList)
                {
                    entity = entity.Include(item);
                }
            }

            // return _mapper.Map<List<Model.IgraKonzola>>(list);
            return Context.IgraKonzola.Select(x => new Model.IgraKonzola
            {
                ID = x.ID,
                DatumIzmjene = x.DatumIzmjene,
                IgraID = x.IgraID,
                KonzolaID = x.KonzolaID,
                Naziv = x.Igra.Naziv + " - " + x.Konzola.Naziv
            });
        }

    }
}
