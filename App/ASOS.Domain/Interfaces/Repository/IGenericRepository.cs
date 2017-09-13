using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASOS.Domain.Entities;

namespace ASOS.Domain.Interfaces.Repository
{
    public interface IGenericRepository<T>
    {
        void Add(T entity);
        T GetById(int id);
    }
}
