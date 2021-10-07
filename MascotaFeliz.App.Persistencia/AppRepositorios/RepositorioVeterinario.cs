using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia
{
    public class RepositorioVeterinario : IRepositorioVeterinario
    {
        static public List<Veterinario> veterinarios;
        private readonly AppContext _appContext;

        public RepositorioVeterinario(AppContext appContext)
        {
            _appContext=appContext;
        }
        public RepositorioVeterinario()
        {
            veterinarios = new List<Veterinario>()
            {
                new Veterinario{Id=5,Identificacion="1192839472",Nombre="Esteban",Apellidos="Peréz Roa",Telefono="6851254",TarjetaProfesional="85301"},
                new Veterinario{Id=6,Identificacion="91285452",Nombre="Martha",Apellidos="Durán",Telefono="3154852651",TarjetaProfesional="75148"},
                new Veterinario{Id=7,Identificacion="1002562487",Nombre="Estefania",Apellidos="Buitrago",Telefono="3004517541",TarjetaProfesional="85914"},
                new Veterinario{Id=8,Identificacion="1125601020",Nombre="Daniel",Apellidos="Rosas Perez",Telefono="6452012",TarjetaProfesional="45820"}
            };
        }
        public Veterinario GetVeterinarioPorId(int veterinarioId)
        {
            return veterinarios.SingleOrDefault(v => v.Id ==veterinarioId);
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
            //return _appContext.Veterinarios;
            return veterinarios;
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