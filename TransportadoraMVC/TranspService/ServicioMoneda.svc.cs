using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TranspService.Modelos;

namespace TranspService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicioMoneda" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServicioMoneda.svc o ServicioMoneda.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServicioMoneda : IServicioMoneda
    {
        transportadoraEntities bd = new transportadoraEntities();
        public void AgregarMoneda(Moneda mon)
        {
            bd.Moneda.Add(mon);
            bd.SaveChanges();
        }

        public Moneda BuscarMoneda(long Id)
        {
            var buscar = bd.Moneda.Find(Id);
            return buscar;
        }

        public void EditarMoneda(long Id, Moneda mon)
        {
            var buscar = bd.Moneda.Find(Id);
            if (buscar != null)
            {
                buscar.Nombre = mon.Nombre;
                buscar.Codigo = mon.Codigo;
                buscar.Valor = mon.Valor;
                buscar.Fecha = mon.Fecha;
                buscar.Descripcion = mon.Descripcion;

                bd.SaveChanges();
            }
        }

        public void EliminarMoneda(long Id)
        {
            var buscar = bd.Moneda.Find(Id);
            if (buscar != null)
            {
                bd.Moneda.Remove(buscar);
                bd.SaveChanges();
            }            
        }

        public List<Moneda> ListarMoneda()
        {
            return bd.Moneda.ToList();
        }
    }
}
