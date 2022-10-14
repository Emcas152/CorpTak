using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CorpTak.Models.VievModel
{
    public class ColaboradorViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Nombres")]
        public string Nombres { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }
        [Required]
        [Display(Name = "Estado civil")]
        public string EstadoCivil { get; set; }
        [Required]
        [Display(Name = "Grado academico")]
        public string GradoAcademico { get; set; }
        [Required]
        [Display(Name = "Direccion")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public string Direccion { get; set; }
        public string JSON { get; set; }
    }
}