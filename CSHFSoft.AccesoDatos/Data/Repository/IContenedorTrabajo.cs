using System;
using System.Collections.Generic;
using System.Text;

namespace CSHFSoft.AccesoDatos.Data.Repository
{
    public interface IContenedorTrabajo : IDisposable
    {
        IVeterinarioRepository Veterinario { get; }


        void Save();

    }
}
