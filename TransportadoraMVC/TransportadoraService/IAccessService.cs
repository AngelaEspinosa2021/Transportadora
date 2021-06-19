using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TransportadoraService.Models;

namespace TransportadoraService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IAccessService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IAccessService
    {
        [OperationContract]
        Usuario ValidarUsuario(string txtUsuario, string txtPassword);
    }
}
