using AutoMapper;
using GamingHub2.Model;
using GamingHub2.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingHub2.Services
{
    public class NarudzbaService : BaseCRUDService<Model.Narudzba, Database.Narudzba, NarudzbaSearchRequest, NarudzbaInsertRequest, NarudzbaUpdateRequest>, INarudzbaService
    {
        private readonly IKorisnikService korisnikService;

        public NarudzbaService(ApplicationDbContext context, IMapper mapper, IKorisnikService korisnikService) : base(context, mapper)
        {
            this.korisnikService = korisnikService;
        }

        public override IEnumerable<Narudzba> Get(NarudzbaSearchRequest search = null)
        {
            var entity = Context.Set<Database.Narudzba>().AsQueryable();

            if (search?.NarudzbaID != null)
            {
                entity = entity.Where(x => x.NarudzbaId == search.NarudzbaID);
            }

            if (search?.Status != null)
            {
                entity = entity.Where(x => x.Status == search.Status);
            }

            Korisnici logiraniKorisnik = korisnikService.GetTrenutniKorisnik();
            bool isAdmin = logiraniKorisnik.KorisniciUloge.Any(x => x.Uloga.Naziv == "Administrator");
            bool isKorisnik = logiraniKorisnik.KorisniciUloge.Any(x => x.Uloga.Naziv == "Korisnik");

            if (isKorisnik && !isAdmin) // ukoliko nije admin
            {
                // filtriranje narudzbi, kako bi se prikazalo samo narudzbe logiranog korisnika
                entity = entity.Where(x => x.KorisnikID == logiraniKorisnik.KorisnikId);
            }


            var list = entity.ToList();

            List<Narudzba> mappedList = _mapper.Map<List<Model.Narudzba>>(list);

            foreach (var narudzba in mappedList)
            {
                narudzba.Iznos = IzracunajIznosNarudzbe(narudzba);
            }
            return mappedList;
        }

        private decimal IzracunajIznosNarudzbe(Narudzba narudzba)
        {
            return (decimal)Context.Set<Database.NarudzbaStavka>().Where(x => x.NarudzbaID == narudzba.NarudzbaId).Sum(x => x.Kolicina * x.Cijena * (1 - x.Popust / 100));
            //sum += item.Kolicina * item.Proizvod.ProdajnaCijena * (1 - item.Proizvod.Popust / 100);

        }

        public override Narudzba Insert(NarudzbaInsertRequest request)
        {
            var set = Context.Set<Database.Narudzba>();
            Database.Narudzba entity = _mapper.Map<Database.Narudzba>(request);


            // dodjela nove narudzbe trenutno logiranom korisnku
            entity.KorisnikID = korisnikService.GetTrenutniKorisnik().KorisnikId;

            set.Add(entity);
            Context.SaveChanges();
            return _mapper.Map<Model.Narudzba>(entity);
        }

        public override Narudzba GetById(int id)
        {
            var set = Context.Set<Database.Narudzba>();
            var entity = set.Find(id);
            var mappedEntity = _mapper.Map<Narudzba>(entity);
            mappedEntity.Iznos = IzracunajIznosNarudzbe(mappedEntity);

            return mappedEntity;
        }
    }
}
