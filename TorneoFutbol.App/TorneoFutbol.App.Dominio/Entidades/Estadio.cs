using System;
namespace TorneoFutbol.App.Dominio
{
    /// <summary>Class <c>Estadio</c>
    /// Modela un Estadio 
    /// </summary>   
    public class Estadio 
    {
        /// Id de cada municipio 
        public int ID { get; set; }    
        ///Nombre del municipio 
        public string Nombre { get; set; }
        ///Nombre del departamento 
        public string Direccion { get; set; }
        
    }
}