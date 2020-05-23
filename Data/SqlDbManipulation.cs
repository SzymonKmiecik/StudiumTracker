using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using StudiumTracker.Models;

namespace StudiumTracker.Data
{
    public class SqlDbManipulation<T> : IDbManipulation<T>
            where T : class, IModelData
    {
        private readonly ApplicationDbContext _context;

        public SqlDbManipulation(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().FirstOrDefault(p => p.Id == id);
        }

        public void Create(T record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            _context.Set<T>().Add(record);
        }

        public void Update(T record)
        {
            //nothing
        }

        public void Delete(T record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));

            _context.Set<T>().Remove(record);
        }
    }
}
