using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TransportadoraService.Models;

namespace TransportadoraService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ActividadService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ActividadService.svc o ActividadService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ActividadService : IActividadService
    {
        TransportadoraEntities datos = new TransportadoraEntities();
        public void AgregarActividad(Actividad actividad)
        {
            datos.Actividad.Add(actividad);
            datos.SaveChanges();
        }

        public Actividad BuscarActividad(long Id)
        {
            var buscar = datos.Actividad.Find(Id);
            return buscar;
        }

        public void Confirmacion(long Id)
        {
            Actividad actividad = datos.Actividad.Find(Id);
            datos.Actividad.Remove(actividad);
            datos.SaveChanges();
        }

        public void EditarActividad(long Id, Actividad actividad)
        {
            var buscar = datos.Actividad.Find(Id);
            if(buscar != null)
            {
                buscar.CreadaPor = actividad.CreadaPor;
                buscar.AsignadaA = actividad.AsignadaA;
                buscar.RelacionadaCon = actividad.RelacionadaCon;
                buscar.Asunto = actividad.Asunto;
                buscar.FechaVencimiento = actividad.FechaVencimiento;
                buscar.Observacion = actividad.Observacion;
                buscar.Estado = actividad.Estado;
                buscar.Prioridad = actividad.Prioridad;

                datos.SaveChanges();
            }
        }

        public void EliminarActividad(long Id)
        {
            Actividad actividad = datos.Actividad.Find(Id);
            datos.Actividad.Remove(actividad);
            datos.SaveChanges();
        }

        public List<Actividad> ListarActividades()
        {
            return datos.Actividad.ToList();
        }
    }
}
