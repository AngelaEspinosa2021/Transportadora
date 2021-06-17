using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TranspService.Modelos;

namespace TranspService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServiceProceso" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceProceso
    {
        [OperationContract]
        List<Proceso> ListarProceso();

        [OperationContract]
        void AgregarProceso(Proceso proc);

        [OperationContract]
        void EditarProceso(long Id, Proceso proc);

        [OperationContract]
        void EliminarProceso(long Id);

        [OperationContract]
        Proceso BuscarProceso(long Id);
    }
}
