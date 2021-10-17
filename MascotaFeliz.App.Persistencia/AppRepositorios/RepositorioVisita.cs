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
        Visita IRepositorioVisita.AddVisita(Visita nuevaVisita)
        {
            var visitaAdicionado=_appContext.Visitas.Add(nuevaVisita);
            _appContext.SaveChanges();
            return visitaAdicionado.Entity;
        }

        void IRepositorioVisita.DeleteVisita(int idVisita)
        {
            var visitaEncontrado=_appContext.Visitas.FirstOrDefault(p =>p.Id==idVisita);
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
            return _appContext.Visitas.FirstOrDefault(p =>p.Id==idVisita);

        }

        Visita IRepositorioVisita.UpdateVisita(Visita visitaActualizado)
        {
            var visitaEncontrado=_appContext.Visitas.FirstOrDefault(p =>p.Id== visitaActualizado.Id);
            if (visitaEncontrado!=null)
            {
                visitaEncontrado.Id = visitaActualizado.Id;
                visitaEncontrado.Mascota=visitaActualizado.Mascota;
                visitaEncontrado.Fecha=visitaActualizado.Fecha;
                visitaEncontrado.Temperatura=visitaActualizado.Temperatura;
                visitaEncontrado.Peso=visitaActualizado.Peso;
                visitaEncontrado.FrecuenciaRespiratoria=visitaActualizado.FrecuenciaRespiratoria;
                visitaEncontrado.FrecuenciaCardiaca=visitaActualizado.FrecuenciaCardiaca;
                visitaEncontrado.EstadoDeAnimo=visitaActualizado.EstadoDeAnimo;
                visitaEncontrado.Recomendaciones=visitaActualizado.Recomendaciones;

                _appContext.SaveChanges();
                
            }
            return visitaEncontrado;
        }

    }

}