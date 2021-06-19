using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TransportadoraService.Models;

namespace TransportadoraService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "UsuarioService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione UsuarioService.svc o UsuarioService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class UsuarioService : IUsuarioService
    {
        TransportadoraEntities datos = new TransportadoraEntities();
        public void AgregarUsuario(Usuario usuario)
        {
            datos.Usuario.Add(usuario);
            datos.SaveChanges();
        }

        public Usuario BuscarUsuario(long Id)
        {
            var buscar = datos.Usuario.Find(Id);
            return buscar;
        }

        public void CambiarPassword(long Id, string contraseñaActual, string nuevaContraseña)
        {
            Usuario usuario = datos.Usuario.Find(Id);

            if(usuario != null)
            {
                if(usuario.Contraseña == contraseñaActual)
                {
                    usuario.Contraseña = nuevaContraseña;
                    datos.SaveChanges();
                }
            }
        }

        public void Confirmacion(long Id)
        {
            Usuario usuario = datos.Usuario.Find(Id);
            datos.Usuario.Remove(usuario);
            datos.SaveChanges();
        }

        public void EditarUsuario(long Id, Usuario usuario)
        {
            var buscar = datos.Usuario.Find(Id);
            if(buscar != null)
            {
                buscar.Correo = usuario.Correo;
                buscar.Contraseña = usuario.Contraseña;

                datos.SaveChanges();
            }           

        }

        public void EliminarUsuario(long Id)
        {
            var buscar = datos.Usuario.Find(Id);
            if (buscar != null)
            {
                datos.Usuario.Remove(buscar);
                datos.SaveChanges();
            }
        }

        public List<Usuario> ListarUsuarios()
        {
            return datos.Usuario.ToList();
        }
    }
}
