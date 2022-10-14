using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CorpTak.Models.VievModel
{
    public class listColaboradorViewModel
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string EstadoCivil { get; set; }
        public string GradoAcademico { get; set; }
        public string Direccion { get; set; }

    }   
}