namespace Application.Interfaces
{
    public interface IRepository<TEntity>
    {
        public TEntity GetById(Guid id);
        public List<TEntity> GetAll();
        public TEntity Create(TEntity entity);
        public TEntity Update(TEntity entity);
        public bool Delete(Guid id);
        public Task SaveChanges();
    }
}