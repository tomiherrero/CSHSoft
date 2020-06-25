using CSHFSoft.AccesoDatos.Data.Repository;
using CSHSoft.AccesoDatos.Data;
using CSHSoft.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSHFSoft.AccesoDatos.Data
{
    public class VeterinarioRepository : Repository<Veterinario>, IVeterinarioRepository
    {
        private readonly ApplicationDbContext _db;

        public VeterinarioRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public IEnumerable<SelectListItem> GetListaVeterinario()
        {
            return _db.Veterinario.Select(i => new SelectListItem() {

                Text = i.RazonSocial,
                Value = i.IdVeterinario.ToString()
            });
        }

        public void Update(Veterinario veterinario)
        {
            // traigo los valores ya existente para poder actualizar
            var objeto = _db.Veterinario.FirstOrDefault(s => s.IdVeterinario == veterinario.IdVeterinario);
            objeto.RazonSocial = veterinario.RazonSocial;
            objeto.Direccion = veterinario.Direccion;
            objeto.HorarioAtencion = veterinario.HorarioAtencion;
            objeto.Internacion = veterinario.Internacion;
            objeto.Observaciones = veterinario.Observaciones;

            _db.SaveChanges();
        }
    }
}
