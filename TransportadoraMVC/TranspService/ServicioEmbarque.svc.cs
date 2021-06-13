using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TranspService.Modelos;

namespace TranspService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicioEmbarque" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServicioEmbarque.svc o ServicioEmbarque.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServicioEmbarque : IServicioEmbarque
    {
        transportadoraEntities bd = new transportadoraEntities();

        public void AgregarEmbarque(Embarque embarque)
        {
            bd.Embarque.Add(embarque);
            bd.SaveChanges();
        }

        public Embarque BuscarEmbarque(long Id)
        {
            var buscar = bd.Embarque.Find(Id);
            return buscar;
        }

        public void ConfirmarEmbarque(long Id)
        {
            Embarque embarque = bd.Embarque.Find(Id);
            bd.Embarque.Remove(embarque);
            bd.SaveChanges();
        }

        public void EditarEmbarque(long Id, Embarque embarque)
        {
            var buscar = bd.Embarque.Find(Id);
            if (buscar != null)
            {
                buscar.Direccion = embarque.Direccion;
                buscar.Telefono = embarque.Telefono;
                buscar.Fax = embarque.Contacto;
                buscar.Contacto = embarque.Contacto;
                buscar.OrdenCompra = embarque.OrdenCompra;
                buscar.Consignatario = embarque.Consignatario;
                buscar.ZonaAduanera = embarque.ZonaAduanera;
                buscar.Origen = embarque.Origen;
                buscar.EmbarqueAereo = embarque.EmbarqueAereo;
                buscar.EmbarqueMaritimo = embarque.EmbarqueMaritimo;
                buscar.Contenedor = embarque.Contenedor;
                buscar.INCOTERM = embarque.INCOTERM;
                buscar.Observacion = embarque.Observacion;

                bd.SaveChanges();

            }
        }

        public void EliminarEmbarque(long Id)
        {
            var buscar = bd.Embarque.Find(Id);
            if (buscar != null)
            {
                bd.Embarque.Remove(buscar);
                bd.SaveChanges();
            }
        }

        public void EliminarTrazas(long IdEmbarque)
        {
            var trazas = (from u in bd.Trazabilidad
                          where u.IdEmbarque == IdEmbarque
                          select u).ToList();

            foreach (var traza in trazas)
            {
                bd.Trazabilidad.Remove(traza);
            }
            bd.SaveChanges();
        }

        public List<Embarque> ListarEmbarques()
        {
            return bd.Embarque.ToList();
        }
    }
}
