using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TranspService.Modelos;

namespace TranspService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceUsuario" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServiceUsuario.svc o ServiceUsuario.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceUsuario : IServiceUsuario
    {
        transportadoraEntities bd = new transportadoraEntities();
        public void AgregarUsuario(Usuario usu)
        {
            bd.Usuario.Add(usu);
            bd.SaveChanges();
        }

        public Usuario BuscarUsuario(long Id)
        {
            var buscar = bd.Usuario.Find(Id);
            return buscar;
        }

        public void CambiarPassword(long id, string contraseñaActual, string nuevaContraseña)
        {
            Usuario usuario = bd.Usuario.Find(id);
            if (usuario != null)
            {
                if (usuario.Contraseña == contraseñaActual)
                {
                    usuario.Contraseña = nuevaContraseña;
                    bd.SaveChanges();
                }
            }
        }

        public void EditarUsuario(long Id, Usuario usu)
        {
            var buscar = bd.Usuario.Find(Id);
            if (buscar != null)
            {
                buscar.Correo = usu.Correo;
                buscar.Contraseña = usu.Contraseña;                

                bd.SaveChanges();
            }
        }

        public void EliminarUsuario(long Id)
        {
            var buscar = bd.Usuario.Find(Id);
            if (buscar != null)
            {
                bd.Usuario.Remove(buscar);
                bd.SaveChanges();
            }
        }

        public List<Usuario> ListarUsuario()
        {
            return bd.Usuario.ToList();
        }

        public List<Usuario> ValidarUsuario(string usuario, string password)
        {
            var listaUsuario = (from m in bd.Usuario
                                where m.Correo == usuario && m.Contraseña == password
                                select m);

            return listaUsuario.ToList();
        }
    }
}
