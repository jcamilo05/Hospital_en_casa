using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TorneoFutbol.App.Dominio;
using TorneoFutbol.App.Persistencia;
using Microsoft.AspNetCore.Authorization;
namespace TorneoFutbol.App.Frontend.Pages.Arbitros
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly IRepositorioArbitro _repoArbitro;

        public Arbitro arbitro { get; set; }

        public EditModel(IRepositorioArbitro repoArbitro)
        {
            _repoArbitro = repoArbitro;
        }

        public IActionResult OnGet(int id)
        {
            arbitro = _repoArbitro.GetArbitro(id);
            if (arbitro == null)
            {
                return NotFound();
            }
            else
            {
                return Page();
            }
        }

        public IActionResult OnPost(Arbitro arbitro)
        {
            if (ModelState.IsValid)
            {
                _repoArbitro.UpdateArbitro (arbitro);
                return RedirectToPage("List");
            }
            else
            {
                return Page();
            }
        }
    }
}
