using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TransportadoraService.Models;

namespace TransportadoraService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "MonedaService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione MonedaService.svc o MonedaService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class MonedaService : IMonedaService
    {
        TransportadoraEntities datos = new TransportadoraEntities();
        public void AgregarMoneda(Moneda moneda)
        {
            datos.Moneda.Add(moneda);
            datos.SaveChanges();
        }

        public Moneda BuscarMoneda(long Id)
        {
            var buscar = datos.Moneda.Find(Id);
            return buscar;
        }

        public void Confirmacion(long Id)
        {
            Moneda moneda = datos.Moneda.Find(Id);
            datos.Moneda.Remove(moneda);
            datos.SaveChanges();
        }

        public void EditarMoneda(long Id, Moneda moneda)
        {
            var buscar = datos.Moneda.Find(Id);
            if(buscar != null)
            {
                buscar.Nombre = moneda.Nombre;
                buscar.Codigo = moneda.Codigo;
                buscar.Valor = moneda.Valor;
                buscar.Fecha = moneda.Fecha;
                buscar.Descripcion = moneda.Descripcion;

                datos.SaveChanges();
            }
        }

        public void EliminarMoneda(long Id)
        {
            Moneda moneda = datos.Moneda.Find(Id);
            datos.Moneda.Remove(moneda);
            datos.SaveChanges();
        }

        public List<Moneda> ListarMonedas()
        {
            return datos.Moneda.ToList();
        }
    }
}
