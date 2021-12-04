using AutoMapper;
using GamingHub2.Model;
using GamingHub2.Model.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingHub2.Services
{
    public class IgraZanrService : IIgraZanrService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public IgraZanrService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IgraZanrPrikazVM GetIgraZanr(int IgraID)
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

        public IgraZanrDodajVM Dodaj(int IgraID)
        {
            var igreizanrovi = _context.IgraZanr;
            IgraZanrDodajVM m = new IgraZanrDodajVM();
            m.IgraID = IgraID;
            m.Zarnovi = _context.Zanr.Where(z => !igreizanrovi.Any(iz => iz.ZanrID == z.ID && iz.IgraID == IgraID))
                .Select(z => new SelectListItem
                {
                    Value = z.ID.ToString(),
                    Text = z.Naziv
                }).ToList();

            return m;
        }
        //public IActionResult Snimi(IgraZanrDodajVM i)
        //{
        //    IgraZanr igraZarn = new IgraZanr
        //    {
        //        IgraID = i.IgraID,
        //        ZanrID = i.ZanrID
        //    };
        //    _context.Add(igraZarn);

        //    _context.SaveChanges();
        //    //return Redirect("/Igra/Detalji?IgraID=" + igraZarn.IgraID);
        //}

        //public IActionResult Obrisi(int IgraZarnID)
        //{
        //    IgraZarn igraZarn = db.IgraZarn.Find(IgraZarnID);
        //    db.Remove(igraZarn);
        //    db.SaveChanges();

        //    return Redirect("/Igra/Detalji?IgraID=" + igraZarn.IgraID);
        //}

    }
}
