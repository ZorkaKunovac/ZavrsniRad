using GamingHub2.Model;
using GamingHub2.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingHub2.Services
{
    public interface IKorisnikService
    {
        List<Model.Korisnici> Get(KorisnikSearchRequest request);
        Model.Korisnici GetById(int id);
        Model.Korisnici MojProfil();
        Model.Korisnici Insert(KorisniciUpsertRequest request);
        Model.Korisnici Update(int id, KorisniciUpsertRequest request);
        Model.Korisnici Authenticiraj(string username, string pass);

        Model.Korisnici GetTrenutniKorisnik();
        void SetTrenutniKorisnik(Model.Korisnici korisnik);
        Model.Korisnici UpdateProfile(KorisniciUpdateProfileRequest request);
    }
    //public interface IKorisnikService : ICRUDService<Model.Korisnik, KorisnikSearchRequest, KorisnikInsertRequest, KorisnikUpdateRequest>
    //{
    //    Korisnik Authenticiraj(string username, string password);
    //}
}
