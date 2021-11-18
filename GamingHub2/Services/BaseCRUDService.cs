using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingHub2.Services
{
    [Authorize]
    public class BaseCRUDService<T, TDb, TSearch, TInsert, TUpdate> : BaseReadService<T, TDb, TSearch>, ICRUDService<T, TSearch, TInsert, TUpdate> where T : class where TDb : class where TSearch : class where TInsert : class where TUpdate : class
    {
        public BaseCRUDService(ApplicationDbContext context, IMapper mapper) : base(context,mapper)
        {
        }

        public virtual T Insert(TInsert request)
        {
            var set = Context.Set<TDb>(); //TDb je neka klasa iz Baze npr Proizvodi
            TDb entity = _mapper.Map<TDb>(request);

            set.Add(entity);
            Context.SaveChanges();
            return _mapper.Map<T>(entity);
        }
        // set uzima _proizvodi iz baze a u entity se smjesta request koji smo poslali, zatim se u _proizvode(set) smjesta taj jedan objekat iz requesta
        // request je database objekat, sacuvamo promjene i korisniku vratimo proizvod u T obliku?
        // Zakljucak: set, entity i request su DB objekti a T je Model
        public virtual T Update(int id, TUpdate request)
        {
            var set = Context.Set<TDb>();
            var entity = set.Find(id);

            _mapper.Map(request, entity);

            Context.SaveChanges();

            return _mapper.Map<T>(entity);
        }

        public virtual T Delete(int id)
        {
            var set = Context.Set<TDb>();
            var entity = set.Find(id);

            if(entity != null)
            {
                set.Remove(entity);
                Context.SaveChanges();
                return _mapper.Map<T>(entity);
            }

            return null;
        }

    }
}
