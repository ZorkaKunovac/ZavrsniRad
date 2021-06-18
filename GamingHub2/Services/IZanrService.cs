using GamingHub2.Model;
using GamingHub2.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingHub2.Services
{
    public interface IZanrService:ICRUDService<Zanr,ZanrSearchRequest, ZanrUpsertRequest, ZanrUpsertRequest> //Zanr je model
    {


        //Dok nije bilo IReadService, bilo je ovako
        //public List<Model.Zanr> Get();
        //public Model.Zanr GetById(int id);
        //public Model.Zanr Insert(Zanr zanr);
        //public Model.Zanr Update(int id, Zanr zanr);
    }
}
