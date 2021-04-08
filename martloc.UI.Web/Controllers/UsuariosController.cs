using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using martloc.ApplicationCore.Interfaces.Services;
using financeiro.UI.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace martloc.UI.Web.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IUsuarioServices _usuarioServices;




        public UsuariosController(IUsuarioServices usuarioServices)
        {
            _usuarioServices = usuarioServices;
        }
        public IActionResult Index()
        {
            var dd = _usuarioServices.List.Select(f => new UsuarioViewModel { Id = f.Id, Nome = f.UserName });
            return View(_usuarioServices.List.Select(f=> new UsuarioViewModel {Id=f.Id,Nome=f.UserName }));
   
        }

        public IActionResult Edit(string id)
        {

          //  ViewBag.Roles= ViewBag.ID = new SelectList(setores, "setorNome");

            return View(_usuarioServices.List.Where(e=>e.Id==id).Select(f => new UsuarioViewModel { Id = f.Id, Nome = f.UserName }).FirstOrDefault());

        }
    }
}