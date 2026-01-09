using System.Collections.Generic;
using Domain.Entity;

namespace Domain.Repository
{
    public interface IRepository<T> where T : EntityBase
    {
        // Summary: O <t> significa que é uma lista genérica.
        IList<T> GetAll();
        T GetById(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
