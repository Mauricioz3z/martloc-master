using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using financeiro.UI.Web.Models;
using martloc.ApplicationCore.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;

namespace financeiro.UI.Web.Controllers
{
    public class HomeController : Controller
    {


        [Authorize(Policy = "precisaRealizarLogin")]
        public IActionResult Index()
        {
          

            return View();
        }


     
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
