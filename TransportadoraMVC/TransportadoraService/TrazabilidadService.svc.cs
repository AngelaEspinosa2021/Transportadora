using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TransportadoraService.Models;

namespace TransportadoraService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "TrazabilidadService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione TrazabilidadService.svc o TrazabilidadService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class TrazabilidadService : ITrazabilidadService
    {
        TransportadoraEntities datos = new TransportadoraEntities();
        public void AgregarTraza(Trazabilidad traza)
        {
            datos.Trazabilidad.Add(traza);
            datos.SaveChanges();
        }

        public Trazabilidad BuscarTraza(long Id)
        {
            var buscar = datos.Trazabilidad.Find(Id);
            return buscar;
        }

        public void Confirmacion(long Id)
        {
            Trazabilidad traza = datos.Trazabilidad.Find(Id);
            datos.Trazabilidad.Remove(traza);
            datos.SaveChanges();
        }

        public void EditarTraza(long Id, Trazabilidad traza)
        {
            var buscar = datos.Trazabilidad.Find(Id);
            if(buscar != null)
            {
                buscar.TipoOperacion = traza.TipoOperacion;
                buscar.PaisOrigen = traza.PaisOrigen;
                buscar.CiudadOrigen = traza.CiudadOrigen;
                buscar.PaisDestino = traza.PaisDestino;
                buscar.CiudadDesstino = traza.CiudadDesstino;
                buscar.Kilos = traza.Kilos;
                buscar.Teus = traza.Teus;

                datos.SaveChanges();
            }
        }

        public void EliminarTraza(long Id)
        {
            Trazabilidad traza = datos.Trazabilidad.Find(Id);
            datos.Trazabilidad.Remove(traza);
            datos.SaveChanges();
        }

        public List<Trazabilidad> Listar(long Id)
        {
            var trazabilidades = (from traza in datos.Trazabilidad
                                where traza.IdEmbarque == Id
                                select traza).ToList();
            return trazabilidades;
        }

    }
}
