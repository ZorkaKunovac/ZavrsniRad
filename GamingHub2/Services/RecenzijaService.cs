﻿using AutoMapper;
using GamingHub2.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingHub2.Services
{
    public class RecenzijaService : BaseCRUDService<Model.Recenzija, Database.Recenzija, RecenzijaSearchRequest, RecenzijaUpsertRequest, RecenzijaUpsertRequest>, IRecenzijaService
    {
        public RecenzijaService(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IEnumerable<Model.Recenzija> Get(RecenzijaSearchRequest search = null)
        {
            var entity = Context.Set<Database.Recenzija>().AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.Naslov))
            {
                entity = entity.Where(x => x.Naslov.StartsWith(search.Naslov));
            }

            if (search.KorisnikId != 0 && search.KorisnikId.HasValue)
            {
                entity = entity.Where(x => x.KorisnikId == search.KorisnikId);
            }
            if (search.KorisnikId != 0 && search.KorisnikId.HasValue)
            {
                entity = entity.Where(x => x.IgraId == search.IgraId);
            }

            var list = entity.OrderByDescending(x => x.DatumObjave).ToList();
            return _mapper.Map<List<Model.Recenzija>>(list);
        }
    }
}