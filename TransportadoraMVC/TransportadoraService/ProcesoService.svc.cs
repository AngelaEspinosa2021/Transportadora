using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TransportadoraService.Models;

namespace TransportadoraService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ProcesoService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ProcesoService.svc o ProcesoService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ProcesoService : IProcesoService
    {
        TransportadoraEntities datos = new TransportadoraEntities();

        public void AgregarProceso(Proceso proceso)
        {
            datos.Proceso.Add(proceso);
            datos.SaveChanges();
        }

        public Proceso BuscarProceso(long Id)
        {
            var buscar = datos.Proceso.Find(Id);
            return buscar;
        }

        public void Confirmacion(long Id)
        {
            Proceso proceso = datos.Proceso.Find(Id);
            datos.Proceso.Remove(proceso);
            datos.SaveChanges();
        }

        public void EditarProceso(long Id, Proceso proceso)
        {
            var buscar = datos.Proceso.Find(Id);
            if (buscar != null)
            {
                buscar.Sucursal = proceso.Sucursal;
                buscar.Nombre = proceso.Nombre;
                buscar.Estado = proceso.Estado;

                datos.SaveChanges();
            }
        }
        public void EliminarProceso(long Id)
        {
            Proceso proceso = datos.Proceso.Find(Id);
            datos.Proceso.Remove(proceso);
            datos.SaveChanges();
        }

        public List<Proceso> ListarProcesos()
        {
            return datos.Proceso.ToList();
        }
    }
}
