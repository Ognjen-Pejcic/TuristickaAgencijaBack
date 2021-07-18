using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementation.Interfaces
{
    public interface IRepositoryPotvrda :IRepository<Potvrda>
    {
        public Task<List<Potvrda>> NadjiPoUsluzi(string usluga);
    }
}
