using Data.Implementation.Interfaces;
using Data.Implementation.Repositories;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.UnitOfWork
{
    public class AgencijaUnitOfWork : IUnitOfWork, IDisposable
    {
        private TuristickaOrgContext context;
        public IRepositoryZahtevZaRezHotela ZahtevZaRez { get; set; }
        public IRepositoryHotel Hotel { get; set; }
        public IRepositoryTipSobe Soba { get; set; }
        public IRepositoryTipSmestaja Smestaj { get; set; }
        public IRepositoryKategorija Kategorija { get; set; }
        public IRepositoryKorisnik Korisnik { get; set; }
        public IRepositoryRadnik Radnici { get; set; }
        public IRepositoryZahtevKorisnika ZahteviKorisnika { get; set; }
        public IRepositoryDestinacija Destinacije { get; set; }
        public IRepositoryPotvrda Potvrde { get; set; }
        public IRepositorySmestaj Smestajj { get ; set ; }

        public AgencijaUnitOfWork(TuristickaOrgContext context)
        {
            this.context = context;
            ZahtevZaRez = new RepositoryZahtevZaRezervisanje(context);
            Hotel = new RepositoryHotel(context);
            Soba = new RepositoryTipSobe(context);
            Smestaj = new RepositoryTipSmestaja(context);
            Kategorija = new RepositoryKategorija(context);
            Korisnik = new RepositoryKorisnik(context);
            Radnici = new RepositoryRadnik(context);
            ZahteviKorisnika = new RepositoryZahtevKorisnika(context);
            Destinacije = new RepositoryDestinacija(context);
            Potvrde = new RepositoryPotvrda(context);
            Smestajj = new RepositorySmestaj(context);
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
