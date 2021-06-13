using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TranspService.Modelos;

namespace TranspService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServicioMoneda" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioMoneda
    {
        [OperationContract]
        List<Moneda> ListarMoneda();

        [OperationContract]
        void AgregarMoneda(Moneda mon);

        [OperationContract]
        void EditarMoneda(long Id, Moneda mon);

        [OperationContract]
        void EliminarMoneda(long Id);

        [OperationContract]
        Moneda BuscarMoneda(long Id);
    }
}
