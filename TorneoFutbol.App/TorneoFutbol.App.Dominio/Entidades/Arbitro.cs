using System;
//using System.ComponentModel.DataAnnotations;
namespace TorneoFutbol.App.Dominio
{
    /// <summary>Class <c>Arbitro</c>
    /// Modela un Arbitro 
    /// </summary>   
    public class Arbitro  
    {

        public int ID { get; set; }
        public string Nombre{ get; set; } 
        public string Documento{ get; set; } 
        
       // [Display(Name = "Número telefonico")]
        public string NumeroTelefono{ get; set; } 
        public string Colegio { get; set; }    

    }
}