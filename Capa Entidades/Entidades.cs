using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades
{
    // Capa de Entidades - Usuario.cs
    public class Usuarios
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string ApellidoUsuario { get; set; }
        public DateTime FechaNacimientoUsuario { get; set; }
        public string TipoUsuario { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
    }

    // Capa de Entidades - Edificio.cs
    public class Edificio
    {
        public int IdEdificio { get; set; }
        public string NombreEdificio { get; set; }
    }

    // Capa de Entidades - Aula.cs
    public class Aula
    {
        public int IdAula { get; set; }
        public string NombreAula { get; set; }
        public int EdificioIdAula { get; set; }
    }

    // Capa de Entidades - Visita.cs
    public class Visita
    {
        public int IdVisita { get; set; }
        public string NombreVisita { get; set; }
        public string ApellidoVisita { get; set; }
        public string CarreraVisita { get; set; }
        public string CorreoVisita { get; set; }
        public int EdificioIdVisita { get; set; }
        public string EdificioVisita { get; set; } // Nombre del edificio
        public int AulaIdVisita { get; set; }
        public string AulaVisita { get; set; } // Nombre del aula
        public DateTime HoraEntradaVisita { get; set; }
        public string MotivoVisita { get; set; }
   
    }

}
