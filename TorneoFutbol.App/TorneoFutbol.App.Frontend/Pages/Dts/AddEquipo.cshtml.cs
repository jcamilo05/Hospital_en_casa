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
    public class AddEquipoModel : PageModel
    {
        private readonly IRepositorioDT _repoDT;
        private readonly IRepositorioEquipo _repoEquipo;
        public DT dt {get;set;}
        public IEnumerable <Equipo> equipos {get;set;}
        public AddEquipoModel(IRepositorioDT repoDT,IRepositorioEquipo repoEquipo)
        {
            _repoDT= repoDT;
            _repoEquipo=repoEquipo;

        }
        public void OnGet(int id)
        {
            dt = _repoDT.GetDT(id);
            equipos=_repoEquipo.GetAllEquipo();
        }
        public IActionResult OnPost(int idDt, int idEquipo)
        {
            _repoDT.LinkDT(idDt, idEquipo);
            return RedirectToPage("DetailsDts", new{ID = idDt});
        }
    }
}
