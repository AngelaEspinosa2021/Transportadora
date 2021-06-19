using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TransportadoraService.Models;

namespace TransportadoraService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "AccessService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione AccessService.svc o AccessService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class AccessService : IAccessService    {
        
        public Usuario ValidarUsuario(string txtUsuario, string txtPassword)
        {
            using (TransportadoraEntities datos = new TransportadoraEntities())
            {
                var listaUsuario = (from m in datos.Usuario
                                    where m.Correo == txtUsuario && m.Contraseña == txtPassword
                                    select m).ToList().FirstOrDefault();

                return listaUsuario;

            }
                
        }
    }
}
