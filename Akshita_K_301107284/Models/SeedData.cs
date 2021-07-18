using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jasmine_Soccer.Models
{
    public class SeedData
    {

        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices
            .GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.Clubs.Any())
            {

                context.Clubs.AddRange(
                    new Club { ClubName = "Toronto FC", YourName="Akshita", AgeGroup=26 },
                    new Club { ClubName = "Brampton Soccer Club", YourName = "Akshita", AgeGroup = 32 },
                    new Club { ClubName = "Terminators", YourName = "Akshita", AgeGroup = 35 },
                    new Club { ClubName = "Red Dragon FC", YourName = "Akshita", AgeGroup = 30 },
                    new Club { ClubName = "Team Avengers", YourName = "Akshita", AgeGroup = 50 }
                );
            }

            if (!context.Players.Any())
            {

                context.Players.AddRange(
                    new Player { PlayerName = "Davis", ClubName = "Toronto FC", PlayerAge = 22 },
                    new Player { PlayerName = "Rock", ClubName = "Terminators", PlayerAge = 21 },
                    new Player { PlayerName = "Simmi", ClubName = "Toronto FC", PlayerAge = 18 },
                    new Player { PlayerName = "Preet", ClubName = "Red Dragon FC", PlayerAge = 19 },
                    new Player { PlayerName = "Karan", ClubName = "Red Dragon FC", PlayerAge = 27 },
                    new Player { PlayerName = "Babal", ClubName = "Terminators", PlayerAge = 25 },
                    new Player { PlayerName = "Akshita", ClubName = "Red Dragon FC", PlayerAge = 16 },
                    new Player { PlayerName = "Gurleen", ClubName = "Terminators", PlayerAge = 28 }
                );
            }
            context.SaveChanges();
        }
    }
}
