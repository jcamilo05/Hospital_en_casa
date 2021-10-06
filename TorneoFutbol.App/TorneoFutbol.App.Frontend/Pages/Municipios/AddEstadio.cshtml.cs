using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TorneoFutbol.App.Persistencia;
using TorneoFutbol.App.Dominio;

namespace TorneoFutbol.App.Frontend.Pages.Municipios
{
    public class AddEstadioModel : PageModel
    {
        private readonly IRepositorioMunicipio _repoMunicipio;
        private readonly IRepositorioEstadio _repoEstadio;
        public Municipio municipio { get; set; }
        public IEnumerable<Estadio> estadios { get; set; }
        public AddEstadioModel(IRepositorioMunicipio repoMunicipio, IRepositorioEstadio repoEstadio)
        {
            _repoMunicipio = repoMunicipio;
            _repoEstadio = repoEstadio;
        }
        
        public void OnGet(int id)
        {
            municipio = _repoMunicipio.GetMunicipio(id);
            estadios = _repoEstadio.GetAllEstadio();
        }
        

        public IActionResult OnPost(int idMunicipio, int idEstadio)
        {
            _repoMunicipio.LinkEstadio(idMunicipio, idEstadio);
            return RedirectToPage("DetailsMunicipios", new { ID = idMunicipio });
        }
        
    }
}
