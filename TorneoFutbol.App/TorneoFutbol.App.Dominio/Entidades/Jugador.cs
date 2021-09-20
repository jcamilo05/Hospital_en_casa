using System;
namespace TorneoFutbol.App.Dominio
{
    /// <summary>Class <c>Jugador</c>
    /// Modela un Jugador de un equipo 
    /// </summary>   
    public class Jugador : Persona
    {
        /// Numero del jugador (Observar bien si lo ponemos como string o entero)
        public string Numero { get; set; }
        /// Posicion de juego del jugador
        public string Posicion { get; set; }
    }
}