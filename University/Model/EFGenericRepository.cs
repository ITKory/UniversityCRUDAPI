using Microsoft.EntityFrameworkCore;

namespace University.Model
{
    public class EFGenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {

        MykbecgkContext _context;
        DbSet<TEntity> _dbSet;

        public EFGenericRepository(MykbecgkContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async  Task<IEnumerable<TEntity>> GetListAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public IEnumerable<TEntity> Get(Func<TEntity,bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).ToList();
        }
        public TEntity FindById(int id)
        {
            return _dbSet.Find(id);
        }

        public async Task<TEntity?> CreateAsync(TEntity item)
        {
            if (item is not null)
            {
               await _dbSet.AddAsync(item);
                _context.SaveChanges();
            }
                return item;
        }
        public void Update(TEntity item)
        {
              _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
 
        }
        public void Remove(TEntity item)
        {
            _dbSet.Remove(item);
            _context.SaveChanges();
        }

    }
}
