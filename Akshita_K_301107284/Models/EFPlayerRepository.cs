using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jasmine_Soccer.Models
{
    public class EFPlayerRepository : IPlayerRepository
    {

        private ApplicationDbContext context;
        public EFPlayerRepository(ApplicationDbContext ctx)
        {
            context = ctx;

        }

        public IEnumerable<Player> GetPlayers()
        {
            return context.Players;
        }

        public Player GetPlayer(string playerName)
        {
            return context.Players.FirstOrDefault(p => p.PlayerName == playerName);
        }

        public IEnumerable<Player> GetPlayers(string clubName)
        {
            return context.Players.Where(p => p.ClubName == clubName);
        }

        public void SavePlayer(Player player)
        {
            Player dbPlayer = context.Players.FirstOrDefault(p => p.PlayerId == player.PlayerId);

            if (dbPlayer != null)
            {
                dbPlayer.PlayerName = player.PlayerName;
                dbPlayer.PlayerEmail = player.PlayerEmail;
                dbPlayer.PlayerNumber = player.PlayerNumber;
                dbPlayer.ClubName = player.ClubName;
            }
            else
            {
                context.Players.Add(player);
            }
            context.SaveChanges();
        }
    }
}
