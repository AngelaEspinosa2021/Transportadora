using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TransportadoraService.Models;

namespace TransportadoraService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "EmbarqueService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione EmbarqueService.svc o EmbarqueService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class EmbarqueService : IEmbarqueService
    {
        TransportadoraEntities datos = new TransportadoraEntities();
        public void AgregarEmbarque(Embarque embarque)
        {
            datos.Embarque.Add(embarque);
            datos.SaveChanges();
        }

        public Embarque BuscarEmbarque(long Id)
        {
            var buscar = datos.Embarque.Find(Id);
            return buscar;
        }

        public void Confirmacion(long Id)
        {
            Embarque embarque = datos.Embarque.Find(Id);
            datos.Embarque.Remove(embarque);
            datos.SaveChanges();
        }

        public void EditarEmbarque(long Id, Embarque embarque)
        {
            var buscar = datos.Embarque.Find(Id);
            if(buscar != null)
            {
                buscar.Direccion = embarque.Direccion;
                buscar.Telefono = embarque.Telefono;
                buscar.Fax = embarque.Fax;
                buscar.Contacto = embarque.Contacto;
                buscar.OrdenCompra = embarque.OrdenCompra;
                buscar.Consignatario = embarque.Consignatario;
                buscar.ZonaAduanera = embarque.ZonaAduanera;
                buscar.Origen = embarque.Origen;
                buscar.Destino = embarque.Destino;
                buscar.EmbarqueAereo = embarque.EmbarqueAereo;
                buscar.EmbarqueMaritimo = embarque.EmbarqueMaritimo;
                buscar.Contenedor = embarque.Contenedor;
                buscar.INCOTERM = embarque.INCOTERM;
                buscar.Observacion = embarque.Observacion;

                datos.SaveChanges();

            }
        }

        public void EliminarEmbarque(long Id)
        {
            Embarque embarque = datos.Embarque.Find(Id);
            EliminarTrazas(Id);
            datos.Embarque.Remove(embarque);
            datos.SaveChanges();
        }

        public void EliminarTrazas(long IdEmbarque)
        {
            var trazas = (from u in datos.Trazabilidad
                          where u.IdEmbarque == IdEmbarque
                          select u).ToList();
            foreach (var traza in trazas)
            {
                datos.Trazabilidad.Remove(traza);
            }
            datos.SaveChanges();
        }

        List<Embarque> IEmbarqueService.ListarEmbarques()
        {
            return datos.Embarque.ToList();
        }
    }
}
