using AutoMapper;
using GamingHub2.Database;
using GamingHub2.Model.Requests;
using GamingHub2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingHub2.Mapping
{
    public class GamingHubProfile:Profile
    {
        public GamingHubProfile()
        {
            CreateMap<Database.Zanr, Model.Zanr>().ReverseMap();
            CreateMap<ZanrUpsertRequest, Database.Zanr>();
            CreateMap<Database.Konzola, Model.Konzola>();
            CreateMap<KonzolaUpsertRequest, Database.Konzola>();
            CreateMap<Database.Igra, Model.Igra>();
            CreateMap<Database.Igra, IgraUpsertRequest>().ReverseMap();
            CreateMap<Database.IgraKonzola, Model.IgraKonzola>();
            CreateMap<Database.IgraZanr, Model.IgraZanr>();
            CreateMap<Database.Korisnik, Model.Korisnici>();

            //CreateMap<Database.Korisnici, Model.Korisnici>().ReverseMap();
            CreateMap<KorisniciUpsertRequest, Database.Korisnik>().ReverseMap();
            //CreateMap<Database.Kupci, Model.Kupci>().ReverseMap();
            CreateMap<Database.KorisniciUloge, Model.KorisniciUloge>().ReverseMap();
            CreateMap<Database.Uloge, Model.Uloge>().ReverseMap();
            CreateMap<UlogaInsertRequest, Database.Uloge>();
            CreateMap<Database.Recenzija, Model.Recenzija>().ReverseMap();
            CreateMap<RecenzijaUpsertRequest, Database.Recenzija>();
            CreateMap<Database.Proizvod, Model.Proizvod>().ReverseMap();
            CreateMap<ProizvodInsertRequest, Database.Proizvod>();
            CreateMap<ProizvodUpdateRequest, Database.Proizvod>();


           CreateMap<Database.Korisnik, KorisniciUpdateProfileRequest>().ReverseMap();

        }
    }
}
