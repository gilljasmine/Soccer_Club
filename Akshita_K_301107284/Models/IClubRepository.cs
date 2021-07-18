using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jasmine_Soccer.Models
{
    public interface IClubRepository
    {
        
        Club GetClub(int clubId);

        IEnumerable<Club> GetClubs();

        void SaveClub(Club club);

        string DeleteClub(Club club);

    }
}
