using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TranspService.Modelos;

namespace TranspService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceEmbarque" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServiceEmbarque.svc o ServiceEmbarque.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceEmbarque : IServiceEmbarque
    {
        transportadoraEntities bd = new transportadoraEntities();
        public void AgregarEmbarque(Embarque emb)
        {
            bd.Embarque.Add(emb);
            bd.SaveChanges();
        }

        public Embarque BuscarEmbarque(long Id)
        {
            var buscar = bd.Embarque.Find(Id);
            return buscar;
        }

        public void EditarEmbarque(long Id, Embarque emb)
        {
            var buscar = bd.Embarque.Find(Id);
            if (buscar != null)
            {
                buscar.Direccion = emb.Direccion;
                buscar.Telefono = emb.Telefono;
                buscar.Fax = emb.Fax;
                buscar.Contacto = emb.Contacto;
                buscar.OrdenCompra = emb.OrdenCompra;
                buscar.Consignatario = emb.Consignatario;
                buscar.ZonaAduanera = emb.ZonaAduanera;
                buscar.Origen = emb.Origen;
                buscar.Destino = emb.Destino;
                buscar.EmbarqueAereo = emb.EmbarqueAereo;
                buscar.EmbarqueMaritimo = emb.EmbarqueMaritimo;
                buscar.Contenedor = emb.Contenedor;
                buscar.INCOTERM = emb.INCOTERM;
                buscar.Observacion = emb.Observacion;
                
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

        public List<Embarque> ListarEmbarque()
        {
            return bd.Embarque.ToList();
        }
    }
}
