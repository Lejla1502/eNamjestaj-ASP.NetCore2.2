using eNamjestaj.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace eNamjestaj.Data
{
    public class MojContext : DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.UseSqlServer("Server=app.fit.ba,1433;Database=p1738_eNamjestaj;Trusted_Connection=false;MultipleActiveResultSets=true;User ID=p1738;Password=V_93xz8z");
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost;Database=p1738_eNamjestaj;Trusted_Connection=true;MultipleActiveResultSets=true;User ID=Aa;Password=Aa");
        }

        public MojContext(DbContextOptions<MojContext> options)
           : base(options)
        {
        }

        public MojContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
               .Entity<Dostavljac>()
               .HasOne(x => x.Korisnik)
               .WithMany()
               .HasForeignKey(x => x.KorisnikId);

            //modelBuilder
            //  .Entity<Zaposlenik>()
            //  .HasOne(x => x.Korisnik)
            //  .WithMany()
            //  .HasForeignKey(x => x.KorisnikId);

            modelBuilder
               .Entity<Kupac>()
               .HasOne(x => x.Korisnik)
               .WithMany()
               .HasForeignKey(x => x.KorisnikId);

            modelBuilder.Entity<ProizvodBoja>().HasKey(pb => new { pb.ProizvodId, pb.BojaId });

       

            modelBuilder.Entity<Dostavljac>()
            .HasIndex(b => b.Email).IsUnique();

            modelBuilder.Entity<Korisnik>()
            .HasIndex(b => b.KorisnickoIme).IsUnique();

            

            modelBuilder.Entity<Kupac>()
            .HasIndex(b => b.Email).IsUnique();

            modelBuilder.Entity<Proizvod>()
                .HasIndex(b => b.Sifra).IsUnique();


            modelBuilder.Entity<IzlazStavka>()
                .HasOne(pt => pt.Proizvod)
                .WithMany()
                .HasForeignKey(pt => pt.ProizvodId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UlazStavke>()
               .HasOne(pt => pt.Ulaz)
               .WithMany()
               .HasForeignKey(pt => pt.UlazId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Narudzba>()
                .HasOne(a => a.Izlaz)
                .WithOne(b => b.Narudzba)
                .HasForeignKey<Izlaz>(b => b.NarudzbaId);

            modelBuilder.Entity<NarudzbaStavka>()
               .HasOne(p => p.Proizvod)
               .WithMany()
               .HasForeignKey(p => p.ProizvodId)
               .OnDelete(DeleteBehavior.Restrict);


        }

        public virtual DbSet<Dostavljac> Dostavljac { get; set; }
        public virtual DbSet<Izlaz> Izlaz { get; set; }
        public virtual DbSet<IzlazStavka> IzlaziStavka { get; set; }
        public virtual DbSet<Korisnik> Korisnik { get; set; }
        public virtual DbSet<Uloga> Uloga { get; set; }
        public virtual DbSet<Kupac> Kupac { get; set; }
        public virtual DbSet<NarudzbaStavka> NarudzbaStavka { get; set; }
        public virtual DbSet<Narudzba> Narudzba { get; set; }
        public virtual DbSet<Proizvod> Proizvod { get; set; }
        public virtual DbSet<Skladiste> Skladiste { get; set; }
        public virtual DbSet<ProizvodSkladiste> ProizvodSkladiste { get; set; }
        public virtual DbSet<Ulaz> Ulaz { get; set; }
        public virtual DbSet<UlazStavke> UlazStavke { get; set; }
        public virtual DbSet<VrstaProizvoda> VrstaProizvoda { get; set; }
        public virtual DbSet<AkcijskiKatalog> AkcijskiKatalog { get; set; }
        public virtual DbSet<Boja> Boja { get; set; }
        public virtual DbSet<Dostava> Dostava { get; set; }
        public virtual DbSet<Drzava> Drzava { get; set; }
        public virtual DbSet<Kanton> Kanton { get; set; }
        public virtual DbSet<KatalogStavka> KatalogStavka { get; set; }
        public virtual DbSet<Opstina> Opstina { get; set; }
        public virtual DbSet<RadniNalog> RadniNalog { get; set; }
        public virtual DbSet<Log> Log { get; set; }
        public virtual DbSet<ProizvodBoja> ProizvodBoja { get; set; }
        public virtual DbSet<Komentar> Komentar { get; set; }
        public virtual DbSet<Ocjena> Ocjena { get; set; }

        //public DbSet<AutorizacijskiToken> AutorizacijskiToken { get; set; }

    }
}
