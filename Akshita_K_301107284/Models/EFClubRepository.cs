using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Jasmine_Soccer.Models
{
    public class EFClubRepository: IClubRepository
    {
        private ApplicationDbContext context;
        public EFClubRepository(ApplicationDbContext ctx)
        {
            context = ctx;

        }

        public Club GetClub(int clubId)
        {
            return context.Clubs.FirstOrDefault(c => c.ClubId == clubId);
        }

        public string DeleteClub(Club club)
        {
            Club dbClub = context.Clubs.FirstOrDefault(c => c.ClubId == club.ClubId);

            if (dbClub != null)
            {
                context.Clubs.Remove(dbClub);
                context.SaveChanges();
            }

            return club.ClubName;
        }

        public IEnumerable<Club> GetClubs()
        {
            IEnumerable<Club> clubs = context.Clubs;
            return clubs;
        }

        public void SaveClub(Club club)
        {
            Club dbClub = context.Clubs.FirstOrDefault(c => c.ClubId == club.ClubId);

            if (dbClub != null)
            {
                dbClub.ClubName = club.ClubName; 
                dbClub.AgeGroup = club.AgeGroup; 
                dbClub.Players = club.Players; 
                dbClub.YourName = club.YourName; 
            }
            else
            {
                context.Clubs.Add(club);
            }
            context.SaveChanges();
        }
    }
}
