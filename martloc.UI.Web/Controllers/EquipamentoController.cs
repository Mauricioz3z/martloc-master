using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace martloc.UI.Web.Controllers
{
    public class EquipamentoController : Controller
    {
        // GET: Equipamento
        public ActionResult Index()
        {
            return View();
        }

        // GET: Equipamento/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Equipamento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Equipamento/Create
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

        // GET: Equipamento/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Equipamento/Edit/5
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

        // GET: Equipamento/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Equipamento/Delete/5
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