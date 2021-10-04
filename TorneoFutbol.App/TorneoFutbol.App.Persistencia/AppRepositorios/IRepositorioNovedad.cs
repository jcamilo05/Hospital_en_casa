using System.Collections.Generic;
using TorneoFutbol.App.Dominio;

namespace TorneoFutbol.App.Persistencia
{
    public interface IRepositorioNovedad
    {

        Novedad AddNovedad(Novedad novedad);
        Novedad GetNovedad(int idNovedad);
        IEnumerable<Novedad> GetAllNovedad();
        Novedad LinkNovedadPartido(int idNovedad, int idPartido);
        Novedad LinkNovedadJugador(int idNovedad, int idJugador);
    }
}