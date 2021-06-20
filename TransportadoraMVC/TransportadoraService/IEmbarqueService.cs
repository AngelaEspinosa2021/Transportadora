using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TransportadoraService.Models;

namespace TransportadoraService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IEmbarqueService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IEmbarqueService
    {
        [OperationContract]
        List<Embarque> ListarEmbarques();

        [OperationContract]
        Embarque BuscarEmbarque(long Id);

        [OperationContract]
        void AgregarEmbarque(Embarque embarque);

        [OperationContract]
        void EditarEmbarque(long Id, Embarque embarque);

        [OperationContract]
        void EliminarEmbarque(long Id);

        [OperationContract]
        void EliminarTrazas(long IdEmbarque);

        [OperationContract]
        void Confirmacion(long Id);


    }
}
