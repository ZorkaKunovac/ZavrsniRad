using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingHub2.Services
{
    public interface IRecommenderService
    {
        List<Model.Proizvod> GetSlicneProizvode(int ProizvodID);
    }
}
