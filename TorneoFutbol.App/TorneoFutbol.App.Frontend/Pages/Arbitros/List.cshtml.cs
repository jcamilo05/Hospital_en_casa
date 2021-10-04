using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TorneoFutbol.App.Persistencia;
using TorneoFutbol.App.Dominio;

namespace TorneoFutbol.App.Frontend.Pages.Arbitros
{
    public class ListModel : PageModel
    {
        private readonly IRepositorioArbitro _repoArbitro;
        public IEnumerable<Arbitro> arbitros {get;set;}
        public ListModel(IRepositorioArbitro repoArbitro)
        {
            _repoArbitro= repoArbitro;
        }            
        public void OnGet()
        {
            arbitros=_repoArbitro.GetAllArbitro();
        }
    }
}
