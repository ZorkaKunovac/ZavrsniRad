﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingHub2.Services
{
    public class BaseReadService<T,TDb,TSearch> :IReadService<T, TSearch> where T : class where TDb : class where TSearch : class
    {
        public ApplicationDbContext Context { get; set; }
        protected readonly IMapper _mapper;

        public BaseReadService(ApplicationDbContext context, IMapper mapper):base()
        {
            Context = context;
            _mapper = mapper;
        }

        public virtual IEnumerable<T> Get(TSearch search = null)
        {
            var entity = Context.Set<TDb>();
            var list = entity.ToList();
            return _mapper.Map<List<T>>(list);
        }

        public virtual T GetById(int id)
        {
            var set = Context.Set<TDb>();
            var entity = set.Find(id);
            return _mapper.Map<T>(entity);
        }

        //public IList<Model.Zanr> Get()
        //{
        //    return Context.Zanr.ToList().Select(x => _mapper.Map<Model.Zanr>(x)).ToList();
        //}

    }
}
