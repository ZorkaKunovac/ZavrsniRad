using AutoMapper;
using GamingHub2.Database;
using GamingHub2.Model;
using GamingHub2.Model.Requests;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingHub2.Services
{
    public class ZanrService : BaseCRUDService<Model.Zanr,Database.Zanr, ZanrSearchRequest, ZanrUpsertRequest, ZanrUpsertRequest>, IZanrService
    {
        //NA MJESTO object SE STAVLJA SEARCHOBJECT AKO POSTOJI tipa ZanrSearchObject/ZanrSearchRequest
        //public ApplicationDbContext Context { get; set; }
        //protected readonly IMapper _mapper;

        public ZanrService(ApplicationDbContext context, IMapper mapper):base(context,mapper)
        {
        }

        //OVO SE DODA
        //public override IEnumerable<Model.Zanr> Get(ZanrSearchObject search = null)
        //{
        //    return base.Get(search);
        //}

        public override IEnumerable<Model.Zanr> Get(ZanrSearchRequest search = null)
        {
            var entity = Context.Set<Database.Zanr>().AsQueryable();

             if (!string.IsNullOrWhiteSpace(search?.Naziv))
            {
                entity = entity.Where(x => x.Naziv.StartsWith(search.Naziv));
            }

            var list = entity.ToList();

            return _mapper.Map<List<Model.Zanr>>(list);
        }

    }
}
