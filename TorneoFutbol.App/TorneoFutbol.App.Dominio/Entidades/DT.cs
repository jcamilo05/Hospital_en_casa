using System;
namespace TorneoFutbol.App.Dominio
{
    /// <summary>Class <c> DT</c>
    /// Modela un director tecnico  
    /// </summary>   
    public class DT
    {
  
        public int ID { get; set; }
        public string Nombre{ get; set; } 
        public string Documento{ get; set; } 
        public string NumeroTelefono{ get; set; } 
        public Equipo Equipo { set; get; }

    }
}