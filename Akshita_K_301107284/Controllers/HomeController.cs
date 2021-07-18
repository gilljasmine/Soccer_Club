using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jasmine_Soccer.Models;
using Microsoft.AspNetCore.Mvc;

namespace Jasmine_Soccer.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }
       
       

    }
}