using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using StudiumTracker.Models;

namespace StudiumTracker.Data
{
    public interface IDbManipulation<T>
        where T : class, IModelData
    {
        bool SaveChanges();

        IEnumerable<T> GetAll();
        T GetById(int id);
        void Create(T record);
        void Update(T record);
        void Delete(T record);
    }
}
