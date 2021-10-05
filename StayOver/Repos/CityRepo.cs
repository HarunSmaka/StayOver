using Microsoft.EntityFrameworkCore;
using StayOver.Data;
using StayOver.Models;
using StayOver.Repos.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StayOver.Repos
{
    public class CityRepo : ICityRepo
    {
        private readonly StayOverDbContext _context;

        public CityRepo(StayOverDbContext context)
        {
            _context = context;
        }   

        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            return await _context.Cities.ToListAsync();
        }
    }
}
