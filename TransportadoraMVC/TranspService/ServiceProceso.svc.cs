using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TranspService.Modelos;

namespace TranspService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceProceso" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServiceProceso.svc o ServiceProceso.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceProceso : IServiceProceso
    {
        transportadoraEntities bd = new transportadoraEntities();
        public void AgregarProceso(Proceso proc)
        {
            bd.Proceso.Add(proc);
            bd.SaveChanges();
        }

        public Proceso BuscarProceso(long Id)
        {
            var buscar = bd.Proceso.Find(Id);
            return buscar;
        }

        public void EditarProceso(long Id, Proceso proc)
        {
            var buscar = bd.Proceso.Find(Id);
            if (buscar != null)
            {
                buscar.Sucursal = proc.Sucursal;
                buscar.Nombre = proc.Nombre;
                buscar.Estado = proc.Estado;           

                bd.SaveChanges();
            }
        }

        public void EliminarProceso(long Id)
        {
            var buscar = bd.Proceso.Find(Id);
            if (buscar != null)
            {
                bd.Proceso.Remove(buscar);
                bd.SaveChanges();
            }
        }

        public List<Proceso> ListarProceso()
        {
            return bd.Proceso.ToList();
        }
    }
}
