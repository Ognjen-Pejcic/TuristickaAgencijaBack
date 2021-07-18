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
    public class RepositoryRadnik : IRepositoryRadnik
    {
        private TuristickaOrgContext context;

        public RepositoryRadnik(TuristickaOrgContext context)
        {
            this.context = context;
        }
        public bool Add(Radnik entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Radnik s)
        {
            throw new NotImplementedException();
        }

        public Task<Radnik> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Radnik>> GetAll()
        {
            return await context.Radnici.ToListAsync();
        }

        public Task<Radnik> Getlast()
        {
            throw new NotImplementedException();
        }

        public void Update(Radnik entity)
        {
            throw new NotImplementedException();
        }
    }
}
