using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TorneoFutbol.App.Dominio
{
    /// <summary>Class <c>Jugador</c>
    /// Modela un Jugador de un equipo 
    /// </summary>   
    public class Jugador 
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        [StringLength(50, MinimumLength = 2, 
        ErrorMessage="El campo {0} debe tener {1} caracteres de máximo y {2} de mínimo")]
        [RegularExpression("[a-zA-Z ]+", ErrorMessage="El campo {0} solo puede recibir letras")]
        public string Nombre{ get; set; } 
        
        [StringLength(10, MinimumLength = 4, 
        ErrorMessage="El campo {0} debe tener {1} caracteres de máximo y {2} de mínimo")]
        [RegularExpression("[0-9]*", ErrorMessage="El campo {0} solo puede recibir números")]
        public string Documento{ get; set; } 

        [StringLength(10, MinimumLength = 4, 
        ErrorMessage="El campo {0} debe tener {1} caracteres de máximo y {2} de mínimo")]
        [RegularExpression("[0-9]*", ErrorMessage="El campo {0} solo puede recibir números")]
        [Display(Name = "Teléfono")]
        public string NumeroTelefono{ get; set; } 

        [RegularExpression("^(\\d?[1-9]|[1-9]0)$", ErrorMessage="El campo {0} solo puede recibir números entre el 1 y el 99")]
        public string Numero { get; set; }
        //se Cambia posicion tipo String a Enum, para el frontend
        public Posicion Posicion { get; set; }
        public Equipo Equipo { set; get; }
        //agregado novedades 
        public ICollection<Novedad> Novedades { get; set; }
    }
}