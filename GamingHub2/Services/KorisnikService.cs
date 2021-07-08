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
        public Model.Korisnici TrenutniKorisnik = null;

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

        public Model.Korisnici MojProfil()
        {
            var entity = _context.Korisnik.Include("KorisniciUloge").Where(x => x.KorisnikId == TrenutniKorisnik.KorisnikId).FirstOrDefault();
            return _mapper.Map<Model.Korisnici>(entity);
        }

        public Model.Korisnici Insert(KorisniciUpsertRequest request)
        {
            var entity = _mapper.Map<Database.Korisnik>(request);

            if (request.Password != request.PasswordPotvrda)
            {
                throw new Exception("Passwordi se ne slažu");
            }

            Korisnik user = _context.Korisnik.FirstOrDefault(u => u.KorisnickoIme == request.KorisnickoIme);
            Korisnik emil = _context.Korisnik.FirstOrDefault(u => u.Email == request.Email);

            if (user != null)
                throw new UserException("Korisnicko ime vec postoji!");
                //ModelState.AddModelError("UserName", "Username Already Exist!");
            if (emil != null)
                throw new UserException("Email vec postoji!");
            
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
        public Model.Korisnici Registracija(KorisniciRegistracijaRequest request)
        {
            var entity = _mapper.Map<Database.Korisnik>(request);

            if (request.Password != request.PasswordPotvrda)
            {
                throw new Exception("Passwordi se ne slažu");
            }

            Korisnik user = _context.Korisnik.FirstOrDefault(u => u.KorisnickoIme == request.KorisnickoIme);
            Korisnik emil = _context.Korisnik.FirstOrDefault(u => u.Email == request.Email);

            if (user != null)
                throw new UserException("Korisnicko ime vec postoji!");
            if (emil != null)
                throw new UserException("Email vec postoji!");

            entity.LozinkaSalt = GenerateSalt();
            entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Password);

            _context.Korisnik.Add(entity);
            _context.SaveChanges();


            //foreach (var uloga in request.Uloge)
            //{
            //    Database.KorisniciUloge korisniciUloge = new Database.KorisniciUloge
            //    {
            //        KorisnikId = entity.KorisnikId,
            //        UlogaId = uloga,
            //        DatumIzmjene = DateTime.Now
            //    };
            //    _context.KorisniciUloge.Add(korisniciUloge);
            //}
                Database.KorisniciUloge korisniciUloge = new Database.KorisniciUloge
                {
                    KorisnikId = entity.KorisnikId,
                    UlogaId = 3, //Po defaultu dodaje ulogu Korisnik
                    DatumIzmjene = DateTime.Now
                };
                _context.KorisniciUloge.Add(korisniciUloge);

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

        public Model.Korisnici UpdateProfile(KorisniciUpdateProfileRequest request)
        {
            var entity = _context.Korisnik.Find(TrenutniKorisnik.KorisnikId);

            if(request.Slika == null || request.Slika.Length == 0)
            {
                request.Slika = entity.Slika;
            }

            _context.Korisnik.Attach(entity);
            _context.Korisnik.Update(entity);

            if (!string.IsNullOrWhiteSpace(request.Password))
            {
                if (request.Password != request.PasswordPotvrda)
                {
                    throw new UserException("Passwordi se ne slažu");
                }

                entity.LozinkaSalt = GenerateSalt();
                entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Password);
            }

            _context.SaveChanges();

            _mapper.Map(request, entity);

            return _mapper.Map<Model.Korisnici>(entity);
        }

        public Korisnici GetTrenutniKorisnik()
        {
            return TrenutniKorisnik;
        }

        public void SetTrenutniKorisnik(Korisnici korisnik)
        {
            TrenutniKorisnik = korisnik;
        }
    }

}
