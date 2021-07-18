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
    public class RepositoryTipSmestaja : IRepositoryTipSmestaja
    {
        private TuristickaOrgContext context;

        public RepositoryTipSmestaja(TuristickaOrgContext context)
        {
            this.context = context;
        }
        public bool Add(TipSmestaja entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TipSmestaja s)
        {
            throw new NotImplementedException();
        }

        public Task<TipSmestaja> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TipSmestaja>> GetAll()
        {
            return await context.TipoviSmestaja.ToListAsync();
            
        }

        public  Task<TipSmestaja> Getlast()
        {
            throw new NotImplementedException();
        }

        public void Update(TipSmestaja entity)
        {
            throw new NotImplementedException();
        }
    }
}
