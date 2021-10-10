using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MascotaFeliz.App.Dominio;
using MascotaFeliz.App.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MascotaFeliz.App.Presentacion.Pages
{
    public class EditVisitaModel : PageModel
    
    {
        public IEnumerable<Mascota> Mascotas = RepositorioMascota.mascotas;
        public IEnumerable<Veterinario> Veterinarios = RepositorioVeterinario.veterinarios;
        private readonly IRepositorioVisita repositorioVisita;
        [BindProperty]
        public Visita Visita { get; set; }

        public EditVisitaModel(IRepositorioVisita repositorioVisita)
        {
            this.repositorioVisita = repositorioVisita;
        }
        public IActionResult OnGet(int? visitaId)
        {
            if(visitaId.HasValue)
            {
            Visita = repositorioVisita.GetVisitaPorId(visitaId.Value);
            }
            else
            {
                Visita = new Visita();
            }
            if (Visita == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
                return Page();
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            if(Visita.Id>0)
            {
              Visita = repositorioVisita.UpdateVisita(Visita);  
            }
            else
            {
                repositorioVisita.AddVisita(Visita);
            }
            return Page();
        }
    }
}
