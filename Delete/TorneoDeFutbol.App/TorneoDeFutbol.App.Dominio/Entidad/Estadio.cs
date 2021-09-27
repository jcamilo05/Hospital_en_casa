using System;
namespace TorneoDeFutbol.App.Dominio
{
    /// <summary>Class <c>Estadio</c>
    /// Modela un Estadio 
    /// </summary>   
    public class Estadio 
    {
        /// Id de cada municipio 
        public int Id { get; set; }    
        ///Nombre del municipio 
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public Municipio Ciudad { get; set; }
        ///Nombre del departamento 
    }
}