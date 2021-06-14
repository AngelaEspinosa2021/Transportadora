using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TranspService.Modelos;

namespace TranspService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicioTrazabilidad" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServicioTrazabilidad.svc o ServicioTrazabilidad.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServicioTrazabilidad : IServicioTrazabilidad
    {
        transportadoraEntities bd = new transportadoraEntities();
        public void AgregarTrazabilidad(Trazabilidad trazabilidad)
        {
            bd.Trazabilidad.Add(trazabilidad);
            bd.SaveChanges();
        }

        public Trazabilidad BuscarTrazabilidad(long Id)
        {
            var buscar = bd.Trazabilidad.Find(Id);
            return buscar;
        }

        public void ConfirmarTraza(long Id)
        {
            Trazabilidad trazabilidad = bd.Trazabilidad.Find(Id);
            bd.Trazabilidad.Remove(trazabilidad);
            bd.SaveChanges();
        }

        public void EditarTrazabilidad(long Id, Trazabilidad trazabilidad)
        {
            var buscar = bd.Trazabilidad.Find(Id);
            if (buscar != null)
            {
                buscar.TipoOperacion = trazabilidad.TipoOperacion;
                buscar.PaisOrigen = trazabilidad.PaisOrigen;
                buscar.CiudadOrigen = trazabilidad.CiudadOrigen;
                buscar.PaisDestino = trazabilidad.PaisDestino;
                buscar.CiudadDesstino = trazabilidad.CiudadDesstino;
                buscar.Kilos = trazabilidad.Kilos;
                buscar.Teus = trazabilidad.Teus; 


                bd.SaveChanges();

            }
        }

        public void EliminarTraza(long Id)
        {
            var buscar = bd.Trazabilidad.Find(Id);
            if (buscar != null)
            {
                bd.Trazabilidad.Remove(buscar);
                bd.SaveChanges();
            }
        }

        public List<Trazabilidad> ListarTrazabilidades()
        {
            return bd.Trazabilidad.ToList();
        }
    }
}
