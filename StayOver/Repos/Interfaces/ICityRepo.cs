using StayOver.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StayOver.Repos.Interfaces
{
    public interface ICityRepo
    {
        Task<IEnumerable<City>> GetCitiesAsync();
    }
}
