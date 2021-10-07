using System;
using System.ComponentModel.DataAnnotations;

namespace MascotaFeliz.App.Dominio
{
     /// <summary>Class <c>Persona</c>
     /// Modela una Persona en general en el sistema 
     /// </summary>  
    public class Mascota
    {
        ///Hola:) 
        public int  Id { get; set;}
        [Required, StringLength(50)]
        public string NombreMascota {get; set;}
        [Required, StringLength(50)]
        public string Raza {get;set;}
        [Required, StringLength(50)]
        public Tipo TipoAnimal {get;set;}
        [Required, StringLength(50)]
        public Propietario Propietario {get;set;}

    }
} 