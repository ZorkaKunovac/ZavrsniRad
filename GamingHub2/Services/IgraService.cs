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

namespace GamingHub2.Services
{
    public class IgraService : BaseCRUDService<Model.Igra, Database.Igra, IgraSearchRequest , IgraUpsertRequest, IgraUpsertRequest>, IIgraService
    {
        public IgraService(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IEnumerable<Model.Igra> Get(IgraSearchRequest search = null)
        {
            var entity = Context.Set<Database.Igra>().AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.Naziv))
            {
                entity = entity.Where(x => x.Naziv.StartsWith(search.Naziv));
            }

            //Database.Igra e;
            //foreach (var konzola in search.Konzole)
            //{
            //    Context.IgraKonzola.Where(ik => ik.IgraID == e.ID))
            //                {

            //    }
            //}
            //    Context.IgraKonzola.Add(new Database.IgraKonzola()
            //    {
            //        IgraID = entity.ID,
            //        KonzolaID = konzola
            //    });

                //if (search?.IsKonzoleLoadingEnabled == true)
                //{
                //    //entity = entity.Include(x => x.);

                //    foreach (var konzola in search.Konzole)
                //    {
                //        Context.IgraKonzola.Where(ik => ik.IgraID == i.ID))
                //            {

                //        }
                //        //Context.IgraKonzola.Add(new Database.IgraKonzola()
                //        //{
                //        //    IgraID = entity.ID,
                //        //    KonzolaID = konzola
                //        //});

                //    konzola = Context.IgraKonzola
                // .Where(ik => ik.IgraID == entity.ID)
                // .Select(ik => new CheckBoxHelper
                // {
                //     Id = ik.ID,
                //     Text = ik.Konzola.Naziv,
                //     IsChecked = ik.IsChecked,
                //     KonzolaId = ik.KonzolaID
                // }).ToList();
                //}
                //    Konzola = db.IgraKonzola
                //    .Where(ik => ik.IgraID == IgraID)
                //    .Select(ik => new CheckBoxHelper
                //    {
                //        Id = ik.ID,
                //        Text = ik.Konzola.Naziv,
                //        IsChecked = ik.IsChecked,
                //        KonzolaId = ik.KonzolaID
                //    }).ToList();
                //}


                var list = entity.ToList();

            return _mapper.Map<List<Model.Igra>>(list);
        }

        [HttpGet("{id}")]
        public override Model.Igra GetById(int id)
        {
            //var entity = Context.Rezervacije.Include("DodatnaOprema.Oprema").Include(x => x.Kupac).Include("Vozilo.Model").Include(x => x.Osiguranje).Where(x => x.RezervacijaId == id).FirstOrDefault();
            //return _mapper.Map<Model.Rezervacije>(entity);
            var entity = Context.Igra.Include("IgraKonzola.Konzola").Where(x => x.ID == id).FirstOrDefault();
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

            //var listIgraKonzola = Context.IgraKonzola.Where(x => x.IgraID == id).ToList();

            //foreach (var item in listIgraKonzola)
            //{
            //    Context.IgraKonzola.Remove(item);
            //}
            //Context.SaveChanges();


            //foreach (var oprema in request.Oprema)
            //{
            //    if (oprema != 0)
            //    {

            //        Database.DodatnaOprema dodatnaOprema = new Database.DodatnaOprema
            //        {
            //            RezervacijaId = entity.RezervacijaId,
            //            OpremaId = oprema,
            //            Datum = DateTime.Now
            //        };
            //        _context.DodatnaOprema.Add(dodatnaOprema);
            //    }
            //}
            //_context.SaveChanges();




            //List<IgraKonzola> igraKonzola = Context.IgraKonzola.Where(ik => ik.IgraID == entity.ID).ToList();
            //foreach (var item in igraKonzola)
            //{
            //    request.Konzole.Add(item.ID);
            //    //foreach (var i in igra.Konzola)
            //    //{
            //    //    if (item.ID == i.Id)
            //    //    {
            //    //        item.IsChecked = i.IsChecked;
            //    //    }
            //    //}
            //}

            //List
            //foreach (var uloga in request.Uloge)
            //{
            //    Database.KorisniciUloge korisniciUloge = new KorisniciUloge();
            //    korisniciUloge.KorisnikId = entity.KorisnikId;
            //    korisniciUloge.UlogaId = uloga;
            //    korisniciUloge.DatumIzmjene = DateTime.Now;

            //    Context.KorisniciUloges.Add(korisniciUloge);
            //}

            //    Konzola = db.IgraKonzola
            //    .Where(ik => ik.IgraID == IgraID)
            //    .Select(ik => new CheckBoxHelper
            //    {
            //        Id = ik.ID,
            //        Text = ik.Konzola.Naziv,
            //        IsChecked = ik.IsChecked,
            //        KonzolaId = ik.KonzolaID
            //    }).ToList();
            //}



            _mapper.Map(request, entity);

            Context.SaveChanges();

            return _mapper.Map<Model.Igra>(entity); 
            
            //if (!string.IsNullOrWhiteSpace(request.Password))
            //{
            //    if (request.Password != request.PasswordPotvrda)
            //    {
            //        throw new Exception("Passwordi se ne slažu");
            //    }

            //    entity.LozinkaSalt = GenerateSalt();
            //    entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Password);
            //}
        }
    }
}
