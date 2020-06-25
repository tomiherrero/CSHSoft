using CSHSoft.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSHFSoft.AccesoDatos.Data.Repository
{
    // Repositorio Veterinario para crear metodos especificos
    public interface IVeterinarioRepository : IRepository<Veterinario> // Hereda de IRepository 
    {
        IEnumerable<SelectListItem> GetListaVeterinario();

        void Update(Veterinario veterinario);
    }
}
