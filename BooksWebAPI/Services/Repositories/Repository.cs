using BooksWebAPI.Contexts;
using System.Linq.Expressions;
namespace BooksWebAPI.Services.Repositories
{

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private MedITContext _context;

        public Repository(MedITContext context) {
            _context = context ?? throw new ArgumentNullException(nameof(context));
                }
        public TEntity Add(TEntity entity) {
        if(entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            return entity;
        }
        public IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities) {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }
            _context.Set<TEntity>().AddRange(entities);
            return entities;
        }
        public TEntity FindDefault(Expression<Func<TEntity, bool>> predicate) {
            return _context.Set<TEntity>().Where(predicate).FirstOrDefault();
        }
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate) {
            return _context.Set<TEntity>().Where(predicate).ToList();
        }
        public IEnumerable<TEntity> GetAll() {
            return _context.Set<TEntity>().ToList();
        }
        public TEntity Get(int id) {
            return _context.Set<TEntity>().Find(id);
        }
        public TEntity Remove(TEntity entity) {
             _context.Set<TEntity>().Remove(entity);
            return entity;
        }
        public IEnumerable<TEntity> RemoveRange(IEnumerable<TEntity> entities) {
             _context.Set<TEntity>().RemoveRange(entities);
            return entities;
        }


    }
}