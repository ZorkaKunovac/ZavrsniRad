using AutoMapper;
using GamingHub2.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingHub2.Services
{
    public class IgraZanrService : IIgraZanrService2
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public IgraZanrService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IgraZanrPrikazVM GetIZ(int IgraID)
        {
            IgraZanrPrikazVM m = new IgraZanrPrikazVM();
            m.rows = _context.IgraZanr.Where(iz => iz.IgraID == IgraID)
             .Select(iz => new IgraZanrPrikazVM.Rows
             {
                 IgraZanrID = iz.ID,
                 Zanr = iz.Zanr.Naziv
             }).ToList();
            m.IgraID = IgraID;
            return m;
        }

        //private IActionResult View(IgraZanrPrikazVM m)
        //{
        //    throw new NotImplementedException();
        //}

        //public override IEnumerable<Model.IgraZanr> Get(object search = null)
        //{
        //    var entity = Context.Set<Database.IgraZanr>().AsQueryable();

        //    //if (search?.IncludeList?.Length > 0)
        //    //{
        //    //    foreach (var item in search.IncludeList)
        //    //    {
        //    //        entity = entity.Include(item);
        //    //    }
        //    //}

        //    // return _mapper.Map<List<Model.IgraKonzola>>(list);
        //    return Context.IgraZanr.Select(x => new Model.IgraZanr
        //    {
        //        ID = x.ID,
        //        DatumIzmjene = x.DatumIzmjene,
        //        IgraID = x.IgraID,
        //        ZanrID=x.ZanrID,
        //        Naziv = x.Igra.Naziv + " - " + x.Zanr.Naziv
        //    });
        //}

       

        //public List<Model.Korisnici> Get(KorisnikSearchRequest request)
        //{
        //    var query = _context.Korisnik.Include("KorisniciUloge.Uloga").AsQueryable();

        //    if (!string.IsNullOrWhiteSpace(request?.Ime))
        //    {
        //        query = query.Where(x => x.Ime.StartsWith(request.Ime));
        //    }

        //    if (!string.IsNullOrWhiteSpace(request?.Prezime))
        //    {
        //        query = query.Where(x => x.Prezime.StartsWith(request.Prezime));
        //    }

        //    if (!string.IsNullOrWhiteSpace(request?.KorisnickoIme))
        //    {
        //        query = query.Where(x => x.KorisnickoIme.StartsWith(request.KorisnickoIme));
        //    }

        //    var list = query.ToList();

        //    return _mapper.Map<List<Model.Korisnici>>(list);
        //}

    }
}
