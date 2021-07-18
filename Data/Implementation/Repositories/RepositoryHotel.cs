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
    public class RepositoryHotel : IRepositoryHotel
    {
        private TuristickaOrgContext context;

        public RepositoryHotel(TuristickaOrgContext context)
        {
            this.context = context;
        }
        public bool Add(Hotel entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Hotel s)
        {
            throw new NotImplementedException();
        }

        public Task<Hotel> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Hotel>> GetAll()
        {
            return await context.Hoteli.ToListAsync();
        }

        public Task<Hotel> Getlast()
        {
            throw new NotImplementedException();
        }

        public void Update(Hotel entity)
        {
            throw new NotImplementedException();
        }
    }
}
