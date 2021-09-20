using System;
using System.Collections.Generic;
namespace TorneoFutbol.App.Dominio

{
     /// <summary>Class <c>Persona</c>
     /// Modela una Persona en general en el sistema 
     /// </summary>        
    public class Novedad
    {
        // Tarjetas registradas en un partido
        public int ID{get;set;}
        public string TarjetaAmarilla{get;set;}
        public string TarjetaRoja{get;set;}
        //id de persona
        public DateTime time {get;set;}
    }

}