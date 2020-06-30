using CSHFSoft.AccesoDatos.Data.Repository;
using CSHSoft.AccesoDatos.Data;
using CSHSoft.Models;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Internal.Account.Manage;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSHFSoft.AccesoDatos.Data
{
    public class UsuarioRepository : Repository<ApplicationUser>, IUsuarioRepository
    {
        private readonly ApplicationDbContext _db;

        public UsuarioRepository(ApplicationDbContext db) : base (db)
        {
            _db = db;
        }
        public void BloqueaUsuario(string IdUsuario)
        {
            var usuarioDb = _db.ApplicationUser.FirstOrDefault(u => u.Id == IdUsuario);
            usuarioDb.LockoutEnd = DateTime.Now.AddYears(100);
            _db.SaveChanges();
        }

        public void DesbloquearUsuario(string IdUsuario)
        {
            var usuarioDb = _db.ApplicationUser.FirstOrDefault(u => u.Id == IdUsuario);
            usuarioDb.LockoutEnd = DateTime.Now;
            _db.SaveChanges();
        }
    }
}
