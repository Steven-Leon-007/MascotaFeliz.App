using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MascotaFeliz.App.Dominio{

    public class Veterinario : Persona { 
        [Required, StringLength(50)]
        public string TarjetaProfesional { get; set;}
        public List<Visita> Visitas{get;set;}
    }
}