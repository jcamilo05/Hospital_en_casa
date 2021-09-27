using System;
using System.Collections.Generic;
namespace TorneoDeFutbol.App.Dominio
{
     /// <summary>Class <c>Equipo</c>
     /// Modela una Equipo en general en el sistema 
     /// </summary>        
    public class Partido
    {
        // Identificador único de cada persona
        public int Id { get; set; }
        public DateTime FechaHora { get; set; }
        public string EquipoLocal { get; set; }
        public string EquipoVisitante { get; set; }
        public int MarcadorInicialVisitante { get; set; }
        public int MarcadorInicialLocal { get; set; }
        public List<Estadio> Estadio { get; set; }
        public List<Arbitro> Arbitro { get; set;}
    }
}