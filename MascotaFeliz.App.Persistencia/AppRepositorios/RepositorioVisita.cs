using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia
{
    public class RepositorioVisita : IRepositorioVisita
    {
        private readonly AppContext _appContext;

        public RepositorioVisita(AppContext appContext)
        {
            _appContext=appContext;
        }
        Visita IRepositorioVisita.AddVisita(Visita visita)
        {
            var visitaAdicionado=_appContext.Visitas.Add(visita);
            _appContext.SaveChanges();
            return visitaAdicionado.Entity;
        }

        void IRepositorioVisita.DeleteVisita(int idVisita)
        {
            var visitaEncontrado=_appContext.Visitas.FirstOrDefault(m => m.Id == idVisita);
            if(visitaEncontrado==null)
                return;
            _appContext.Visitas.Remove(visitaEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Visita> IRepositorioVisita.GetAllVisitas()
        {
            return _appContext.Visitas;
        }

        Visita IRepositorioVisita.GetVisita(int idVisita)
        {
            return _appContext.Visitas.FirstOrDefault(vi => vi.Id == idVisita);

        }

        Visita IRepositorioVisita.UpdateVisita(Visita visita, int idVisita_original)
        {
            var visitaEncontrado=_appContext.Visitas.FirstOrDefault(vi => vi.Id == idVisita_original);
            if (visitaEncontrado==null)
            {
                visitaEncontrado.Mascota=visita.Mascota;
                visitaEncontrado.Veterinario=visita.Veterinario;
                visitaEncontrado.Fecha=visita.Fecha;
                visitaEncontrado.Temperatura=visita.Temperatura;
                visitaEncontrado.Peso=visita.Peso;
                visitaEncontrado.FrecuenciaRespiratoria=visita.FrecuenciaRespiratoria;
                visitaEncontrado.FrecuenciaCardiaca=visita.FrecuenciaCardiaca;
                visitaEncontrado.EstadoDeAnimo=visita.EstadoDeAnimo;
                visitaEncontrado.Recomendaciones=visita.Recomendaciones;

                //mascotaEncontrado.TarjetaProfesional=mascota.TarjetaProfesional;

                _appContext.SaveChanges();
                
            }
            return visitaEncontrado;
        }
    }
}