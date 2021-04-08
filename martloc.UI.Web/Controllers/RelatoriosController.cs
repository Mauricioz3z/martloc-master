using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace financeiro.UI.Web.Controllers
{
    public class RelatoriosController : Controller
    {

        [Authorize(Roles = "Admin,Gerente")]
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Detalhes()
        {
            return View();
        }


        
    }
}