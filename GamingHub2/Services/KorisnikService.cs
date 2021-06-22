using AutoMapper;
using GamingHub2.Database;
using GamingHub2.Model;
using GamingHub2.Model.Requests;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using GamingHub2.Filters;
using Microsoft.AspNetCore.Mvc;
using GamingHub2.Filters;
using System.Security.Cryptography;
using System.Text;

namespace GamingHub2.Services
{
    public class KorisnikService : BaseCRUDService<Model.Korisnik, Database.Korisnik, KorisnikSearchRequest, KorisnikInsertRequest, KorisnikUpdateRequest>, IKorisnikService
    {
        public KorisnikService(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public static string GenerateSalt()
        {
            var buf = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buf);
            return Convert.ToBase64String(buf);
        }

        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }

        public override IEnumerable<Model.Korisnik> Get(KorisnikSearchRequest search = null)
        {
            var entity = Context.Set<Database.Korisnik>().AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.Ime))
            {
                entity = entity.Where(x => x.Ime.StartsWith(search.Ime));
            }

            if (search?.IsUlogeLoadingEnabled == true)
            {
                entity = entity.Include(x => x.KorisnikUloga);
            }


            var list = entity.ToList();

            return _mapper.Map<List<Model.Korisnik>>(list);


        }

        public override Model.Korisnik GetById(int id)
        {
            var entity = Context.Korisnik.Find(id);

            return _mapper.Map<Model.Korisnik>(entity);
        }

        //[HttpGet("{id}")]
        //public override Model.Korisnik GetById(int id)
        //{
        //    var entity = Context.Korisnik.Include(x=>x.KorisnikUloga).Where(x => x.Id == id).FirstOrDefault();
        //    //var entity = Context.Korisnik.Include("KorisnikUloga.Uloga").Where(x => x.Id == id).FirstOrDefault();
        //    return _mapper.Map<Model.Korisnik>(entity);
        //}

        public override Model.Korisnik Insert(KorisnikInsertRequest request)
        {
            //  var set = Context.Set<Database.Korisnik>();
            var entity = _mapper.Map<Database.Korisnik>(request);


            if (request.Password != request.PasswordPotvrda)
            {
                throw new UserException("Passwordi se ne slažu");
            }

            //entity.LozinkaHash = "test";
            //entity.LozinkaSalt = "test";
            entity.LozinkaSalt = GenerateSalt();
            entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Password);



            Context.Korisnik.Add(entity);
            Context.SaveChanges();
          



            //foreach (var uloga in request.Uloge)
            //{
            //    Context.KorisnikUloga.Add(new Database.KorisnikUloga()
            //    {
            //        KorisnikId = entity.Id,
            //        UlogaId = uloga
            //    });
            //    //Database.KorisnikUloga korisnikUloga = new Database.KorisnikUloga
            //    //{
            //    //    KorisnikId = entity.Id,
            //    //    UlogaId = uloga,
            //    //    DatumIzmjene = DateTime.Now
            //    //};

            //    //Context.KorisnikUloga.Add(korisnikUloga);
            //}
            //Context.SaveChanges();
            return _mapper.Map<Model.Korisnik>(entity);
        }


        public override Model.Korisnik Update(int id, KorisnikUpdateRequest request)
        {
            //var set = Context.Set<Database.Korisnik>();
            //var entity = set.Find(id);

            var entity = Context.Korisnik.Find(id);

            Context.Korisnik.Attach(entity);
            Context.Korisnik.Update(entity);

            //var listKorisnikUloga = Context.KorisnikUloga.Where(x => x.KorisnikId == id).ToList();

            //foreach (var item in listKorisnikUloga)
            //{
            //    Context.KorisnikUloga.Remove(item);
            //}
            //Context.SaveChanges();

            //foreach (var uloga in request.Uloge)
            //{
            //    if (uloga != 0)
            //    {
            //        Database.KorisnikUloga korisnikUloga = new Database.KorisnikUloga
            //        {
            //            KorisnikId=entity.Id,
            //            UlogaId=uloga,
            //            DatumIzmjene = DateTime.Now
            //        };
            //        Context.KorisnikUloga.Add(korisnikUloga);
            //    }
            //}
            //Context.SaveChanges();


            _mapper.Map(request, entity);
            if (request.Password != request.PasswordPotvrda)
            {
                throw new UserException("Passwordi se ne slažu");
            }

            Context.SaveChanges();

            return _mapper.Map<Model.Korisnik>(entity);
        }
    }
}
