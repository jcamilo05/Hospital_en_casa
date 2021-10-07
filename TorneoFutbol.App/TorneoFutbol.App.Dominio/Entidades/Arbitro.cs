using System;
using System.ComponentModel.DataAnnotations;
namespace TorneoFutbol.App.Dominio
{
    /// <summary>Class <c>Arbitro</c>
    /// Modela un Arbitro 
    /// </summary>   
    public class Arbitro  
    {
        
        public int ID { get; set; }

        [Required(ErrorMessage = "{0} es un campo obligatorio")]
        [StringLength(50, MinimumLength = 10, 
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

        [StringLength(50, MinimumLength = 10, 
        ErrorMessage="El campo {0} debe tener {1} caracteres de máximo y {2} de mínimo")]
        public string Colegio { get; set; }    

    }
}