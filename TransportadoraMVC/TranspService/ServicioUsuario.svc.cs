using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TranspService.Modelos;

namespace TranspService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServicioUsuario" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServicioUsuario.svc o ServicioUsuario.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServicioUsuario : IServicioUsuario
    {
        transportadoraEntities bd = new transportadoraEntities();
        public void AgregarUsuario(Usuario usuario)
        {
            bd.Usuario.Add(usuario);
            bd.SaveChanges();
        }

        public Usuario BuscarUsuario(long Id)
        {
            var buscar =  bd.Usuario.Find(Id);
            return buscar;
        }

        public void CambiarPassword(long Id, string contraseñaActual, string nuevaContraseña)
        {
            Usuario usuario = bd.Usuario.Find(Id);

            if (usuario != null)
            {
                if (usuario.Contraseña == contraseñaActual)
                {
                    usuario.Contraseña = nuevaContraseña;
                    bd.SaveChanges();
                }
                
            }           
            
        }

        public void ConfirmarUsuario(long Id)
        {
            Usuario usuario = bd.Usuario.Find(Id);
            bd.Usuario.Remove(usuario);
            bd.SaveChanges();
        }

        public void EditarUsuario(long Id, Usuario usuario)
        {
            var buscar = bd.Usuario.Find(Id);
            if (buscar != null)
            {
                buscar.Correo = usuario.Correo;
                buscar.Contraseña = usuario.Contraseña;

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

        public List<Usuario> ListarUsuarios()
        {
            return bd.Usuario.ToList();
        }

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
