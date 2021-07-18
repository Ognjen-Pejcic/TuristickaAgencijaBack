using Data.Implementation.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementation.Repositories
{
    public class RepositoryZahtevKorisnika : IRepositoryZahtevKorisnika
    {
        private TuristickaOrgContext context;

        public RepositoryZahtevKorisnika(TuristickaOrgContext context)
        {
            this.context = context;
        }
        public bool Add(ZahtevKorisnika entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(ZahtevKorisnika s)
        {
            throw new NotImplementedException();
        }

        public Task<ZahtevKorisnika> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ZahtevKorisnika>> GetAll()
        {
            return await context.ZahteviKorisnika.ToListAsync();
        }

        public  Task<ZahtevKorisnika> Getlast()
        {
            return  context.ZahteviKorisnika.OrderByDescending(p => p.SifraZahteva).FirstAsync();
        }

        public void Update(ZahtevKorisnika entity)
        {
            throw new NotImplementedException();
        }
    }
}
