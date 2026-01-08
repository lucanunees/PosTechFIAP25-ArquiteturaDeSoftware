using Domain.Entity;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class EFRepository<T> : IRepository<T> where T : EntityBase
    {
        protected ApplicationDbContext _context;
        protected DbSet<T> _dbSet;

        public EFRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Create(T entity)
        {
            entity.CreateAt = DateTime.Now;
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _dbSet.Remove(GetId(id));
            _context.SaveChanges();
        }

        public IList<T> GetAll()
            => _dbSet.ToList();

        public T GetId(int id)
            => _dbSet.FirstOrDefault(entity => entity.Id == id);

        public void Update(T entity)
        {
            entity.CreateAt = DateTime.Now;
            _dbSet.Update(entity);
            _context.SaveChanges();
        }
    }
}
