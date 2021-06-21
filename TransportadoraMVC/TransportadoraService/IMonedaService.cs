using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TransportadoraService.Models;

namespace TransportadoraService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IMonedaService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IMonedaService
    {
        [OperationContract]
        List<Moneda> ListarMonedas();

        [OperationContract]
        Moneda BuscarMoneda(long Id);

        [OperationContract]
        void AgregarMoneda(Moneda moneda);

        [OperationContract]
        void EditarMoneda(long Id, Moneda moneda);

        [OperationContract]
        void EliminarMoneda(long Id);

        [OperationContract]
        void Confirmacion(long Id);

    }
}
