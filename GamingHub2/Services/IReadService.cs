using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingHub2.Services
{
    public interface IReadService<T, TSearch> where T:class where TSearch : class
    {
        //public IEnumerable<Model.Zanr> Get();
        //public Model.Zanr GetById(int id);

        IEnumerable<T> Get(TSearch search = null);
        public T GetById(int id);
    }
}
