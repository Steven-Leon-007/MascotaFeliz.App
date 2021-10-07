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
    public class EditMascotaModel : PageModel
    {
        private readonly IRepositorioMascota repositorioMascota;
        [BindProperty]
        public Mascota Mascota { get; set; }

        public EditMascotaModel(IRepositorioMascota repositorioMascota)
        {
            this.repositorioMascota = repositorioMascota;
        }
        public IActionResult OnGet(int? mascotaId)
        {
            if(mascotaId.HasValue)
            {
            Mascota = repositorioMascota.GetMascotaPorId(mascotaId.Value);
            }
            else
            {
                Mascota = new Mascota();
            }
            if (Mascota == null)
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
            if(Mascota.Id>0)
            {
              Mascota = repositorioMascota.UpdateMascota(Mascota);  
            }
            else
            {
                repositorioMascota.AddMascota(Mascota);
            }
            return Page();
        }
    }
}
