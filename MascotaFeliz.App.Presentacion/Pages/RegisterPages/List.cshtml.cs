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
    public class ListModel : PageModel
    {
        private readonly IRepositorioVeterinario repositorioVeterinario;
        private readonly IRepositorioPropietario repositorioPropietario;
        private readonly IRepositorioMascota repositorioMascota;
        private readonly IRepositorioVisita repositorioVisita;
        public IEnumerable<Veterinario> Veterinarios{get;set;}
        public IEnumerable<Propietario> Propietarios {get;set;}
        public IEnumerable<Mascota> Mascotas {get; set;}
        public IEnumerable<Visita> Visitas {get;set;}
        public ListModel(IRepositorioVeterinario repositorioVeterinario, IRepositorioPropietario repositorioPropietario, IRepositorioMascota repositorioMascota, IRepositorioVisita repositorioVisita)
        {
            this.repositorioVeterinario= repositorioVeterinario;
            this.repositorioPropietario = repositorioPropietario;
            this.repositorioMascota = repositorioMascota;
            this.repositorioVisita = repositorioVisita;
        }
        public void OnGet()
        {
            Veterinarios = repositorioVeterinario.GetAllVeterinarios();
            Propietarios = repositorioPropietario.GetAllPropietarios();
            Mascotas = repositorioMascota.GetAllMascotas();
            Visitas = repositorioVisita.GetAllVisitas();
        }
    }
}
