using Microsoft.EntityFrameworkCore;
using System.Formats.Asn1;
using WorldAPI.Data;
using WorldAPI.Models;


namespace WorldAPI.Repository.IRepository
{
    public class StatesRepository : GenericRepository<State>, IStatesRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public StatesRepository (ApplicationDBContext dbContext) : base(dbContext) 
        {
            _dbContext = dbContext;
        }
        public async Task Update(State entity)
        {
            _dbContext.State.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<State>> GetStateWCountry(String country)
        {
            var countryWithState = await _dbContext.State
                .Include(x => x.Countries)
                .Where(x => x.Countries.CountryName.Trim().ToLower() == country.Trim().ToLower())
                .ToListAsync();
            return countryWithState;
        }




    }
}
