using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace MascotaFeliz.App.Persistencia
{
    public class RepositorioVeterinario : IRepositorioVeterinario
    {
        private readonly AppContext _appContext;

        public RepositorioVeterinario(AppContext appContext)
        {
            _appContext=appContext;
        }
        Veterinario IRepositorioVeterinario.AddVeterinario(Veterinario nuevoVeterinario)
        {
            var veterinarioAdicionado=_appContext.Veterinarios.Add(nuevoVeterinario);
            _appContext.SaveChanges();
            return veterinarioAdicionado.Entity;
        }

        void IRepositorioVeterinario.DeleteVeterinario(int idVeterinario)
        {
            var veterinarioEncontrado=_appContext.Veterinarios.FirstOrDefault(p =>p.Id==idVeterinario);
            if(veterinarioEncontrado==null)
                return;
            _appContext.Veterinarios.Remove(veterinarioEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Veterinario> IRepositorioVeterinario.GetAllVeterinarios()
        {
            return _appContext.Veterinarios.Include(p=>p.Visitas);
        }

        Veterinario IRepositorioVeterinario.GetVeterinario(int idVeterinario)
        {
            return _appContext.Veterinarios.Where(p => p.Id == idVeterinario).Include(p=>p.Visitas).FirstOrDefault();

        }

        Veterinario IRepositorioVeterinario.UpdateVeterinario(Veterinario veterinarioActualizado)
        {
            var veterinarioEncontrado=_appContext.Veterinarios.FirstOrDefault(p =>p.Id== veterinarioActualizado.Id);
            if (veterinarioEncontrado!=null)
            {
                veterinarioEncontrado.Id = veterinarioActualizado.Id;
                veterinarioEncontrado.Identificacion=veterinarioActualizado.Identificacion;
                veterinarioEncontrado.Nombre=veterinarioActualizado.Nombre;
                veterinarioEncontrado.Apellidos=veterinarioActualizado.Apellidos;
                veterinarioEncontrado.Telefono=veterinarioActualizado.Telefono;
                veterinarioEncontrado.TarjetaProfesional=veterinarioActualizado.TarjetaProfesional;
                veterinarioEncontrado.Visitas = veterinarioActualizado.Visitas;

                _appContext.SaveChanges();
                
            }
            return veterinarioEncontrado;
        }
        IEnumerable<Veterinario> IRepositorioVeterinario.SearchVeterinarios(string nombre)
        {
            return _appContext.Veterinarios
                        .Where(p => p.Nombre.Contains(nombre));
        }

    }

}