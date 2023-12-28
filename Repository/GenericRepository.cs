using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Security.AccessControl;
using WorldAPI.Data;
using WorldAPI.Repository.IRepository;

namespace WorldAPI.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDBContext _dbContext;

        public GenericRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Create(T entity)
        {
            await _dbContext.AddAsync(entity);
            await Save();
        }

        public async Task Delete(T entity)
        {
            _dbContext.Remove(entity);
            await Save();
        }

        public async Task<T> Get(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public bool IsRecordExists(Expression<Func<T, bool>> condition)
        {
            var result = _dbContext.Set<T>().AsQueryable().Where(condition).Any();
            return result;
        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
