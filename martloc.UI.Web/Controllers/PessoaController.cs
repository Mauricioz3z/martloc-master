using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using martloc.ApplicationCore.Entity;
using martloc.ApplicationCore.Interfaces.Services;
using martloc.UI.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace martloc.UI.Web.Controllers
{
    public class PessoaController : Controller

    {

        private readonly IPessoaServices _pessoaServices;
        private readonly IFisicaServices _fisicaServices;
        private readonly IJuridicaServices _juridicaServices;
        
        private readonly IMapper _mapper;

        public PessoaController(IPessoaServices pessoaServices,
                               IFisicaServices fisicaServices,
                                 IJuridicaServices juridicaServices,
                               IMapper mapper)
        {
            _pessoaServices = pessoaServices;
            _fisicaServices = fisicaServices;
            _juridicaServices = juridicaServices;
            _mapper = mapper;
        }

        // GET: Pessoa
        public ActionResult Index()
        {
            return View();
        }

        // GET: Pessoa/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pessoa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pessoa/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(PessoaViewModel model)//IFormCollection collection
        {

            if (model.TipoPessoa==0)
            {
                var fisica = _mapper.Map<PessoaViewModel, Fisica>(model);
                _fisicaServices.Adicionar(fisica);
            }
            else {
                var juridica = _mapper.Map<PessoaViewModel, Juridica>(model);
                _juridicaServices.Adicionar(juridica);
            }




    
            


            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Pessoa/Edit/5
        public ActionResult Edit(int id)
        {
            var pessoa = _pessoaServices.ObterPorId(id);
            return Json(pessoa);
        }

        // POST: Pessoa/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(PessoaViewModel model)//int id, IFormCollection collection
        {


            
            try
            {


                // TODO: Add update logic here
               // _pessoaServices.Atualizar(_mapper.Map<PessoaViewModel, Pessoa>(model));


                if (model.TipoPessoa ==0)
                {
                    var fisica = _mapper.Map<PessoaViewModel, Fisica>(model);
                    _fisicaServices.Atualizar(fisica);
                }
                else
                {
                    var juridica = _mapper.Map<PessoaViewModel, Juridica>(model);
               
                    _juridicaServices.Atualizar(juridica);
                }





                return RedirectToAction(nameof(Index));
            }
            catch(Exeption e)
            {
                return View(e.Message);
            }
        }

        // GET: Pessoa/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pessoa/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult GetPessoas()
        {


            var pessoas = _mapper.Map<List<PessoaViewModel>>(_pessoaServices.List);

            return Json(new { data = pessoas });

        }
    }
}