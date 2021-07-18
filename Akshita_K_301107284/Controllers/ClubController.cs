using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jasmine_Soccer.Models;
using Microsoft.AspNetCore.Mvc;


namespace Jasmine_Soccer.Controllers
{
    public class ClubController : Controller
    {

        private IClubRepository clubRepo;
        private IPlayerRepository playerRepo;

        public ClubController(IClubRepository clubRepository, IPlayerRepository playerRepository)
        {
            clubRepo = clubRepository;
            playerRepo = playerRepository;
        }

        public ViewResult ClubList()
        {
            IEnumerable<Club> clubs = clubRepo.GetClubs();
            return View(clubs);
        }

        [HttpPost]
        public ViewResult AddClub(Club club)
        {
            clubRepo.SaveClub(club);

            Player player = playerRepo.GetPlayer(club.YourName);

            if (player != null)
            {
                player.ClubName = club.ClubName;
                playerRepo.SavePlayer(player);
            }

            TempData["message"] = $"Club {club.ClubName} saved!";

            return View(club);
        }

        [HttpGet]
        public ViewResult AddClub(int clubId)
        {
            Club club = clubRepo.GetClub(clubId);
            return View(club);
        }

        public IActionResult RemoveClub(int clubId)
        {
            Club club = clubRepo.GetClub(clubId);

            if (club != null)
            {
                clubRepo.DeleteClub(club);
                TempData["message"] = $"Club {club.ClubName} deleted!";
            }

            return RedirectToAction("ClubList");
        }

        public ViewResult AddClub()
        {
            return View();
        }

        public ViewResult ClubDetails()
        {
            return View();
        }

        [HttpGet]
        public ViewResult ClubDetails(int clubId)
        {
            Club club = clubRepo.GetClub(clubId) ;
            club.Players = playerRepo.GetPlayers(club.ClubName);

            return View(club);
        }

    }
}
