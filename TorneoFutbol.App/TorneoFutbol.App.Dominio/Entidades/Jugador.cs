using System;
using System.Collections.Generic;

namespace TorneoFutbol.App.Dominio
{
    /// <summary>Class <c>Jugador</c>
    /// Modela un Jugador de un equipo 
    /// </summary>   
    public class Jugador 
    {
        public int ID { get; set; }
        public string Nombre{ get; set; } 
        public string Documento{ get; set; } 
        public string NumeroTelefono{ get; set; } 
        public string Numero { get; set; }
        public string Posicion { get; set; }
        public Equipo Equipo { set; get; }
        //agregado novedades 
        public ICollection<Novedad> Novedades { get; set; }
    }
}