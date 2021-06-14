using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TranspService.Modelos;

namespace TranspService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceActividad" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServiceActividad.svc o ServiceActividad.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceActividad : IServiceActividad
    {
        transportadoraEntities bd = new transportadoraEntities();
        public void AgregarActividad(Actividad act)
        {
            bd.Actividad.Add(act);
            bd.SaveChanges();
        }

        public Actividad BuscarActividad(long Id)
        {
            var buscar = bd.Actividad.Find(Id);
            return buscar;
        }

        public void EditarActividad(long Id, Actividad act)
        {
            var buscar = bd.Actividad.Find(Id);
            if (buscar != null)
            {
                buscar.CreadaPor = act.CreadaPor;
                buscar.AsignadaA = act.AsignadaA;
                buscar.RelacionadaCon = act.RelacionadaCon;
                buscar.Asunto = act.Asunto;
                buscar.FechaVencimiento = act.FechaVencimiento;
                buscar.Observacion = act.Observacion;
                buscar.Estado = act.Estado;
                buscar.Prioridad = act.Prioridad;

                bd.SaveChanges();
            }
        }

        public void EliminarActividad(long Id)
        {
            var buscar = bd.Actividad.Find(Id);
            if (buscar != null)
            {
                bd.Actividad.Remove(buscar);
                bd.SaveChanges();
            }
        }

        public List<Actividad> ListarActividad()
        {
            return bd.Actividad.ToList();
        }
    }
}
