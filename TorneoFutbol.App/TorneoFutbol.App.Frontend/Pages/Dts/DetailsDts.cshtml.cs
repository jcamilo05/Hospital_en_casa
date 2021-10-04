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
    public class DetailsDtsModel : PageModel
    {
        private readonly IRepositorioDT _repoDT;
        public DT dt { get; set; }
        public DetailsDtsModel(IRepositorioDT repoDt)
        {
            _repoDT = repoDt;
        }
        public IActionResult OnGet(int id)
        {
            dt = _repoDT.GetDT(id); 
            if (dt == null)
            {
                return NotFound();
            }
            else
            {
                return Page();
            }
        }
    }
}
