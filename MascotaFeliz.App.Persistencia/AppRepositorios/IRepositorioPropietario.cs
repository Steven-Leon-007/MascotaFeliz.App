using System;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia
{
    public interface IRepositorioPropietario
    {
        IEnumerable<Propietario> GetAllPropietarios();
        Propietario AddPropietario(Propietario nuevoPropietario);
        Propietario UpdatePropietario(Propietario propietarioActualizado);
        void DeletePropietario(int idPropietario);    
        Propietario GetPropietario(int idPropietario);
    }

}