using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace MascotaFeliz.App.Dominio{
    public class Propietario : Persona {
        [Required, StringLength(50)]
        public string Direccion {get;set;}
        public List<Mascota> Mascotas{get;set;}

    }
}