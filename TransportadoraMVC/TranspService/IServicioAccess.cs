using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using TranspService.Modelos;

namespace TranspService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServicioAccess" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioAccess
    {

        [OperationContract]
        Usuario ValidarUsuario(string txtUsuario, string txtPassword);
    }
}
