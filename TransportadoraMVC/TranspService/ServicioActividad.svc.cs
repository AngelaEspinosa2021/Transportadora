using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TranspService.Modelos;

namespace TranspService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicioActividad" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServicioActividad.svc o ServicioActividad.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServicioActividad : IServicioActividad
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

        public void DoWork()
        {
        }

        public void EditarActividad(long Id, Actividad act)
        {
            throw new NotImplementedException();
        }

        public void EliminarActividad(long Id)
        {
            throw new NotImplementedException();
        }

        public List<Actividad> ListarActivida()
        {
            throw new NotImplementedException();
        }
    }
}
