using Data.Implementation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
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
        public IRepositorySmestaj Smestajj { get; set; }
        void Commit();
    }
}
