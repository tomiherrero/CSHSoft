using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSHFSoft.AccesoDatos.Data.Repository;
using CSHSoft.Models;
using Microsoft.AspNetCore.Mvc;

namespace CSHSoft.Areas.Admin.Controllers
{[Area("Admin")]
    public class VeterinariosController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public VeterinariosController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet] //Llamada al formulario Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(Veterinario veterinario)
        {
            if (ModelState.IsValid)
            {
                _contenedorTrabajo.Veterinario.Add(veterinario);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }

            return View(veterinario);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Veterinario veterinario = new Veterinario();
            veterinario = _contenedorTrabajo.Veterinario.Get(id);
            if (veterinario == null)
            {
                return NotFound();
            }

            return View(veterinario);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(Veterinario veterinario)
        {
            if (ModelState.IsValid)
            {
                _contenedorTrabajo.Veterinario.Update(veterinario);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(veterinario);
        }

        #region LLAMADAS A LA API
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { Data = _contenedorTrabajo.Veterinario.GetAll() });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objeto = _contenedorTrabajo.Veterinario.Get(id);
            if (objeto == null)
            {
                return Json(new { success = false, message = "Error" });
            }

            _contenedorTrabajo.Veterinario.Remove(objeto);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Veterinario borrado correctamente" });
        }
        #endregion
    }
}
