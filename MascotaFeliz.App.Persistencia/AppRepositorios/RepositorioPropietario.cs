using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia
{
    public class RepositorioPropietario : IRepositorioPropietario
    {
        private readonly AppContext _appContext;

        public RepositorioPropietario(AppContext appContext)
        {
            _appContext=appContext;
        }
        Propietario IRepositorioPropietario.AddPropietario(Propietario propietario)
        {
            var propietarioAdicionado=_appContext.Propietarios.Add(propietario);
            _appContext.SaveChanges();
            return propietarioAdicionado.Entity;
        }

        void IRepositorioPropietario.DeletePropietario(int idPropietario)
        {
            var propietarioEncontrado=_appContext.Propietarios.FirstOrDefault(p =>p.Id==idPropietario);
            if(propietarioEncontrado==null)
                return;
            _appContext.Propietarios.Remove(propietarioEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Propietario> IRepositorioPropietario.GetAllPropietarios()
        {
            return _appContext.Propietarios;
        }

        Propietario IRepositorioPropietario.GetPropietario(int idPropietario)
        {
            return _appContext.Propietarios.FirstOrDefault(p =>p.Id==idPropietario);

        }

        Propietario IRepositorioPropietario.UpdatePropietario(Propietario propietario, int idPropietario_original)
        {
            var propietarioEncontrado=_appContext.Propietarios.FirstOrDefault(p =>p.Id== idPropietario_original);
            if (propietarioEncontrado==null)
            {
                propietarioEncontrado.Identificacion=propietario.Identificacion;
                propietarioEncontrado.Nombre=propietario.Nombre;
                propietarioEncontrado.Apellidos=propietario.Apellidos;
                propietarioEncontrado.Telefono=propietario.Telefono;
                propietarioEncontrado.Direccion=propietario.Direccion;

                _appContext.SaveChanges();
                
            }
            return propietarioEncontrado;
        }
    }
}