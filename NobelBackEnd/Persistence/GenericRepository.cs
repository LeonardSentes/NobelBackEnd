using NobelBackEnd.Core;
using NobelBackEnd.MyDatabase;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Web;

namespace NobelBackEnd.Persistence
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public ApplicationDbContext db;
        public DbSet<T> table;
        public GenericRepository(ApplicationDbContext context)
        {
            db = context;
            table = db.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }
        public T GetById(object id) 
        { 
            return table.Find(id);
        }
        public void Insert(T obj) 
        {
            //db.Entry(obj).State = EntityState.Added;//
            table.Add(obj);
        }
        public void Update(T obj) 
        {
            table.Attach(obj);
            db.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(object id) 
        {
            T existing = table.Find(id);
            table.Remove(existing); //db.Entity(obj).State = EntityState.Deleted;
        }
        public void Save() 
        {
            db.SaveChanges();
        }

        void IGenericRepository<T>.Delete(T obj)
        {
            throw new NotImplementedException();
        }
    }
}