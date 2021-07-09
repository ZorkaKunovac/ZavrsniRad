using AutoMapper;
using GamingHub2.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingHub2.Services
{
    public class NarudzbaStavkaService : BaseCRUDService<Model.NarudzbaStavka, Database.NarudzbaStavka, object, NarudzbaStavkaInsertRequest, object>, INarudzbaStavkaService
    {
        public NarudzbaStavkaService(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
