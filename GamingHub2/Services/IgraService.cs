using AutoMapper;
using GamingHub2.Database;
using GamingHub2.Model;
using GamingHub2.Model.Requests;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GamingHub2.Filters;

namespace GamingHub2.Services
{
    public class IgraService : BaseCRUDService<Model.Igra, Database.Igra, IgraSearchRequest, IgraUpsertRequest, IgraUpsertRequest>, IIgraService
    {
        public IgraService(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IEnumerable<Model.Igra> Get(IgraSearchRequest search = null)
        {
            var entity = Context.Set<Database.Igra>().AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.Naziv))
            {
                entity = entity.Where(x => x.Naziv.Contains(search.Naziv));
            }

            var list = entity.ToList();

            return _mapper.Map<List<Model.Igra>>(list);
        }

        [HttpGet("{id}")]
        public override Model.Igra GetById(int id)
        {
            var entity = Context.Igra.Include("IgraKonzola.Konzola").Include("IgraZanr.Zanr")
                .Where(x => x.ID == id).FirstOrDefault();
            return _mapper.Map<Model.Igra>(entity);
        }

        public override Model.Igra Insert(IgraUpsertRequest request)
        {
            var set = Context.Set<Database.Igra>();
            var entity = _mapper.Map<Database.Igra>(request);

            set.Add(entity);
            Context.SaveChanges();

            foreach (var konzola in request.Konzole)
            {
                Context.IgraKonzola.Add(new Database.IgraKonzola()
                {
                    IgraID = entity.ID,
                    KonzolaID = konzola
                });
            }
            Context.SaveChanges();

            foreach (var zanr in request.Zanrovi)
            {
                Context.IgraZanr.Add(new Database.IgraZanr()
                {
                    IgraID = entity.ID,
                    ZanrID = zanr,
                    DatumIzmjene = DateTime.Now
                });
            }

            Context.SaveChanges();
            return _mapper.Map<Model.Igra>(entity);
        }

        public override Model.Igra Update(int id, IgraUpsertRequest request)
        {
            var entity = Context.Igra.Find(id);
            Context.Igra.Attach(entity);
            Context.Igra.Update(entity);

            var listIgraKonzola = Context.IgraKonzola.Where(x => x.IgraID == id).ToList();

            foreach (var item in listIgraKonzola)//one koje su u bazi
            {
                // Brisanje svih IgraKonzola objekata koji nisu sadrzani  u request.Konzole
                if (!request.Konzole.Contains(item.KonzolaID))
                {
                    if (Context.Proizvod.Any(x => x.IgraKonzolaID == item.ID))
                    {
                        throw new UserException("Nije dozvoljeno brisanje igre na konzoli za koju ima kreiran proizvod.");
                    }

                    Context.IgraKonzola.Remove(item);

                }
            }
            Context.SaveChanges();


            foreach (var konzola in request.Konzole)
            {
                if (konzola != 0)
                {
                    // IgraKonzola vec postoji, ne treba kreirati isti zapis ponovo

                    if (Context.IgraKonzola.Any(x => x.KonzolaID == konzola && x.IgraID == entity.ID))
                        continue;

                    Database.IgraKonzola igrakonzola = new Database.IgraKonzola
                    {
                        IgraID = entity.ID,
                        KonzolaID = konzola,
                        DatumIzmjene = DateTime.Now
                    };
                    Context.IgraKonzola.Add(igrakonzola);
                }
            }
            Context.SaveChanges();

            var listIgraZanr = Context.IgraZanr.Where(x => x.IgraID == id).ToList();

            foreach (var item in listIgraZanr)
            {
                Context.IgraZanr.Remove(item);
            }
            Context.SaveChanges();


            foreach (var zanr in request.Zanrovi)
            {
                if (zanr != 0)
                {
                    Database.IgraZanr igrazanr = new Database.IgraZanr
                    {
                        IgraID = entity.ID,
                        ZanrID = zanr,
                        DatumIzmjene = DateTime.Now
                    };
                    Context.IgraZanr.Add(igrazanr);
                }
            }
            Context.SaveChanges();

            _mapper.Map(request, entity);
            Context.SaveChanges();
            return _mapper.Map<Model.Igra>(entity);
        }
    }
}
