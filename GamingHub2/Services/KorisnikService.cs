using AutoMapper;
using GamingHub2.Database;
using GamingHub2.Model;
using GamingHub2.Model.Requests;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using GamingHub2.Filters;
using Microsoft.AspNetCore.Mvc;

namespace GamingHub2.Services
{
    public class KorisnikService : BaseCRUDService<Model.Korisnik, Database.Korisnik, KorisnikSearchRequest, KorisnikInsertRequest, KorisnikUpdateRequest>, IKorisnikService
    {
        public KorisnikService(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IEnumerable<Model.Korisnik> Get(KorisnikSearchRequest search = null)
        {
            var entity = Context.Set<Database.Korisnik>().AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.Ime))
            {
                entity = entity.Where(x => x.Ime.StartsWith(search.Ime));
            }

            var list = entity.ToList();

            return _mapper.Map<List<Model.Korisnik>>(list);

            /*            
            if(request?.IsUlogeLoadingEnabled == true)
            {
                query = query.Include(x => x.KorisniciUloge);
            }

            */
        }

        [HttpGet("{id}")]
        public override Model.Korisnik GetById(int id)
        {
            var entity = Context.Korisnik.Include("KorisnikUloga.Uloga").Where(x => x.Id == id).FirstOrDefault();
            return _mapper.Map<Model.Korisnik>(entity);
        }

        public override Model.Korisnik Insert(KorisnikInsertRequest request)
        {
            var set = Context.Set<Database.Korisnik>();
            var entity = _mapper.Map<Database.Korisnik>(request);

            set.Add(entity);
            Context.SaveChanges();
            //if (request.Password != request.PasswordPotvrda)
            //{
            //    throw new UserException("Passwordi se ne slažu");
            //}

            entity.LozinkaHash = "test";
            entity.LozinkaSalt = "test";

            foreach (var uloga in request.Uloge)
            {
                Context.KorisnikUloga.Add(new Database.KorisnikUloga()
                {
                    KorisnikId = entity.Id,
                    UlogaId = uloga
                });
                //Database.KorisnikUloga korisnikUloga = new Database.KorisnikUloga
                //{
                //    KorisnikId = entity.Id,
                //    UlogaId = uloga,
                //    DatumIzmjene = DateTime.Now
                //};

                //Context.KorisnikUloga.Add(korisnikUloga);
            }
            Context.SaveChanges();
            return _mapper.Map<Model.Korisnik>(entity);
        }


        public override Model.Korisnik Update(int id, KorisnikUpdateRequest request)
        {
            //var set = Context.Set<Database.Korisnik>();
            //var entity = set.Find(id);

            var entity = Context.Korisnik.Find(id);

            Context.Korisnik.Attach(entity);
            Context.Korisnik.Update(entity);

            var listKorisnikUloga = Context.KorisnikUloga.Where(x => x.KorisnikId == id).ToList();

            foreach (var item in listKorisnikUloga)
            {
                Context.KorisnikUloga.Remove(item);
            }
            Context.SaveChanges();

            foreach (var uloga in request.Uloge)
            {
                if (uloga != 0)
                {
                    Database.KorisnikUloga korisnikUloga = new Database.KorisnikUloga
                    {
                        KorisnikId=entity.Id,
                        UlogaId=uloga,
                        DatumIzmjene = DateTime.Now
                    };
                    Context.KorisnikUloga.Add(korisnikUloga);
                }
            }
            Context.SaveChanges();


            _mapper.Map(request, entity);
            //if (request.Password != request.PasswordPotvrda)
            //{
            //    throw new UserException("Passwordi se ne slažu");
            //}

            Context.SaveChanges();

            return _mapper.Map<Model.Korisnik>(entity);
        }
    }
}
