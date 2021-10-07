using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia
{
    public class RepositorioVisita : IRepositorioVisita
    {
        List<Visita> visitas;
        private readonly AppContext _appContext;

        public RepositorioVisita(AppContext appContext)
        {
            _appContext=appContext;
        }
        public RepositorioVisita()
        {
            visitas = new List<Visita>()
            {
                new Visita{Id=1,Mascota=RepositorioMascota.mascotas[0],Veterinario=RepositorioVeterinario.veterinarios[2], Fecha=new System.DateTime(2021,09,12),Temperatura=36,Peso=12,FrecuenciaRespiratoria=32,FrecuenciaCardiaca=172,EstadoDeAnimo="Un poco alterado, pero no fuera de lo común",Recomendaciones="Proporcionar las vitaminas cada 12 horas y asegurarse de que beba abundante agua"},
                new Visita{Id=2,Mascota=RepositorioMascota.mascotas[1],Veterinario=RepositorioVeterinario.veterinarios[3], Fecha=new System.DateTime(2021,09,15),Temperatura=35,Peso=17,FrecuenciaRespiratoria=40,FrecuenciaCardiaca=109,EstadoDeAnimo="Bastante sereno y calmado",Recomendaciones="Limpiar constantemente patas y cuello. Aumentar ingesta de proteína"},
                new Visita{Id=3,Mascota=RepositorioMascota.mascotas[2],Veterinario=RepositorioVeterinario.veterinarios[0],Fecha=new System.DateTime(2021,09,16),Temperatura=34,Peso=15,FrecuenciaRespiratoria=35,FrecuenciaCardiaca=157,EstadoDeAnimo="Alegre,alterado",Recomendaciones="Bajar consumo de enlatados, proporcionar cantidades más pequeñas con respecto a la hora del día"},
                new Visita{Id=4,Mascota=RepositorioMascota.mascotas[3],Veterinario=RepositorioVeterinario.veterinarios[1], Fecha=new System.DateTime(2021,09,22),Temperatura=35,Peso=23,FrecuenciaRespiratoria=37,FrecuenciaCardiaca=120,EstadoDeAnimo="Algo malhumorado, impaciente",Recomendaciones="Prestar especial atención a las manchas del cuello, si continuan, regresar lo mas pronto posible. Proporcionar medicina asignada"},
                new Visita{Id=5,Mascota=RepositorioMascota.mascotas[1],Veterinario=RepositorioVeterinario.veterinarios[2], Fecha=new System.DateTime(2021,09,23),Temperatura=34,Peso=12,FrecuenciaRespiratoria=39,FrecuenciaCardiaca=135,EstadoDeAnimo="Timido, bastante nervioso",Recomendaciones="Incrementar el tiempo de paseo, procurar que socialice con otros animales. Suministrar vitaminas"},
                new Visita{Id=6,Mascota=RepositorioMascota.mascotas[0],Veterinario=RepositorioVeterinario.veterinarios[1], Fecha=new System.DateTime(2021,09,29),Temperatura=36,Peso=23,FrecuenciaRespiratoria=36,FrecuenciaCardiaca=110,EstadoDeAnimo="Tranquilo, alegre",Recomendaciones="Bañar cada 7 días. Continuar con los cuidados"}
            };
        }

        public Visita GetVisitaPorId(int visitaId)
        {
            return visitas.SingleOrDefault(vi => vi.Id ==visitaId);
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
            //return _appContext.Visitas;
            return visitas;
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