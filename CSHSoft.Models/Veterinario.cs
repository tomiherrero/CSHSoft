using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CSHSoft.Models
{
    public class Veterinario
    {
        [Key]
        public int IdVeterinario { get; set; }

        [Required(ErrorMessage ="Ingresar nombre")]
        [Display(Name="Razón Social")]
        public string RazonSocial { get; set; }

        [Required(ErrorMessage="Ingresar dirección")]
        [Display(Name="Dirección")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Ingresar horario de atención")]
        [Display(Name = "Horario de Atención")]
        public string HorarioAtencion { get; set; }

        [Required(ErrorMessage = "Ingresar si tiene internación")]
        [Display(Name = "Internación")]
        public int Internacion { get; set; }

        public string Observaciones { get; set; }
    }
}
