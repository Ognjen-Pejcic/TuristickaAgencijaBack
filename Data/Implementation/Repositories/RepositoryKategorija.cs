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
    public class RepositoryKategorija : IRepositoryKategorija
    {
        private TuristickaOrgContext context;

        public RepositoryKategorija(TuristickaOrgContext context)
        {
            this.context = context;
        }
        public bool Add(Kategorija entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Kategorija s)
        {
            throw new NotImplementedException();
        }

        public Task<Kategorija> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Kategorija>> GetAll()
        {
            return await context.Kategorije.ToListAsync();

        }
        public Task<Kategorija> Getlast()
        {
            throw new NotImplementedException();
        }

        public void Update(Kategorija entity)
        {
            throw new NotImplementedException();
        }
    }
}
