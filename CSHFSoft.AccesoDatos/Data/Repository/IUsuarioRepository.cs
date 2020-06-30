using CSHSoft.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSHFSoft.AccesoDatos.Data.Repository
{
    // Repositorio Usuario para crear metodos especificos
    public interface IUsuarioRepository : IRepository<ApplicationUser> // Hereda de IRepository 
    {

        void BloqueaUsuario(string IdUsuario);
        void DesbloquearUsuario(string IdUsuario);
    }
}
