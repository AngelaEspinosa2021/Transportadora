using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TransportadoraService.Models;

namespace TransportadoraService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicioTransportadora" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServicioTransportadora.svc o ServicioTransportadora.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServicioTransportadora : IServicioTransportadora
    {
        TransportadoraEntities db = new TransportadoraEntities();


        public void DoWork()
        {
        }

        public List<Usuario> ListarUsuarios()
        {
            return db.Usuario.ToList();
        }
    }
}
