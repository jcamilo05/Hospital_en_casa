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
        
        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        [StringLength(50, MinimumLength = 2, 
        ErrorMessage="El campo {0} debe tener {1} caracteres de máximo y {2} de mínimo")]
        public string Nombre { get; set; }

        ///Nombre del departamento 
        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        [StringLength(50, MinimumLength = 2, 
        ErrorMessage="El campo {0} debe tener {1} caracteres de máximo y {2} de mínimo")]
        public string Departamento { get; set; }
        public Estadio Estadio {get; set;}
    }
}