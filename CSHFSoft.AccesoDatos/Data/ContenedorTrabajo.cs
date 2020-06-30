using CSHFSoft.AccesoDatos.Data.Repository;
using CSHSoft.AccesoDatos.Data;
using CSHSoft.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSHFSoft.AccesoDatos.Data
{
    // Contenedor de Trabajo donde se conectan las capas.
    public class ContenedorTrabajo : IContenedorTrabajo //implementamos la interfas
    {
        private readonly ApplicationDbContext _db;

        public ContenedorTrabajo(ApplicationDbContext db)
        {
            _db = db;
            Veterinario = new VeterinarioRepository(_db);
            Usuario = new UsuarioRepository(_db);
        }
        public IVeterinarioRepository Veterinario { get; private set; }

        public IUsuarioRepository Usuario { get; private set; }
        public void Dispose()
        {
            _db.Dispose();    
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
