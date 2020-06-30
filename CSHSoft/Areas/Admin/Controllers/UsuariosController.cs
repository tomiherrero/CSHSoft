﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CSHFSoft.AccesoDatos.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CSHSoft.Areas.Admin.Controllers
{
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
        public IActionResult Bloquear(string id)
        {
            if (id == null)
            {
                return NotFound();

            }

            _contenedorTrabajo.Usuario.BloqueaUsuario(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Desbloquear(string id)
        {
            if (id == null)
            {
                return NotFound();

            }

            _contenedorTrabajo.Usuario.DesbloquearUsuario(id);
            return RedirectToAction(nameof(Index));
        }
    }
}