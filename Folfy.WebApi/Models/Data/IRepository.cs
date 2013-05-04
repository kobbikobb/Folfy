using System.Collections.Generic;

namespace Folfy.WebApi.Models.Data
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        T Get(int id);
        void Create(T t);
        void Update(T t);
        void Delete(T t);
    }
}