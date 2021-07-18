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
    public class RepositoryKorisnik : IRepositoryKorisnik
    {
        private TuristickaOrgContext context;

        public RepositoryKorisnik(TuristickaOrgContext context)
        {
            this.context = context;
        }
        public bool Add(Korisnik entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Korisnik s)
        {
            throw new NotImplementedException();
        }

        public Task<Korisnik> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Korisnik>> GetAll()
        {
            return await context.Korisnici.ToListAsync();
        }
        public Task<Korisnik> Getlast()
        {
            throw new NotImplementedException();
        }

        public void Update(Korisnik entity)
        {
            throw new NotImplementedException();
        }
    }
}
