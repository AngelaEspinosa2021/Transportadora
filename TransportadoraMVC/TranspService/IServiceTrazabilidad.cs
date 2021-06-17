using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TranspService.Modelos;

namespace TranspService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServiceTrazabilidad" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceTrazabilidad
    {
        [OperationContract]
        List<Trazabilidad> ListarTrazabilidad();

        [OperationContract]
        void AgregarTrazabilidad(Trazabilidad tra);

        [OperationContract]
        void EditarTrazabilidad(long Id, Trazabilidad tra);

        [OperationContract]
        void EliminarTrazabilidad(long Id);

        [OperationContract]
        Trazabilidad BuscarTrazabilidad(long Id);
    }
}
