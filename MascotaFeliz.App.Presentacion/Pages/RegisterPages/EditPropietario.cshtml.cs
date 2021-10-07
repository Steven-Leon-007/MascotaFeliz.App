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
    public class EditPropietarioModel : PageModel
    {
        private readonly IRepositorioPropietario repositorioPropietario;
        [BindProperty]
        public Propietario Propietario { get; set; }

        public EditPropietarioModel(IRepositorioPropietario repositorioPropietario)
        {
            this.repositorioPropietario = repositorioPropietario;
        }
        public IActionResult OnGet(int? propietarioId)
        {
            if(propietarioId.HasValue)
            {
            Propietario = repositorioPropietario.GetPropietarioPorId(propietarioId.Value);
            }
            else
            {
                Propietario = new Propietario();
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
              Propietario = repositorioPropietario.UpdatePropietario(Propietario);  
            }
            else
            {
                repositorioPropietario.AddPropietario(Propietario);
            }
            return Page();
        }
    }
}
