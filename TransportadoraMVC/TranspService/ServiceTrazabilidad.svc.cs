using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TranspService.Modelos;

namespace TranspService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceTrazabilidad" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServiceTrazabilidad.svc o ServiceTrazabilidad.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceTrazabilidad : IServiceTrazabilidad
    {
        transportadoraEntities bd = new transportadoraEntities();
        public void AgregarTrazabilidad(Trazabilidad tra)
        {
            bd.Trazabilidad.Add(tra);
            bd.SaveChanges();
        }

        public Trazabilidad BuscarTrazabilidad(long Id)
        {
            var buscar = bd.Trazabilidad.Find(Id);
            return buscar;
        }

        public void EditarTrazabilidad(long Id, Trazabilidad tra)
        {
            var buscar = bd.Trazabilidad.Find(Id);
            if (buscar != null)
            {
                buscar.TipoOperacion = tra.TipoOperacion;
                buscar.PaisOrigen = tra.PaisOrigen;
                buscar.CiudadOrigen = tra.CiudadOrigen;
                buscar.PaisDestino = tra.PaisDestino;
                buscar.CiudadDesstino = tra.CiudadDesstino;

                bd.SaveChanges();
            }
        }

        public void EliminarTrazabilidad(long Id)
        {
            var buscar = bd.Trazabilidad.Find(Id);
            if (buscar != null)
            {
                bd.Trazabilidad.Remove(buscar);
                bd.SaveChanges();
            }
        }

        public List<Trazabilidad> ListarTrazabilidad()
        {
            return bd.Trazabilidad.ToList();
        }
    }
}
