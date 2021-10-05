using StayOver.Models;
using StayOver.Repos.Interfaces;
using StayOver.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StayOver.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepo _repo;

        public CityService(ICityRepo repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<City>> GetCitiesiesAsync()
        {
            return await _repo.GetCitiesAsync();
        }
    }
}
