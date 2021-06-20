using AutoMapper;
using GamingHub2.Model;
using GamingHub2.Model.Requests;
using System.Collections.Generic;
using System.Linq;
using System;
using GamingHub2.Filters;
using Microsoft.EntityFrameworkCore;


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

        public override Model.Korisnik GetById(int id)
        {
            var entity = Context.Korisnik.Include("KorisnikUloga.Uloga").Where(x => x.Id == id).FirstOrDefault();
            return _mapper.Map<Model.Korisnik>(entity);
        }

        public override Korisnik Insert(KorisnikInsertRequest request)
        {
            var set = Context.Set<Database.Korisnik>();
            var entity = _mapper.Map<Database.Korisnik>(request);

            if (request.Password != request.PasswordPotvrda)
            {
                throw new UserException("Passwordi se ne slažu");
            }
      
            entity.LozinkaHash = "test";
            entity.LozinkaSalt = "test";

            set.Add(entity);
            Context.SaveChanges();
            foreach (var uloga in request.Uloge)
            {
                Database.KorisnikUloga korisnikUloga = new Database.KorisnikUloga
                {
                    KorisnikId = entity.Id,
                    UlogaId = uloga,
                    DatumIzmjene = DateTime.Now
                };

                Context.KorisnikUloga.Add(korisnikUloga);
            }
            Context.SaveChanges();
            return _mapper.Map<Model.Korisnik>(entity);
        }


        public override Korisnik Update(int id, KorisnikUpdateRequest request)
        {
            var set = Context.Set<Database.Korisnik>();
            var entity = set.Find(id);

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
            if (request.Password != request.PasswordPotvrda)
            {
                throw new UserException("Passwordi se ne slažu");
            }

            Context.SaveChanges();

            return _mapper.Map<Model.Korisnik>(entity);
        }
    }
}
