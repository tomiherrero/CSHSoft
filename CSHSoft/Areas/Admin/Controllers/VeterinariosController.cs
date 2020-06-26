using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSHFSoft.AccesoDatos.Data.Repository;
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
        public IActionResult Index()
        {
            return View();
        }
        #region LLAMADAS A LA API
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { Data = _contenedorTrabajo.Veterinario.GetAll() });
        }
        #endregion
    }
}
