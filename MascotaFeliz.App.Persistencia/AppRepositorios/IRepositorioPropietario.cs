using System;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia
{
    public interface IRepositorioPropietario
    {
        IEnumerable<Propietario> GetAllPropietarios();
        Propietario AddPropietario(Propietario propietario);
        Propietario UpdatePropietario(Propietario propietario, int idPropietario_original);//modificada por mi para que funcionara
        void DeletePropietario(int idPropietario);    
        Propietario GetPropietario(int idPropietario);
        //Medico AsignarMedico(int idPaciente, int idMedico); 
    }
}