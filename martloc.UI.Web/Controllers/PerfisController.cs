using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;
using financeiro.UI.Web.Models;
using martloc.UI.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace martloc.UI.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PerfisController : Controller
    {
        private RoleManager<IdentityRole> _roleMngr { get; }


        public PerfisController(RoleManager<IdentityRole> RoleMngr)
        {
            _roleMngr = RoleMngr;
        }
      


        
        

        public IActionResult Index()
        {




            var roles = _roleMngr.Roles.Select(e => new RolesViewModel { Id = e.Id, Name = e.Name });

            return View(roles);
        }



        public async Task<ActionResult> GetAcoes(string tela,string RoleId) {

            Assembly asm = Assembly.GetExecutingAssembly();

            var controlleractionlist = asm.GetTypes()
            .Where(type => typeof(Controller).IsAssignableFrom(type))
            .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
            .Where(m => !m.GetCustomAttributes(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), true).Any())
            .Select(x => new { Controller = x.DeclaringType.Name, Action = x.Name, ReturnType = x.ReturnType.Name, Attributes = String.Join(",", x.GetCustomAttributes().Select(a => a.GetType().Name.Replace("Attribute", ""))) })
            .OrderBy(x => x.Controller).ThenBy(x => x.Action).GroupBy(j => new { j.Controller })
            .Select(e => new TelaViewModel
            {
                Nome = e.Key.Controller.Replace("Controller", ""),
                Acoes = e.Select(v => v.Action).Distinct().ToList()
            }).ToList();

            var telaSelecioanda = controlleractionlist.FirstOrDefault(f => f.Nome == tela);
            if (telaSelecioanda != null)
            {
                var role = _roleMngr.Roles.FirstOrDefault(f => f.Id == RoleId);
                var Claimsx = await _roleMngr.GetClaimsAsync(role);
                ViewBag.acoesSelecionadas = Claimsx.Select(e=>e.Value).ToList();
                ViewBag.telaSelecionada = telaSelecioanda.Nome;
                return View("~/Views/Perfis/_Acoes.cshtml", telaSelecioanda.Acoes);
            }
            else {
                return View("~/Views/Perfis/_Acoes.cshtml", new List<string>());
            }


        
        }
    
        public IActionResult Edit(string id)
        {
            var role = _roleMngr.Roles.Where(f => f.Id == id).Select(e => new RolesViewModel { Id = e.Id, Name = e.Name }).FirstOrDefault();

            Assembly asm = Assembly.GetExecutingAssembly();

            var controlleractionlist = asm.GetTypes()
                    .Where(type => typeof(Controller).IsAssignableFrom(type))
                    .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
                    .Where(m => !m.GetCustomAttributes(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), true).Any())
                    .Select(x => new { Controller = x.DeclaringType.Name, Action = x.Name, ReturnType = x.ReturnType.Name, Attributes = String.Join(",", x.GetCustomAttributes().Select(a => a.GetType().Name.Replace("Attribute", ""))) })
                    .OrderBy(x => x.Controller).ThenBy(x => x.Action).GroupBy(j => new { j.Controller })
                    .Select(e => new TelaViewModel
                    {
                        Nome = e.Key.Controller.Replace("Controller", ""),
                        Acoes = e.Select(v => v.Action).Distinct().ToList()
                    }).ToList();


            ViewBag.Controller = controlleractionlist;
            ViewBag.RoleName = role.Name;
            ViewBag.RoleId = role.Id;

            return View(controlleractionlist);
        }

        [HttpPost]
      
        public async Task<ActionResult> Edit(PerfilViewModel perfil) {
            var role = _roleMngr.Roles.FirstOrDefault(f => f.Id == perfil.Id);

            var storedClaims = await _roleMngr.GetClaimsAsync(role);
            foreach (var item in storedClaims)
            {
                _roleMngr.RemoveClaimAsync(role, item).Wait();


            }


            foreach (var item in perfil.Claims)
            {
                _roleMngr.AddClaimAsync(role, new Claim(item, item)).Wait();

            }

            return Ok();
        }


    }
}
