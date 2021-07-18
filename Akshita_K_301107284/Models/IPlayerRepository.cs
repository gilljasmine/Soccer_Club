using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jasmine_Soccer.Models
{
    public interface IPlayerRepository
    {

        IEnumerable<Player> GetPlayers();

        IEnumerable<Player> GetPlayers(string clubName);

        Player GetPlayer(string playerName);

        void SavePlayer(Player player);

    }
}
