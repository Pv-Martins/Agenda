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
        private readonly IConsultaRepository consultaRepository;

        public ConsultaController(IConsultaRepository consultaRepository)
        {
            this.consultaRepository = consultaRepository;
        }

        // GET: Consulta
        public IActionResult Index()
        {
            return View(consultaRepository.GetConsultas());
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
                consultaRepository.SaveConsulta(consulta);
    
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
            var consulta = consultaRepository.GetConsulta(id);
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
            consultaRepository.UpdateConsulta(id, consulta);

            return RedirectToAction("Index");
        }

        // GET: Consulta/Delete/5
        public IActionResult Delete(int id)
        {
            consultaRepository.RemoveConsulta(id);
            return RedirectToAction("Index");
        }

        // POST: Consulta/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Consulta consulta)
        {
            // TODO ATUALIZAR PARA DELETAR NO POST.

            consultaRepository.RemoveConsulta(consulta.Id);

            return RedirectToAction("Index");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}