using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TranspService.Modelos;

namespace TranspService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServiceEmbarque" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceEmbarque
    {
        [OperationContract]
        List<Embarque> ListarEmbarque();

        [OperationContract]
        void AgregarEmbarque(Embarque emb);

        [OperationContract]
        void EditarEmbarque(long Id, Embarque emb);

        [OperationContract]
        void EliminarEmbarque(long Id);

        [OperationContract]
        Embarque BuscarEmbarque(long Id);
    }
}
