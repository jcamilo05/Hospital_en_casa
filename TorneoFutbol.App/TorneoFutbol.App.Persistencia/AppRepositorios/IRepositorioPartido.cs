using System.Collections.Generic;
using TorneoFutbol.App.Dominio;

namespace TorneoFutbol.App.Persistencia
{
    public interface IRepositorioPartido
    {
        
        Partido AddPartido(Partido partido);

        Partido GetPartido(int idPartido);
        IEnumerable<Partido> GetAllPartido();
        IEnumerable<Partido> GetTblPartido();
        Partido LinkLocal(int idPartido, int idEquipo);
        Partido LinkVisitante(int idPartido, int idEquipo);
        Partido LinkEstadioPartido(int idPartido, int idEstadio);
        Partido LinkArbitroPartido(int idPartido, int idArbitro);

        //TODO, BUSCAR COMO INSERTAR TODAS LAS NOVEDADES DE UN PARTIDO EN UNA LISTA 
        //IEnumerable<Novedad> GetAllNovedadesPartido();
    }
}