using Microsoft.EntityFrameworkCore;
using StayOver.Models;

namespace StayOver.Data
{
    public static class DbContextExtentions
    {

        public static ModelBuilder SeedCity(this ModelBuilder builder)
        {
            builder.Entity<City>().HasData(new City { CityId = 1, Name = "Banovići" });
            builder.Entity<City>().HasData(new City { CityId = 2, Name = "Banja Luka" });            
            builder.Entity<City>().HasData(new City { CityId = 3, Name = "Bihać"});
            builder.Entity<City>().HasData(new City { CityId = 4, Name = "Bijeljina" });
            builder.Entity<City>().HasData(new City { CityId = 5, Name = "Brčko" });
            builder.Entity<City>().HasData(new City { CityId = 6, Name = "Cazin"});
            builder.Entity<City>().HasData(new City { CityId = 7, Name = "Kakanj" });
            builder.Entity<City>().HasData(new City { CityId = 8, Name = "Konjic" });
            builder.Entity<City>().HasData(new City { CityId = 9, Name = "Mostar"});
            builder.Entity<City>().HasData(new City { CityId = 10, Name = " Neum" });
            builder.Entity<City>().HasData(new City { CityId = 11, Name = "Sanski Most"});
            builder.Entity<City>().HasData(new City { CityId = 12, Name = "Sarajevo"});
            builder.Entity<City>().HasData(new City { CityId = 13, Name = "Tuzla"});
            builder.Entity<City>().HasData(new City { CityId = 14, Name = "Velika Kladuša"});
            builder.Entity<City>().HasData(new City { CityId = 15, Name = "Stolac" });
            builder.Entity<City>().HasData(new City { CityId = 16, Name = "Tešanj" });
            builder.Entity<City>().HasData(new City { CityId = 17, Name = "Travnik" });
            builder.Entity<City>().HasData(new City { CityId = 18, Name = "Trebinje" });
            builder.Entity<City>().HasData(new City { CityId = 19, Name = "Zenica" });
            builder.Entity<City>().HasData(new City { CityId = 20, Name = "Zvornik" });

            return builder;
        }
    }
}
