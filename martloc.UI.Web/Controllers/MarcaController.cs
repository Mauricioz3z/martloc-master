
using System.Collections.Generic;
using AutoMapper;
using martloc.ApplicationCore.Entity;
using martloc.ApplicationCore.Interfaces.Services;
using martloc.UI.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace martloc.UI.Web.Controllers
{
    [Authorize(Roles = "Admin,Gerente,Coordenador")]
    public class MarcaController : Controller
    {
        private readonly IMarcaServices _marcaServices;
        private readonly IMapper _mapper;

        public MarcaController(IMarcaServices marcaServices, IMapper mapper)
        {
            _marcaServices = marcaServices;
            _mapper= mapper;
        }
        [Authorize(Policy = "podeListarMarcas")]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Policy = "podeCriarMarca")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "podeCriarMarca")]
        public IActionResult Create(MarcaViewModel model)
        {


          var marca=  _mapper.Map<Marca>(model);

            try
            {
                _marcaServices.Adicionar(marca);

                return  Json(new { resposta=1});
            }
            catch (Exeption e)
            {
               
                return Json(new { resposta = -1 });
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "podeEditarMarca")]
        public int Edit(MarcaViewModel model)
        {

            var marca = _mapper.Map<Marca>(model);

            try
            {
                _marcaServices.Atualizar(marca);

                return 1;
            }
            catch (Exeption e)
            {
                return -1;
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "podeDeletarMarca")]
        public int Delete(int id)
        {
            try
            {
                var marca =_marcaServices.ObterPorId(id);
                if (marca != null) {
                    _marcaServices.Remover(marca);
                    return 1;
                }
                else { return -1; }
            }
            catch
            {
                return -1;
            }
        }

        [Authorize(Policy = "podeObterMarcaAjax")]
        public ActionResult GetMarcas()
        {
            var marcas = _mapper.Map<List<MarcaViewModel>>(_marcaServices.List);
            return Json(new{data= marcas });
            
        }

        
    }
}