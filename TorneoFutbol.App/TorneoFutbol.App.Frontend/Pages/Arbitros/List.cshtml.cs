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
        public string colArbitro {set; get;}
        private readonly IRepositorioArbitro _repoArbitro;
        public IEnumerable<Arbitro> arbitros {get;set;}
        public ListModel(IRepositorioArbitro repoArbitro)
        {
            _repoArbitro= repoArbitro;
        }            

        public void OnGet(string col)
        {
            if(string.IsNullOrEmpty(col))
            {
                colArbitro = "";
                arbitros=_repoArbitro.GetAllArbitro();
            }
            else
            {
                colArbitro = col;
                arbitros=_repoArbitro.GetArbitroOnColegio(col);
            }
        }
    }
}
