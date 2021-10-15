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
    public class DeletePropietarioModel : PageModel
    {
        private readonly IRepositorioPropietario repositorioPropietario;
        [BindProperty]
        public Propietario Propietario { get; set; }

        public DeletePropietarioModel()
        {
            this.repositorioPropietario = new RepositorioPropietario(new MascotaFeliz.App.Persistencia.AppContext());
        }
        public IActionResult OnGet(int? propietarioId)
        {
            if(propietarioId.HasValue)
            {
            Propietario = repositorioPropietario.GetPropietario(propietarioId.Value);
            }
            if (Propietario == null)
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
            if(Propietario.Id>0)
            {
                repositorioPropietario.DeletePropietario(Propietario.Id);
            }
            return Page();
        }
    }
}
