using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CSHFSoft.AccesoDatos.Data.Repository;
using CSHSoft.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CSHSoft.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]

    public class UsuariosController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public UsuariosController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }

        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var usuarioActual = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            return View(_contenedorTrabajo.Usuario.GetAll(u => u.Id != usuarioActual.Value));
        }
        public IActionResult Bloquear(string id, Auditoria auditoria)
        {
            if (id == null)
            {
                return NotFound();

            }

            _contenedorTrabajo.Usuario.BloqueaUsuario(id);
            _contenedorTrabajo.Auditoria.Add(auditoria);
            auditoria.nombreUsuario = @User.Identity.Name;
            auditoria.fecha = DateTime.Now;
            auditoria.accion = "Bloqueo usuario con id " + id;
            _contenedorTrabajo.Save();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Desbloquear(string id, Auditoria auditoria)
        {
            if (id == null)
            {
                return NotFound();

            }

            _contenedorTrabajo.Usuario.DesbloquearUsuario(id);
            _contenedorTrabajo.Auditoria.Add(auditoria);
            auditoria.nombreUsuario = @User.Identity.Name;
            auditoria.fecha = DateTime.Now;
            auditoria.accion = "Desbloqueo usuario con id " + id;
            _contenedorTrabajo.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}