using StayOver.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StayOver.Services.Interfaces
{
    public interface ICityService
    {
        Task<IEnumerable<City>> GetCitiesiesAsync();
    }
}
