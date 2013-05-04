using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using Folfy.WebApi.Models;
using Folfy.WebApi.Models.Data;


namespace Folfy.WebApi.Data
{
    public abstract class GenericRepository<T> : IRepository<T> where T : class, IModel
    {
        private readonly FolfyDbContext dbContext;

        protected GenericRepository()
        {
            dbContext = new FolfyDbContext();
        }

        protected virtual IQueryable<T> Set
        {
            get { return dbContext.Set<T>(); }
        }

        public List<T> GetAll()
        {
            return Set.ToList();
        }

        public T Get(int id)
        {
            return Set.SingleOrDefault(x => x.Id == id);
        }

        public void Create(T t)
        {
            dbContext.Set<T>().Add(t);
            dbContext.SaveChanges();
        }

        public void Update(T t)
        {
            dbContext.Entry(t).State = EntityState.Modified;
            dbContext.SaveChanges();
        }

        public void Delete(T t)
        {
            dbContext.Set<T>().Remove(t);
            dbContext.SaveChanges();
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}