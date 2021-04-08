using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using martloc.ApplicationCore.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace financeiro.UI.Web.Controllers
{
    public class ClienteController : Controller
    {

        private readonly IClienteServices _clienteServices;
        public ClienteController(IClienteServices clienteServices) 
        {
            _clienteServices = clienteServices;
        }


        // GET: Clinte
        public IActionResult Index()
        {

            return Json(_clienteServices.List);
        }

        // GET: Clinte/Details/5
        public ActionResult Details(int id)
        {
            return Json(_clienteServices.ObterPorId(id));
        }

        // GET: Clinte/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clinte/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
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

        // GET: Clinte/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Clinte/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Clinte/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Clinte/Delete/5
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
    }
}