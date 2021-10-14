using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MascotaFeliz.App.Dominio;
using MascotaFeliz.App.Persistencia;

namespace MascotaFeliz.App.Presentacion.Pages
{
    public class DetailsVisitaModel : PageModel
    {
        private readonly IRepositorioVisita repositorioVisita;
        public Visita Visita { get; set; }

        public DetailsVisitaModel()
        {
            this.repositorioVisita =new RepositorioVisita(new MascotaFeliz.App.Persistencia.AppContext());
        }

        public IActionResult OnGet(int visitaId)
        {

            Visita = repositorioVisita.GetVisita(visitaId);
            if (Visita == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
                return Page();
        }
    }

}
