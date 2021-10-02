using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TorneoFutbol.App.Persistencia;
using TorneoFutbol.App.Dominio;

namespace TorneoFutbol.App.Frontend.Pages.Dts
{
    public class ListDtsModel : PageModel
    {
        private readonly IRepositorioDT _repoDT;
        public IEnumerable<DT> dts {get;set;}
        public ListDtsModel(IRepositorioDT repoDt)
        {
            _repoDT= repoDt;
        }
        
        public void OnGet()
        {
           dts=_repoDT.GetAllDT();
        }
    }
}
