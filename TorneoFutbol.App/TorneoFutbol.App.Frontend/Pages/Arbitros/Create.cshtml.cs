using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TorneoFutbol.App.Persistencia;
using TorneoFutbol.App.Dominio;
using Microsoft.AspNetCore.Authorization;

namespace TorneoFutbol.App.Frontend.Pages.Arbitros
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly IRepositorioArbitro _repoArbitro;
        public Arbitro arbitro { get; set; }
        public CreateModel(IRepositorioArbitro repoArbitro)
        {
            _repoArbitro = repoArbitro;
        }
        public void OnGet()
        {
            arbitro = new Arbitro();
        }
        public IActionResult OnPost(Arbitro arbitro)
        {
            if(ModelState.IsValid)
            {
                _repoArbitro.AddArbitro(arbitro);
                return RedirectToPage("List");
            }
            else
            {
                return Page();
            }
        }
    }
}
