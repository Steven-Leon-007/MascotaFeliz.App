using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using MascotaFeliz.App.Dominio;
using MascotaFeliz.App.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MascotaFeliz.App.Presentacion.Pages
{
    public class EditMascotaModel : PageModel
    {
        [BindProperty]
        public Propietario propietario {get;set;}
        private readonly IRepositorioMascota repositorioMascota;
        public IRepositorioPropietario repositorioPropietario;
        [BindProperty]
        public Mascota mascota { get; set; }
        public EditMascotaModel()
        {
            this.repositorioMascota = new RepositorioMascota(new MascotaFeliz.App.Persistencia.AppContext());
            this.repositorioPropietario = new RepositorioPropietario(new MascotaFeliz.App.Persistencia.AppContext());
        }
        public IActionResult OnGet(int? mascotaId, int? propietarioId)
        {
            if(mascotaId.HasValue && propietarioId.HasValue)
            {
            propietario = repositorioPropietario.GetPropietario(propietarioId.Value);
            mascota = repositorioMascota.GetMascota(mascotaId.Value);
            }
            else
            {
                if (propietarioId.HasValue)
                {
                    propietario = repositorioPropietario.GetPropietario(propietarioId.Value);
                }
                else
                {
                    return RedirectToPage("./PropietarioReg");
                }
                mascota = new Mascota();
            }
            if (mascota == null || propietario == null)
            {
                return RedirectToPage("./PropietarioReg");
            }
            else
            ViewData["propietario"] = propietarioId.Value;
            return Page();
        }

        public IActionResult OnPost()
        {
            propietario = repositorioPropietario.GetPropietario(int.Parse(Request.Form["propietarioId"]));
            if (!ModelState.IsValid)
            {
                Console.WriteLine("no valido");
                return Page();
            }
            if (mascota.Id > 0)
            {
                var mascotae = repositorioMascota.UpdateMascota(mascota);
                ViewData["Respuesta"] = Alerts.ShowAlert(Alert.Success, "<span><strong>" + mascotae.NombreMascota + "</strong> fue modificado correctamente.</span>");
            }
            else
            {
                if (propietario != null)
                {
                    if (propietario.Mascotas != null)
                    {
                        propietario.Mascotas.Add(mascota);
                        repositorioPropietario.UpdatePropietario(propietario);
                        ViewData["Respuesta"] = Alerts.ShowAlert(Alert.Primary, "<span><strong>" + mascota.NombreMascota + "</strong> se agregó una nueva mascota para " + propietario.Nombre + " " + propietario.Apellidos + ".</span>");
                    }
                    else
                    {
                        propietario.Mascotas = new List<Mascota>(){mascota};
                        Console.WriteLine(JsonSerializer.Serialize(propietario));
                        repositorioPropietario.UpdatePropietario(propietario);
                        ViewData["Respuesta"] = Alerts.ShowAlert(Alert.Primary, "<span><strong>" + mascota.NombreMascota + "</strong> se agregó a la lista de mascotas de " + propietario.Nombre + " " + propietario.Apellidos + ".</span>");
                    }
                }
            }
            ViewData["propietario"] = propietario.Id;
            return Page();
        }
    }

}
