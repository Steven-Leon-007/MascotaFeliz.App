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

        public EditPropietarioModel()
        {
            this.repositorioPropietario = new RepositorioPropietario(new MascotaFeliz.App.Persistencia.AppContext());
        }
        public IActionResult OnGet(int? propietarioId)
        {
            if(propietarioId.HasValue)
            {
            Propietario = repositorioPropietario.GetPropietario(propietarioId.Value);
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
              var propietario = repositorioPropietario.UpdatePropietario(Propietario); 
              ViewData["Respuesta"] = Alerts.ShowAlert(Alert.Success, "<span><strong>"+propietario.Nombre+" "+propietario.Apellidos+"</strong> fue modificado correctamente.</span>");
            }
            else
            {
               var propietario = repositorioPropietario.AddPropietario(Propietario);
                ViewData["Respuesta"] = Alerts.ShowAlert(Alert.Primary, "<span><strong>"+propietario.Nombre+" "+propietario.Apellidos+"</strong> se agregó a la lista de propietarios.</span>");
            }
            return Page();
        }
    }

}
