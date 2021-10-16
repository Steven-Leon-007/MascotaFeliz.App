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
        [BindProperty(SupportsGet = true)]
        public int propietarioId {get;set;}
        private readonly IRepositorioMascota repositorioMascota;
         [BindProperty(SupportsGet = true)]
        public IEnumerable<Propietario> Propietarios{get;set;}
        public IRepositorioPropietario repositorioPropietario;
        [BindProperty]
        public Mascota Mascota { get; set; }
        public EditMascotaModel()
        {
            this.repositorioMascota = new RepositorioMascota(new MascotaFeliz.App.Persistencia.AppContext());
            this.repositorioPropietario = new RepositorioPropietario(new MascotaFeliz.App.Persistencia.AppContext());
        }
        public IActionResult OnGet(int? mascotaId)
        {
            Propietarios = repositorioPropietario.GetAllPropietarios();
            if(mascotaId.HasValue)
            {
            Mascota = repositorioMascota.GetMascota(mascotaId.Value);
            propietarioId = Mascota.Propietario.Id; 
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
            Propietarios = repositorioPropietario.GetAllPropietarios(); 
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
                repositorioMascota.AsignarPropietario(Mascota, propietarioId);
                repositorioMascota.AddMascota(Mascota);
            }
            return Page();
        }
    }

}
