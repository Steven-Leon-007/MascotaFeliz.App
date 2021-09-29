using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia
{
    public class RepositorioVeterinario : IRepositorioVeterinario
    {
        private readonly AppContext _appContext;

        public RepositorioVeterinario(AppContext appContext)
        {
            _appContext=appContext;
        }
        Veterinario IRepositorioVeterinario.AddVeterinario(Veterinario veterinario)
        {
            var veterinarioAdicionado=_appContext.Veterinarios.Add(veterinario);
            _appContext.SaveChanges();
            return veterinarioAdicionado.Entity;
        }

        void IRepositorioVeterinario.DeleteVeterinario(int IdVeterinario)
        {
            var veterinarioEncontrado=_appContext.Veterinarios.FirstOrDefault(v =>v.Id==IdVeterinario);
            if(veterinarioEncontrado==null)
                return;
            _appContext.Veterinarios.Remove(veterinarioEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Veterinario> IRepositorioVeterinario.GetAllVeterinarios()
        {
            return _appContext.Veterinarios;
        }

        Veterinario IRepositorioVeterinario.GetVeterinario(int IdVeterinario)
        {
            return _appContext.Veterinarios.FirstOrDefault(v =>v.Id==IdVeterinario);

        }

        Veterinario IRepositorioVeterinario.UpdateVeterinario(Veterinario veterinario, int idVeterinario_original)
        {
            var veterinarioEncontrado=_appContext.Veterinarios.FirstOrDefault(v => v.Id == idVeterinario_original);
            if (veterinarioEncontrado==null)
            {
                veterinarioEncontrado.Identificacion=veterinario.Identificacion;
                veterinarioEncontrado.Nombre=veterinario.Nombre;
                veterinarioEncontrado.Apellidos=veterinario.Apellidos;
                veterinarioEncontrado.Telefono=veterinario.Telefono;
                veterinarioEncontrado.TarjetaProfesional=veterinario.TarjetaProfesional;

                _appContext.SaveChanges();
                
            }
            return veterinarioEncontrado;
        }
    }
}