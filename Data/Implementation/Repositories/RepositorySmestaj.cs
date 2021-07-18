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
    public class RepositorySmestaj : IRepositorySmestaj
    {
        private TuristickaOrgContext context;

        public RepositorySmestaj(TuristickaOrgContext context)
        {
            this.context = context;
        }
        public bool Add(Smestaj entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Smestaj s)
        {
            throw new NotImplementedException();
        }

        public Task<Smestaj> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Smestaj>> GetAll()
        {
            var A = context.Smestaji.ToList(); 
            return await context.Smestaji.ToListAsync();
        }

        public Task<Smestaj> Getlast()
        {
            throw new NotImplementedException();
        }

        public void Update(Smestaj entity)
        {
            throw new NotImplementedException();
        }
    }
}
