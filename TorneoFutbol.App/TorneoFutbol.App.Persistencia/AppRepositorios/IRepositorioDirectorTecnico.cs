using System.Collections.Generic;
using TorneoFutbol.App.Dominio;

namespace TorneoFutbol.App.Persistencia
{
    public interface IRepositorioDirectorTecnico
    {
        IEnumerable<DirectorTecnico> GetAllDirectorTecnicos();
        DirectorTecnico AddDirectorTecnico(DirectorTecnico directorTecnico);
        DirectorTecnico UpdateDirectorTecnico(DirectorTecnico directorTecnico);
        void DeleteDirectorTecnico(int idDirectorTecnico);
        DirectorTecnico GetDirectorTecnico(int idDirectorTecnico);
    }

}