using System;
using System.ComponentModel.DataAnnotations;

namespace   MascotaFeliz.App.Dominio{

    /// <summary>Class <c>Persona</c>
     /// Modela una Persona en general en el sistema 
     /// </summary>   

    public class Persona
    {
        public int Id {get;set;}
        [Required, StringLength(50)]
        public string Identificacion {get; set;}
        [Required, StringLength(50)]
        public string Nombre {get;set;}
        [Required, StringLength(50)]
        public string Apellidos {get;set;}
        [Required, StringLength(50)]
        public string Telefono {get;set;}
    
    }

}