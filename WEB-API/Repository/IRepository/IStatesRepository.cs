using WorldAPI.Models;

namespace WorldAPI.Repository.IRepository
{
    public interface IStatesRepository  : IGenericRepository<State>
    { 
        Task Update(State entity);
        Task<List<State>> GetStateWCountry(String country);

    }
}
