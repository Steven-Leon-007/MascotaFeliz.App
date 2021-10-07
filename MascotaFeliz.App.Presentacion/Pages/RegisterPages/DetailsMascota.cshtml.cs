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
    public class DetailsMascotaModel : PageModel
    {
        private readonly IRepositorioMascota repositorioMascota;
        public Mascota Mascota { get; set; }

        public DetailsMascotaModel(IRepositorioMascota repositorioMascota)
        {
            this.repositorioMascota = repositorioMascota;
        }
        public IActionResult OnGet(int mascotaId)
        {
            Mascota = repositorioMascota.GetMascotaPorId(mascotaId);
            if (Mascota == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
                return Page();
        }
    }
}
