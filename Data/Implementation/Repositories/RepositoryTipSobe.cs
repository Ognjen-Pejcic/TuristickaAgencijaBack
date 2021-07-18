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
    public class RepositoryTipSobe : IRepositoryTipSobe
    {
        private TuristickaOrgContext context;

        public RepositoryTipSobe(TuristickaOrgContext context)
        {
            this.context = context;
        }
        public bool Add(TipSobe entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TipSobe s)
        {
            throw new NotImplementedException();
        }

        public Task<TipSobe> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TipSobe>> GetAll()
        {
            return await context.TipoviSobe.ToListAsync();
        }

        public Task<TipSobe> Getlast()
        {
            throw new NotImplementedException();
        }

        public void Update(TipSobe entity)
        {
            throw new NotImplementedException();
        }
    }
}
