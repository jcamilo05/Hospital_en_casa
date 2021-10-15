using System;
using System.ComponentModel.DataAnnotations;
namespace TorneoFutbol.App.Dominio
{
    /// <summary>Class <c>Municipio</c>
    /// Modela un Municipio 
    /// </summary>   
    public class Municipio 
    {
        /// Id de cada municipio 
        public int ID { get; set; }    
        ///Nombre del municipio 
        [Required, StringLength(50)]
        public string Nombre { get; set; }

        ///Nombre del departamento 
        [Required, StringLength(50)]
        public string Departamento { get; set; }
        public Estadio Estadio {get; set;}
    }
}