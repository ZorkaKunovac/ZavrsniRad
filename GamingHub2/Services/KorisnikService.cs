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
using Microsoft.AspNetCore.Authorization;

namespace GamingHub2.Services
{

    public class KorisniciService : IKorisnikService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public KorisniciService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        //-----------------------------------------------------------------------------------
        public Model.Korisnici Authenticiraj(string username, string pass)
        {
            var entity = _context.Korisnik.Include("KorisniciUloge.Uloga").FirstOrDefault(x => x.KorisnickoIme == username);

            //if (user != null)
            //{
            //    var newHash = GenerateHash(user.LozinkaSalt, pass);

            //    if (newHash == user.LozinkaHash)
            //    {
            //        return _mapper.Map<Model.Korisnici>(user);
            //    }
            //}
            //return null;

            if (entity == null)
            {
                throw new UserException("Pogrešan username ili password");
            }

            var hash = GenerateHash(entity.LozinkaSalt, pass);

            if (hash != entity.LozinkaHash)
            {
                throw new UserException("Pogrešan username ili password");
            }

            return _mapper.Map<Model.Korisnici>(entity);
        }
        //-----------------------------------------------------------------------------------
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
        //-----------------------------------------------------------------------------------
        public List<Model.Korisnici> Get(KorisnikSearchRequest request)
        {
            var query = _context.Korisnik.Include("KorisniciUloge.Uloga").AsQueryable();

            if (!string.IsNullOrWhiteSpace(request?.Ime))
            {
                query = query.Where(x => x.Ime.StartsWith(request.Ime));
            }

            if (!string.IsNullOrWhiteSpace(request?.Prezime))
            {
                query = query.Where(x => x.Prezime.StartsWith(request.Prezime));
            }

            if (!string.IsNullOrWhiteSpace(request?.KorisnickoIme))
            {
                query = query.Where(x => x.KorisnickoIme.StartsWith(request.KorisnickoIme));
            }

            var list = query.ToList();

            return _mapper.Map<List<Model.Korisnici>>(list);
        }

        public Model.Korisnici GetById(int id)
        {
            var entity = _context.Korisnik.Include("KorisniciUloge").Where(x => x.KorisnikId == id).FirstOrDefault();
            return _mapper.Map<Model.Korisnici>(entity);
        }

        public Model.Korisnici Insert(KorisniciUpsertRequest request)
        {
            var entity = _mapper.Map<Database.Korisnik>(request);

            if (request.Password != request.PasswordPotvrda)
            {
                throw new Exception("Passwordi se ne slažu");
            }

            entity.LozinkaSalt = GenerateSalt();
            entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Password);

            _context.Korisnik.Add(entity);
            _context.SaveChanges();

            foreach (var uloga in request.Uloge)
            {
                Database.KorisniciUloge korisniciUloge = new Database.KorisniciUloge
                {
                    KorisnikId = entity.KorisnikId,
                    UlogaId = uloga,
                    DatumIzmjene = DateTime.Now
                };
                _context.KorisniciUloge.Add(korisniciUloge);
            }
            _context.SaveChanges();

            return _mapper.Map<Model.Korisnici>(entity);
        }
        public Model.Korisnici Update(int id, KorisniciUpsertRequest request)
        {
            var entity = _context.Korisnik.Find(id);
            _context.Korisnik.Attach(entity);
            _context.Korisnik.Update(entity);
            //------------------------------------------
            var korisnickeUloge = _context.KorisniciUloge.Where(x => x.KorisnikId == id).ToList();

            foreach (var item in korisnickeUloge)
            {
                _context.KorisniciUloge.Remove(item);
            }
            _context.SaveChanges();


            foreach (var uloga in request.Uloge)
            {
                Database.KorisniciUloge korisniciUloge = new Database.KorisniciUloge
                {
                    KorisnikId = entity.KorisnikId,
                    UlogaId = uloga,
                    DatumIzmjene = DateTime.Now
                };
                _context.KorisniciUloge.Add(korisniciUloge);
            }
            _context.SaveChanges();
            //------------------------------------------
            if (!string.IsNullOrWhiteSpace(request.Password))
            {
                if (request.Password != request.PasswordPotvrda)
                {
                    throw new Exception("Passwordi se ne slažu");
                }

                entity.LozinkaSalt = GenerateSalt();
                entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Password);
            }

            _mapper.Map(request, entity);

            _context.SaveChanges();

            return _mapper.Map<Model.Korisnici>(entity);
        }
    }

    //public class KorisnikService : BaseCRUDService<Model.Korisnik, Database.Korisnik, KorisnikSearchRequest, KorisnikInsertRequest, KorisnikUpdateRequest>, IKorisnikService
    //{
    //    public KorisnikService(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
    //    {
    //    }


    //    public override IEnumerable<Model.Korisnik> Get(KorisnikSearchRequest search = null)
    //    {
    //        var entity = Context.Set<Database.Korisnik>().AsQueryable();

    //        if (!string.IsNullOrWhiteSpace(search?.Ime))
    //        {
    //            entity = entity.Where(x => x.Ime.StartsWith(search.Ime));
    //        }

    //        if (search?.IsUlogeLoadingEnabled == true)
    //        {
    //            entity = entity.Include(x => x.KorisnikUloga);
    //        }
    //        var list = entity.ToList();

    //        return _mapper.Map<List<Model.Korisnik>>(list);
    //    }



    //    public override Model.Korisnik Insert(KorisnikInsertRequest request)
    //    {
    //        var entity = _mapper.Map<Database.Korisnik>(request);
    //        Context.Add(entity);
    //        if (request.Password != request.PasswordPotvrda)
    //        {
    //            //throw new NotImplementedException();
    //            throw new UserException("Lozinka nije ispravna");
    //        }

    //        entity.LozinkaSalt = GenerateSalt();
    //        entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Password);

    //        Context.SaveChanges();

    //        foreach (var uloga in request.Uloge)
    //        {
    //            Database.KorisniciUloge korisniciUloge = new Database.KorisniciUloge();
    //            korisniciUloge.KorisnikId = entity.Id;
    //            korisniciUloge.UlogaId = uloga;
    //            korisniciUloge.DatumIzmjene = DateTime.Now;

    //            Context.KorisnikUloga.Add(korisniciUloge);
    //        }
    //        Context.SaveChanges();

    //        return _mapper.Map<Model.Korisnik>(entity);
    //    }


    //    public override Model.Korisnik Update(int id, KorisnikUpdateRequest request)
    //    {
    //        //var set = Context.Set<Database.Korisnik>();
    //        //var entity = set.Find(id);

    //        var entity = Context.Korisnik.Find(id);

    //        Context.Korisnik.Attach(entity);
    //        Context.Korisnik.Update(entity);

    //        //var listKorisnikUloga = Context.KorisnikUloga.Where(x => x.KorisnikId == id).ToList();

    //        //foreach (var item in listKorisnikUloga)
    //        //{
    //        //    Context.KorisnikUloga.Remove(item);
    //        //}
    //        //Context.SaveChanges();

    //        //foreach (var uloga in request.Uloge)
    //        //{
    //        //    if (uloga != 0)
    //        //    {
    //        //        Database.KorisnikUloga korisnikUloga = new Database.KorisnikUloga
    //        //        {
    //        //            KorisnikId=entity.Id,
    //        //            UlogaId=uloga,
    //        //            DatumIzmjene = DateTime.Now
    //        //        };
    //        //        Context.KorisnikUloga.Add(korisnikUloga);
    //        //    }
    //        //}
    //        //Context.SaveChanges();


    //        _mapper.Map(request, entity);
    //        //if (request.Password != request.PasswordPotvrda)
    //        //{
    //        //    throw new UserException("Passwordi se ne slažu");
    //        //}

    //        Context.SaveChanges();

    //        return _mapper.Map<Model.Korisnik>(entity);
    //    }
    //}
}
