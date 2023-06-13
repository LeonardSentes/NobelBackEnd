using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NobelBackEnd.Core
{
    public interface IGenericRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        void Insert (T obj);
        void Update (T obj);
        void Delete (T obj);
        void Save();
    }
}