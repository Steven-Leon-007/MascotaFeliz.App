using System;
using System.ComponentModel.DataAnnotations;

namespace MascotaFeliz.App.Dominio{
    public class Propietario : Persona {
        [Required, StringLength(50)]
        public string Direccion { get; set;}

    }
}