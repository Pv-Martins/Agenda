using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AgendaITIX.Models;
using AgendaITIX.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgendaITIX.Controllers
{
    public class ConsultaController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public ConsultaController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        
        // GET: Consulta
        public IActionResult Index()
        {
            return View(unitOfWork.Consultas.GetAll());
        }

        // GET: Consulta/Create
        public IActionResult Create()
        {
            Paciente paciente = new Paciente();
            return View();
        }

        // POST: Consulta/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Consulta consulta)
        {
            try
            {
                unitOfWork.Consultas.Insert(consulta);
                unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Consulta/Edit/5
        public IActionResult Edit(int id)
        {
            var consulta = unitOfWork.Consultas.GetById(id);
            if (consulta == null)
            {
                return NotFound();
            }
            return View(consulta);
        }

        // POST: Consulta/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Consulta consulta)
        {
            unitOfWork.Consultas.Update(consulta);
            unitOfWork.Save();

            return RedirectToAction("Index");
        }

        // GET: Consulta/Delete/5
        public IActionResult Delete(int id)
        {
            unitOfWork.Consultas.Delete(id);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }

        // POST: Consulta/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Consulta consulta)
        {
            // TODO ATUALIZAR PARA DELETAR NO POST.

            unitOfWork.Consultas.Delete(consulta.Id);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}