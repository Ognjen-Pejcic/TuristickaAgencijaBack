using Data.Implementation.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementation.Repositories
{
    public class RepositoryPotvrda : IRepositoryPotvrda
    {
        private TuristickaOrgContext context;

        public RepositoryPotvrda(TuristickaOrgContext context)
        {
            this.context = context;
        }
        public bool Add(Potvrda entity)
        {
            entity.Zahtev = context.ZahteviZaRez.Find(entity.Zahtev.SifraZahteva);
            entity.Smestaj = context.Smestaji.Find(entity.Smestaj.SmestajId);
            entity.Destinacija = context.Destinacije.Find(entity.Destinacija.DestinacijaId);

            try
            {
                context.Potvrde.Add(entity);
                return true;
            }
            catch
            {
            return false;

            }
        }

        public void Delete(Potvrda s)
        {
            throw new NotImplementedException();
        }

        public async Task<Potvrda> FindById(int id)
        {
            return await context.Potvrde.Include(p=>p.Destinacija).Include(p=>p.Smestaj).Include(p=>p.Zahtev).Where(p=>p.BrojPotvrde == id).FirstOrDefaultAsync();
        }

        public Task<List<Potvrda>> GetAll()
        {
            throw new NotImplementedException();
        }


        public async Task<Potvrda> Getlast()
        {
                var data = await context.Potvrde.OrderByDescending(e => e.BrojPotvrde).ToListAsync();
            return data.Count() != 0 ? data.FirstOrDefault() : new Potvrda();

        }

        public async Task<List<Potvrda>> NadjiPoUsluzi(string usluga)
        {
            return await context.Potvrde.Include(p => p.Destinacija).Include(p => p.Smestaj).Include(p => p.Zahtev).Where(p => p.Usluga.Contains(usluga)).ToListAsync();
        }

        public void Update(Potvrda entity)
        {
            entity.Zahtev = context.ZahteviZaRez.Find(entity.Zahtev.SifraZahteva);
            entity.Destinacija = context.Destinacije.Find(entity.Destinacija.DestinacijaId);
            entity.Smestaj = context.Smestaji.Find(entity.Smestaj.SmestajId);

            context.Potvrde.Update(entity);

        }
    }
}
