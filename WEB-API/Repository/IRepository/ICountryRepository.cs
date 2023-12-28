using WorldAPI.Data;
using WorldAPI.Models;

namespace WorldAPI.Repository.IRepository
{
    public interface ICountryRepository : IGenericRepository<Countries>
    { 
        Task Update (Countries entity);
      
    }
}
