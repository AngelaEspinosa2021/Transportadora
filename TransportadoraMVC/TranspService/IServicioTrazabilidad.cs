using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TranspService.Modelos;

namespace TranspService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServicioTrazabilidad" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioTrazabilidad
    {
        [OperationContract]
        List<Trazabilidad> ListarTrazabilidades();

        [OperationContract]
        Trazabilidad BuscarTrazabilidad(long Id);

        [OperationContract]
        void AgregarTrazabilidad(Trazabilidad trazabilidad);

        [OperationContract]
        void EditarTrazabilidad(long Id, Trazabilidad trazabilidad);

        [OperationContract]
        void ConfirmarTraza(long Id);

        [OperationContract]
        void EliminarTraza(long Id);
    }
}
