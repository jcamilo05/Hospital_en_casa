using System;
using System.Collections.Generic;

namespace TorneoFutbol.App.Dominio
{
    public class Desempenio
    {
        //PartidosJugados
        public int DesempenioID {get; set;}
        public int PartidosJugados { get; set; }
        public int PartidosGanados { get; set; }
        public int PartidosEmpatados { get; set; }
        public int GolesAFavor { get; set; }
        public int GolesEnContra { get; set; }
        public int Puntos { get; set; }
    }

}