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
    public class RepositoryDestinacija : IRepositoryDestinacija
    {
        private TuristickaOrgContext context;

        public RepositoryDestinacija(TuristickaOrgContext context)
        {
            this.context = context;
        }
        public bool Add(Destinacija entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Destinacija s)
        {
            throw new NotImplementedException();
        }

        public Task<Destinacija> FindById(int id)
        {
            throw new NotImplementedException();
        }

       
        public async Task<List<Destinacija>> GetAll()
        {
            return await context.Destinacije.ToListAsync();
        }
        public Task<Destinacija> Getlast()
        {
            throw new NotImplementedException();
        }

        public void Update(Destinacija entity)
        {
            throw new NotImplementedException();
        }
    }
}
