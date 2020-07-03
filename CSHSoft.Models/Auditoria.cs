using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CSHSoft.Models
{

    public class Auditoria
    {
        [Key]
        public int idAuditoria { get; set; }
        public string nombreUsuario { get; set; }
        public DateTime fecha { get; set; }
        public string accion { get; set; }
        //public Auditoria()
        //{

        //}
  
        //public Auditoria(string nombre, DateTime fecha, string accion )
        //{
        //    Auditoria auditoria = new Auditoria();
        //    auditoria.nombreUsuario = nombre;
        //    auditoria.fecha = fecha;
        //    auditoria.accion = accion;
        //}
    }
}
