using System;
using System.Collections.Generic;
using System.Text;
using GamingHub2.Database;
//using Data.EntityModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
//using GamingHub.EntityModels;

namespace GamingHub2
{
    //    public class ApplicationDbContext : IdentityDbContext<Korisnik>

    public class ApplicationDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IgraKonzola>()
                .HasOne<Proizvod>(ik => ik.Proizvod)
                .WithOne(ad => ad.IgraKonzola)
                .HasForeignKey<Proizvod>(ad => ad.IgraKonzolaID);

            modelBuilder.Entity<Korisnik>()
               .HasOne<Kupac>(k => k.Kupac)
               .WithOne(ad => ad.Korisnik)
               .HasForeignKey<Kupac>(ad => ad.KorisnikId);

            //modelBuilder.Entity<Korisnik>()
            //   .HasIndex(k => new { k.Email, k.KorisnickoIme })
            //   .IsUnique(true);

            modelBuilder.Entity<Korisnik>()
               .HasIndex(u => u.Email)
               .IsUnique();

            modelBuilder.Entity<Korisnik>()
            .HasIndex(u => u.KorisnickoIme)
            .IsUnique();
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Zanr> Zanr { get; set; }
        public DbSet<Korisnik> Korisnik { get; set; }
        public DbSet<Konzola> Konzola { get; set; }
        public DbSet<Igra> Igra { get; set; }
        public DbSet<IgraKonzola> IgraKonzola { get; set; }
        public DbSet<IgraZanr> IgraZanr { get; set; }
        public DbSet<Recenzija> Recenzija { get; set; }
        public DbSet<Proizvod> Proizvod { get; set; }
        public DbSet<Kupac> Kupac { get; set; }
        //public DbSet<Narudzba> Narudzba { get; set; }
        //public DbSet<NarudzbaStavka> NarudzbaStavka { get; set; }
        ////public DbSet<OdabranaNarudžbaStavke> OdabranaNarudžbaStavke { get; set; }
        public DbSet<KreditnaKartica> KreditnaKartica { get; set; }
        public DbSet<TipKartice> TipKartice { get; set; }
        public DbSet<Drzava> Drzava { get; set; }
        public virtual DbSet<Uloge> Uloge { get; set; }
        public virtual DbSet<KorisniciUloge> KorisniciUloge { get; set; }


    }
}
