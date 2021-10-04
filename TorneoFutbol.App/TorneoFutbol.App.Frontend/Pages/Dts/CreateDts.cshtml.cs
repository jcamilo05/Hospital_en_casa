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
    public class CreateDtsModel : PageModel
    {
        private readonly IRepositorioDT _repoDT;
        public DT dt { get; set; }
        public CreateDtsModel(IRepositorioDT repoDt)
        {
            _repoDT = repoDt;
        }
        public void OnGet()
        {
            dt = new DT();
        }

        public IActionResult OnPost(DT dt)
        {
            _repoDT.AddDT(dt);
            return RedirectToPage("ListDts");
        }    
    }
}
