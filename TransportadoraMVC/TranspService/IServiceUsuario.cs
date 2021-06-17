using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TranspService.Modelos;

namespace TranspService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServiceUsuario" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceUsuario
    {
        [OperationContract]
        List<Usuario> ListarUsuario();

        [OperationContract]
        void AgregarUsuario(Usuario usu);

        [OperationContract]
        void EditarUsuario(long Id, Usuario usu);

        [OperationContract]
        void EliminarUsuario(long Id);

        [OperationContract]
        Usuario BuscarUsuario(long Id);

        [OperationContract]
        List<Usuario> ValidarUsuario(string usuario, string password);

        [OperationContract]
        void CambiarPassword(long id, string contraseñaActual, string nuevaContraseña);
    }
}
