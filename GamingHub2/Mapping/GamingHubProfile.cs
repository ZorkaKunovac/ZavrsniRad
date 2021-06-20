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

            // CreateMap<IgraUpsertRequest, Database.Igra>();
            CreateMap<Database.Proizvod, Model.Proizvod>(); //ReverseMap?
            CreateMap<Database.Korisnik, Model.Korisnik>();
            CreateMap<KorisnikInsertRequest, Database.Korisnik>().ReverseMap();
            CreateMap<KorisnikUpdateRequest, Database.Korisnik>();
            CreateMap<Database.KorisnikUloga, Model.KorisnikUloga>();

            CreateMap<Database.Uloga, Model.Uloga>();
            CreateMap<UlogaInsertRequest, Database.Uloga>();

            //CreateMap<Database.Korisnik,KorisnikUpdateRequest>(); //reversemap? V3 39:30

        }
    }
}
