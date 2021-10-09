using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TorneoFutbol.App.Persistencia;
using TorneoFutbol.App.Dominio;

namespace TorneoFutbol.App.Frontend.Pages.Partidos
{
    public class IndexModel : PageModel
    {
        private readonly IRepositorioEquipo _repoEquipo;
        private readonly IRepositorioEstadio _repoEstadio;
        private readonly IRepositorioPartido _repoPartido;
        public Municipio municipio { get; set; }
        public IEnumerable<Equipo> equipos { get; set; }
        public IEnumerable<Estadio> estadios { get; set; }

        public IndexModel(IRepositorioEquipo repoEquipo, IRepositorioEstadio repoEstadio)
        {
            
            _repoEquipo = repoEquipo;
            _repoEstadio = repoEstadio;
        }
        
        
        public void OnGet(int id)
        {
            //municipio = _repoMunicipio.GetMunicipio(id);
            equipos = _repoEquipo.GetAllEquipo();
            estadios = _repoEstadio.GetAllEstadio();
            /**
            if (id == Guid.Empty) {
                Label = "Create"; 
            } else {
                Label = "Update";
            }
            */
        }
        
    }
}
