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
    public class DeleteVisitaModel : PageModel
    {
        private readonly IRepositorioMascota repositorioMascota;
        private readonly IRepositorioVeterinario repositorioVeterinario;
        public IEnumerable<Veterinario> Veterinarios{get;set;}
        public IEnumerable<Mascota> Mascotas{get;set;}
        private readonly IRepositorioVisita repositorioVisita;
        [BindProperty]
        public Visita Visita { get; set; }

        public DeleteVisitaModel()
        {
            this.repositorioVisita = new RepositorioVisita(new MascotaFeliz.App.Persistencia.AppContext());
            this.repositorioVeterinario = new RepositorioVeterinario(new MascotaFeliz.App.Persistencia.AppContext());
            this.repositorioMascota = new RepositorioMascota(new MascotaFeliz.App.Persistencia.AppContext());
        }
        public IActionResult OnGet(int? visitaId)
        {
            Mascotas = repositorioMascota.GetAllMascotas();
            Veterinarios = repositorioVeterinario.GetAllVeterinarios();
            if(visitaId.HasValue)
            {
            Visita = repositorioVisita.GetVisita(visitaId.Value);
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
              repositorioVisita.DeleteVisita(Visita.Id);  
            }
            return Page();
        }
    }
}
