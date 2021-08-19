using AutoMapper;
using GamingHub2.Database;
using GamingHub2.Model.Requests;
using GamingHub2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamingHub2.Helpers;

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
            CreateMap<Database.IgraKonzola, Model.IgraKonzolaNoRelations>();
            CreateMap<Database.IgraZanr, Model.IgraZanr>();
            CreateMap<Database.Korisnik, Model.Korisnici>();

            CreateMap<KorisniciUpsertRequest, Database.Korisnik>().ReverseMap();
            CreateMap<Database.KorisniciUloge, Model.KorisniciUloge>().ReverseMap();
            CreateMap<Database.Uloge, Model.Uloge>().ReverseMap();
            CreateMap<UlogaInsertRequest, Database.Uloge>();
            CreateMap<Database.Recenzija, Model.Recenzija>().ReverseMap();
            CreateMap<RecenzijaUpsertRequest, Database.Recenzija>();
            CreateMap<Database.Proizvod, Model.Proizvod>().ReverseMap();
            CreateMap<ProizvodInsertRequest, Database.Proizvod>();
            CreateMap<ProizvodUpdateRequest, Database.Proizvod>();

            CreateMap<Database.Korisnik, KorisniciUpdateProfileRequest>().ReverseMap();
            CreateMap<Database.Korisnik, KorisniciRegistracijaRequest>().ReverseMap();
            CreateMap<Database.Narudzba, Model.Narudzba>().ReverseMap();
            CreateMap<NarudzbaInsertRequest, Database.Narudzba>();
            CreateMap<NarudzbaUpdateRequest, Database.Narudzba>();
            CreateMap<Database.NarudzbaStavka, Model.NarudzbaStavka>().ReverseMap();
            CreateMap<NarudzbaStavkaInsertRequest, Database.NarudzbaStavka>();
            CreateMap<Database.Ocjena, Model.Ocjena>().ReverseMap();
            CreateMap<OcjenaUpsertRequest, Database.Ocjena>();

            CreateMap<Database.Kupac, Model.Kupac>().ReverseMap();
            CreateMap<KupacUpsertRequest, Database.Kupac>();
        }
    }
}
