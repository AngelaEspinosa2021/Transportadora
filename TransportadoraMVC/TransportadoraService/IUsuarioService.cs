using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TransportadoraService.Models;

namespace TransportadoraService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IUsuarioService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IUsuarioService
    {

        [OperationContract]
        List<Usuario> ListarUsuarios();

        [OperationContract]
        Usuario BuscarUsuario(long Id);

        [OperationContract]
        void AgregarUsuario(Usuario usuario);

        [OperationContract]
        void EliminarUsuario(long Id);

        [OperationContract]
        void CambiarPassword(long Id, string contraseñaActual, string nuevaContraseña);

        [OperationContract]
        void EditarUsuario(long Id, Usuario usuario);

        [OperationContract]
        void Confirmacion(long Id);

    }
}
