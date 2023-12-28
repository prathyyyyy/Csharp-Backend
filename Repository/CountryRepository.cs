using Microsoft.EntityFrameworkCore;
using WorldAPI.Data;
using WorldAPI.Models;
using WorldAPI.Repository.IRepository;

namespace WorldAPI.Repository
{
    public class CountryRepository : GenericRepository<Countries>,ICountryRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public CountryRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task Update(Countries entity)
        {
            _dbContext.Countries.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
