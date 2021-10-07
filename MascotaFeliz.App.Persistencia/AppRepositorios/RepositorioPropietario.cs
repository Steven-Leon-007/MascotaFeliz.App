using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia
{
    public class RepositorioPropietario : IRepositorioPropietario
    {
        static public List<Propietario> propietarios;
        private readonly AppContext _appContext;

        public RepositorioPropietario(AppContext appContext)
        {
            _appContext=appContext;
        }
        public RepositorioPropietario()
        {
            propietarios = new List<Propietario>()
            {
                new Propietario{Id=1,Identificacion="1003456764",Nombre="Juan",Apellidos="Gomez Diaz",Telefono="321456876",Direccion="Cra 37 # 28-12"},
                new Propietario{Id=2,Identificacion="37829374",Nombre="Ana María",Apellidos="Gonzales Rodriguez",Telefono="3224865942", Direccion="Cll 12 # 45-103"},
                new Propietario{Id=3,Identificacion="1118932932",Nombre="Carlos",Apellidos="Sánchez",Telefono="3002568545", Direccion="Cra 10 # 15-87 - Apto 304"},
                new Propietario{Id=4,Identificacion="1023434532",Nombre="Gloria",Apellidos="Chaparro Alvarez",Telefono="3143590845", Direccion="Cra 20 # 27-18"}
            };
        }
        public Propietario GetPropietarioPorId(int propietarioId)
        {
            return propietarios.SingleOrDefault(p => p.Id ==propietarioId);
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
            //return _appContext.Propietarios;
            return propietarios;
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