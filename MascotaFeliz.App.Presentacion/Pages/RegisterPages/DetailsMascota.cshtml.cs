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

        public DetailsMascotaModel()
        {
            this.repositorioMascota = new RepositorioMascota(new MascotaFeliz.App.Persistencia.AppContext());
        }
        public IActionResult OnGet(int mascotaId, int propietarioId)
        {
            Mascota = repositorioMascota.GetMascota(mascotaId);
            if (Mascota == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            ViewData["propietario"]=propietarioId;
            return Page();
        }
    }

}
