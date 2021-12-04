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

    }
}
