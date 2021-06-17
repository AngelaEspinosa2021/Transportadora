using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Windows;
using TranspService.Modelos;

namespace TranspService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicioAccess" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServicioAccess.svc o ServicioAccess.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServicioAccess : IServicioAccess
    {
        public Usuario ValidarUsuario(string txtUsuario, string txtPassword)
        {
            using (transportadoraEntities bd = new transportadoraEntities())
            {
                var listaUsuario = (from m in bd.Usuario
                                    where m.Correo == txtUsuario && m.Contraseña == txtPassword
                                    select m).ToList().FirstOrDefault();

                return listaUsuario;
            }
        }
    }
}
