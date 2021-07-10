using AutoMapper;
using Microsoft.EntityFrameworkCore;
using GamingHub2.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingHub2.Services
{
    public class RecommenderService : IRecommenderService
    {

        Dictionary<int, List<Model.Ocjena>> proizvodi = new Dictionary<int, List<Model.Ocjena>>();
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public RecommenderService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Model.Proizvod> GetSlicneProizvode(int ProizvodID)
        {
            UcitajProizvode(ProizvodID);


            List<Model.Ocjena> ocjenePosmatranogProizvoda = new List<Model.Ocjena>();
            List<Ocjena> ocjeneizbaze = _context.Ocjena.Where(x => x.ProizvodId == ProizvodID).OrderBy(y => y.KupacId).ToList();
            _mapper.Map(ocjeneizbaze, ocjenePosmatranogProizvoda);



            List<Model.Ocjena> zajednickeOcjene1 = new List<Model.Ocjena>();
            List<Model.Ocjena> zajednickeOcjene2 = new List<Model.Ocjena>();
            List<Model.Proizvod> preporuceniProizvodi = new List<Model.Proizvod>();

            foreach (var item in proizvodi)
            {
                foreach (Model.Ocjena o in ocjenePosmatranogProizvoda)
                {
                    if (item.Value.Where(x => x.KupacId == o.KupacId).Count() > 0)
                    {
                        zajednickeOcjene1.Add(o);
                        zajednickeOcjene2.Add(item.Value.Where(x => x.KupacId == o.KupacId).First());
                    }
                }

                double slicnosti = 0;
                slicnosti = GetSlicnost(zajednickeOcjene1, zajednickeOcjene2);


                if (slicnosti > 0.99)
                {
                    Database.Proizvod element1 = _context.Proizvod.Include(y => y.IgraKonzola.Igra.IgraZanr).Where(x => x.ID == item.Key).FirstOrDefault();
                    Model.Proizvod element2 = new Model.Proizvod();

                    _mapper.Map(element1, element2);

                    element2.ProsjecnaOcjena = _context.Ocjena.Where(x => x.ProizvodId == element2.ID).Average(x => (decimal?)x.OcjenaProizvoda) ?? 0m;
                    element2.Slika = _context.Igra.Where(x => x.ID == element2.IgraKonzola.IgraID).Select(x => x.SlikaLink).FirstOrDefault();
                    preporuceniProizvodi.Add(element2);

                }

                zajednickeOcjene1.Clear();
                zajednickeOcjene2.Clear();
            }

            return preporuceniProizvodi;
        }

        private double GetSlicnost(List<Model.Ocjena> zajednickeOcjene1, List<Model.Ocjena> zajednickeOcjene2)
        {
            if (zajednickeOcjene1.Count != zajednickeOcjene2.Count)
                return 0;

            double brojnik = 0, nazivnik1 = 0, nazivnik2 = 0;

            for (int i = 0; i < zajednickeOcjene1.Count; i++)
            {
                brojnik += zajednickeOcjene1[i].OcjenaProizvoda * zajednickeOcjene2[i].OcjenaProizvoda;
                nazivnik1 += zajednickeOcjene1[i].OcjenaProizvoda * zajednickeOcjene1[i].OcjenaProizvoda;
                nazivnik2 += zajednickeOcjene2[i].OcjenaProizvoda * zajednickeOcjene2[i].OcjenaProizvoda;

            }
            nazivnik1 = Math.Sqrt(nazivnik1);
            nazivnik2 = Math.Sqrt(nazivnik2);
            double nazivnik = nazivnik1 * nazivnik2;
            if (nazivnik == 0)
                return 0;
            return brojnik / nazivnik;
        }

        private void UcitajProizvode(int ProizvodID)
        {
            List<Database.Proizvod> aktivniProizvodi = _context.Proizvod.Include(y => y.IgraKonzola.Igra.IgraZanr).Where(x => x.ID != ProizvodID).ToList();

            Database.Proizvod posmatraniartikal = _context.Proizvod.Where(x => x.ID == ProizvodID).Include(x => x.IgraKonzola.Igra.IgraZanr).SingleOrDefault();
            if (posmatraniartikal == null)
                return;

            List<Model.Proizvod> novalista = new List<Model.Proizvod>();
            _mapper.Map(aktivniProizvodi, novalista);



            List<Model.Proizvod> listakonacna = new List<Model.Proizvod>();
            foreach (var item in novalista)
            {
                if (item.IgraKonzola.KonzolaID == posmatraniartikal.IgraKonzola.KonzolaID && item.IgraKonzola.Igra.IgraZanr.Any(x => posmatraniartikal.IgraKonzola.Igra.IgraZanr.Any(y => y.ZanrID == x.ZanrID)))
                {
                    listakonacna.Add(item);
                }
            }


            foreach (Model.Proizvod p in listakonacna)
            {
                List<Database.Ocjena> novalistaocjena = _context.Ocjena.Where(x => x.ProizvodId == p.ID).ToList();
                List<Model.Ocjena> ocjene = new List<Model.Ocjena>();
                foreach (var item2 in novalistaocjena)
                {

                    Model.Ocjena novaocjena = new Model.Ocjena();
                    novaocjena.Datum = item2.Datum;
                    novaocjena.OcjenaProizvoda = item2.OcjenaProizvoda;
                    novaocjena.OcjenaId = item2.OcjenaId;
                    novaocjena.ProizvodId = item2.ProizvodId;
                    novaocjena.KupacId = item2.KupacId;


                    ocjene.Add(novaocjena);
                }

                if (ocjene.Count > 0)
                    proizvodi.Add(p.ID, ocjene);

            }
        }


    }
}
