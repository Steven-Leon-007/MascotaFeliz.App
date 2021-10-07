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
    public class DetailsPropietarioModel : PageModel
    {
        private readonly IRepositorioPropietario repositorioPropietario;
        public Propietario Propietario { get; set; }

        public DetailsPropietarioModel(IRepositorioPropietario repositorioPropietario)
        {
            this.repositorioPropietario = repositorioPropietario;
        }

        public IActionResult OnGet(int propietarioId)
        {

            Propietario = repositorioPropietario.GetPropietarioPorId(propietarioId);
            if (Propietario == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
                return Page();
        }
    }
}