namespace University.Model
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity?> CreateAsync(TEntity item);
        TEntity FindById(int id);
        Task<IEnumerable<TEntity>> GetListAsync();
        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
        void Remove(TEntity item);
        void Update(TEntity item);
    }
}
