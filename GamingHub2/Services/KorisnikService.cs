using AutoMapper;
using GamingHub2.Model;
using GamingHub2.Model.Requests;
using System.Collections.Generic;
using System.Linq;
using System;
using GamingHub2.Filters;

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
           
            if (!string.IsNullOrWhiteSpace(request?.Prezime))
            {
                query = query.Where(x => x.Prezime.StartsWith(request.Prezime));
            }

            if(request?.IsUlogeLoadingEnabled == true)
            {
                query = query.Include(x => x.KorisniciUloge);
            }

            */
        }

        public override Korisnik Insert(KorisnikInsertRequest request)
        {
            var set = Context.Set<Database.Korisnik>();
            var entity = _mapper.Map<Database.Korisnik>(request);
            //  try sve trebas stavljaty u try catch block
            //try
            //{
            if (request.Password != request.PasswordPotvrda)
            {
                throw new UserException("Passwordi se ne slažu");
            }
            //}
            //catch(UserException exception)
            //{

            //}
            entity.LozinkaHash = "test";
            entity.LozinkaSalt = "test";

            set.Add(entity);
            Context.SaveChanges();

            return _mapper.Map<Model.Korisnik>(entity);
        }


        public override Korisnik Update(int id, KorisnikUpdateRequest request)
        {
            var set = Context.Set<Database.Korisnik>();
            var entity = set.Find(id);

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
