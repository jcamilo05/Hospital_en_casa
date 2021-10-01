using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TorneoFutbol.App.Persistencia;
using TorneoFutbol.App.Dominio;

namespace TorneoFutbol.App.Frontend.Pages.Estadios
{
    public class ListEstadiosModel : PageModel
    {
        private readonly IRepositorioEstadio _repoEstadio;
        public IEnumerable<Estadio> estadios {get;set;}
        public ListModel(IRepositorioEstadio repoEstadio)
        {
            _repoEstadio= repoEstadio;
        }  
        public void OnGet()
        {
            estadios = _repoEstadio.GetAllEstadio();
        }
    }
}
