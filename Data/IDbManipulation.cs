using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudiumTracker.Data
{
    public interface IDbManipulation<T>
        where T : class
    {
        bool SaveChanges();

        IEnumerable<T> GetAll();
        T GetById(int id);
        void Create(T record);
        void Update(T record);
        void Delete(T record);
    }
}
