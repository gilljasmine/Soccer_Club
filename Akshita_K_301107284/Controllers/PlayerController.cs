using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jasmine_Soccer.Models;
using Microsoft.AspNetCore.Mvc;

namespace Jasmine_Soccer.Controllers
{
    public class PlayerController : Controller
    {

        private IPlayerRepository playerRepo;

        public PlayerController(IPlayerRepository playerRepository)
        {
            playerRepo = playerRepository;
        }

        public ViewResult PlayersPage()
        {
            return View();
        }
        public ViewResult PlayerList()
        {

            IEnumerable<Player> players = playerRepo.GetPlayers();
            return View(players);

        }
       
        public ViewResult Reassign(string clubName)
        {
            Player player = new Player();
            player.ClubName = clubName;
            return View(player);
        }

        [HttpPost]
        public ViewResult Reassign(Player player)
        {
            Player dbPlayer = playerRepo.GetPlayer(player.PlayerName);
            string playerName = player.PlayerName;

            if (dbPlayer != null)
            {
                dbPlayer.ClubName = player.ClubName;
                playerRepo.SavePlayer(dbPlayer);
                TempData["message"] = $"Player {playerName} updated!";
            }
            else
            {
                TempData["message"] = $"Player {playerName} not found.";
            }

            return View();
        }
        public ViewResult Delete()
        {
            return View();
        }
    }
}
