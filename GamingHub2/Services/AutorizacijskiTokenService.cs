using AutoMapper;
using GamingHub2.Model;
using GamingHub2.Model.Requests;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingHub2.Services
{
    public class AutorizacijskiTokenService : BaseCRUDService<Model.AutorizacijskiToken, Database.AutorizacijskiToken, AutorizacijskiTokenSearchRequest, AutorizacijskiTokenInsertRequest, object>, IAutorizacijskiTokenService
    {
        public AutorizacijskiTokenService(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IEnumerable<AutorizacijskiToken> Get(AutorizacijskiTokenSearchRequest search)
        {
            var entity = Context.AutorizacijskiToken
                .Include("Korisnik.KorisniciUloge.Uloga")
                .Where(x => x.Vrijednost == search.Vrijednost)
                .ToList();

            return _mapper.Map<List<Model.AutorizacijskiToken>>(entity);
        }
    }
}
