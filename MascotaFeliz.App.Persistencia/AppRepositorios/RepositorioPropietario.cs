using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace MascotaFeliz.App.Persistencia
{
    public class RepositorioPropietario : IRepositorioPropietario
    {
        private readonly AppContext _appContext;

        public RepositorioPropietario(AppContext appContext)
        {
            _appContext=appContext;
        }
        Propietario IRepositorioPropietario.AddPropietario(Propietario nuevoPropietario)
        {
            var propietarioAdicionado=_appContext.Propietarios.Add(nuevoPropietario);
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
            return _appContext.Propietarios.Include(p=>p.Mascotas);
        }

        Propietario IRepositorioPropietario.GetPropietario(int idPropietario)
        {
            return _appContext.Propietarios.Where(p => p.Id == idPropietario).Include(p=>p.Mascotas).FirstOrDefault();

        }

        Propietario IRepositorioPropietario.UpdatePropietario(Propietario propietarioActualizado)
        {
            var propietarioEncontrado=_appContext.Propietarios.FirstOrDefault(p =>p.Id== propietarioActualizado.Id);
            if (propietarioEncontrado!=null)
            {
                propietarioEncontrado.Id = propietarioActualizado.Id;
                propietarioEncontrado.Identificacion=propietarioActualizado.Identificacion;
                propietarioEncontrado.Nombre=propietarioActualizado.Nombre;
                propietarioEncontrado.Apellidos=propietarioActualizado.Apellidos;
                propietarioEncontrado.Telefono=propietarioActualizado.Telefono;
                propietarioEncontrado.Direccion=propietarioActualizado.Direccion;
                propietarioEncontrado.Mascotas = propietarioActualizado.Mascotas;

                _appContext.SaveChanges();
                
            }
            return propietarioEncontrado;
        }
        IEnumerable<Propietario> IRepositorioPropietario.SearchPropietarios(string nombre)
        {
            return _appContext.Propietarios
                        .Where(p => p.Nombre.Contains(nombre));
        }
        IEnumerable<Propietario> IRepositorioPropietario.SearchPropietarioxId(string iden)
        {
            return _appContext.Propietarios
                        .Where(p => p.Identificacion.Contains(iden));
        }

    }

}