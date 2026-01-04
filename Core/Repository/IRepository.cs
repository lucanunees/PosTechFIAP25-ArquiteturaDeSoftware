using Core.Entity;

namespace Core.Repository
{
    public interface IRepository<T> where T : EntityBase
    {
        // Summary: O <t> significa que é uma lista genérica.
        IList<T> GetAll();
        T GetId(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
