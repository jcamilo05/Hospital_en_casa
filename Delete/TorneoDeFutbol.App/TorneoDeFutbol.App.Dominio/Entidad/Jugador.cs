using System;
using System.Collections.Generic;
namespace TorneoDeFutbol.App.Dominio
{
    /// <summary>Class <c>Jugador</c>
    /// Modela un Jugador de un equipo 
    /// </summary>   
    public class Jugador : Persona
    {
        /// Numero del jugador 
        public string Numero { get; set; }
        /// Posicion de juego del jugador
        public Posicion Posicion { get; set; }
    }
}