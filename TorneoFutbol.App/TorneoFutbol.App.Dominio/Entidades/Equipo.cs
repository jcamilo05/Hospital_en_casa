using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace TorneoFutbol.App.Dominio
{
     /// <summary>Class <c>Equipo</c>
     /// Modela una Equipo en general en el sistema 
     /// </summary>        
    public class Equipo
    {
        // Identificador único de cada persona
        public int ID { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        [StringLength(50, MinimumLength = 2, 
        ErrorMessage="El campo {0} debe tener {1} caracteres de máximo y {2} de mínimo")]
        [RegularExpression("[a-zA-Z ]+", ErrorMessage="El campo {0} solo puede recibir letras")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        [StringLength(50, MinimumLength = 2, 
        ErrorMessage="El campo {0} debe tener {1} caracteres de máximo y {2} de mínimo")]
        [RegularExpression("[a-zA-Z ]+", ErrorMessage="El campo {0} solo puede recibir letras")]
        public Municipio Municipio { get; set; } 
        [Display(Name = "Desempeño")]
        public Desempeno Desempeno {get;set;}

        public ICollection<Jugador> Jugadores { get; set; } 
    }
}