using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using martloc.ApplicationCore.Entity;
using martloc.ApplicationCore.Interfaces.Services;
using martloc.UI.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace martloc.UI.Web.Controllers
{
    public class LocacaoController : Controller
    {
        private readonly ILocacaoServices _locacaoServices;
        private readonly IMapper _mapper;
        
        public LocacaoController(ILocacaoServices locacaoServices, IMapper mapper)
        {
            _locacaoServices = locacaoServices;
            _mapper =mapper;
    }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        

        public IActionResult GetLocacoes()
        {
            //Referencia circular
            var locacoes = _locacaoServices.List.Include(e => e.Pessoa)
                                                .Include("LocacaoItens.Equipamento").ToList();
            return Json(new { data = _mapper.Map<List<LocacaoViewModel>>(locacoes) });
        }

    }
}