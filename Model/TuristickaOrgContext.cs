using Microsoft.EntityFrameworkCore;
using Model.Domain;

namespace Model
{
    public class TuristickaOrgContext : DbContext
    {
        public DbSet<Hotel> Hoteli { get; set; }
        public DbSet<Kategorija> Kategorije { get; set; }
        public DbSet<Korisnik> Korisnici { get; set; }
        public DbSet<Radnik> Radnici { get; set; }
        public DbSet<StavkaRezervacijeHotela> StavkeRHotela { get; set; }
        public DbSet<TipSmestaja> TipoviSmestaja { get; set; }
        public DbSet<TipSobe> TipoviSobe { get; set; }
        public DbSet<ZahtevKorisnika> ZahteviKorisnika { get; set; }
        public DbSet<ZahtevZaRezervisanjeHotela> ZahteviZaRez { get; set; }
        public DbSet<Destinacija> Destinacije { get; set; }
        public DbSet<Smestaj> Smestaji { get; set; }
        public DbSet<Potvrda> Potvrde{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TuristickaAgencija3;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Korisnik>().HasKey(e => e.JMBG);
            modelBuilder.Entity<ZahtevKorisnika>().HasKey(e => e.SifraZahteva);
            modelBuilder.Entity<ZahtevZaRezervisanjeHotela>().HasKey(e => e.SifraZahteva);

            modelBuilder.Entity<ZahtevZaRezervisanjeHotela>().HasMany(e => e.StavkaRezervacijeHotela).WithOne(e => e.ZahtevZaRezervisanjeHotela);
            modelBuilder.Entity<StavkaRezervacijeHotela>().HasKey(e => new {e.StavkaRezervacijeHotelaId, e.ZahtevZaRezervisanjeHotelaId });

            modelBuilder.Entity<Potvrda>().HasKey(e => e.BrojPotvrde);

            modelBuilder.Entity<ZahtevZaRezervisanjeHotela>().HasOne(e => e.Potvrda).WithOne(e => e.Zahtev);
 
        }
    }

}
