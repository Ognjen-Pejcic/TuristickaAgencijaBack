using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementation.Interfaces
{
    public interface IRepository<T> where T : class
    {
        bool Add(T entity);
        void Update(T entity);
        Task<List<T>> GetAll();
        Task<T> FindById(int id);
        Task<T> Getlast();

        void Delete(T s);
    }
}
