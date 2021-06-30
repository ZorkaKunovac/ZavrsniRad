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


            /*
             * 'The expression 'x.Igra.Naziv' is invalid inside an 'Include' operation, since it does not represent a property access: 't => t.MyProperty'. 
             * To target navigations declared on derived types, use casting ('t => ((Derived)t).MyProperty') or the 'as' operator ('t => (t as Derived).MyProperty').
             * Collection navigation access can be filtered by composing Where, OrderBy(Descending), ThenBy(Descending), 
             * Skip or Take operations. For more information on including related data, see http://go.microsoft.com/fwlink/?LinkID=746393.'
             */

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
