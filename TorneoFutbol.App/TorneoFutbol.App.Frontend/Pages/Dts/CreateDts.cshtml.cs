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
        private readonly IRepositorioEquipo _repoEquipo;
        public IEnumerable <Equipo> equipos {get;set;}
        private readonly IRepositorioDT _repoDT;
        public DT dt { get; set; }
        public CreateDtsModel(IRepositorioDT repoDt, IRepositorioEquipo repoEquipo)
        {
            _repoDT = repoDt;
            _repoEquipo=repoEquipo;
        }
        public void OnGet()
        {
            equipos=_repoEquipo.GetAllEquipo();
            dt = new DT();
        }

        public IActionResult OnPost(DT dt, int idEquipo)
        {
            
            if (ModelState.IsValid)
            {
                _repoDT.AddDT(dt);
                _repoDT.LinkDT(dt.ID, idEquipo);
                return RedirectToPage("ListDts");
            }
            else
            {
                return Page();
            }            
        }    
    }
}
