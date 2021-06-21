using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TransportadoraService.Models;

namespace TransportadoraService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IProcesoService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IProcesoService
    {
        [OperationContract]
        List<Proceso> ListarProcesos();

        [OperationContract]
        Proceso BuscarProceso(long Id);

        [OperationContract]
        void AgregarProceso(Proceso proceso);

        [OperationContract]
        void EditarProceso(long Id, Proceso proceso);

        [OperationContract]
        void Confirmacion(long Id);

        [OperationContract]
        void EliminarProceso(long Id);

    }
}
