using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TransportadoraService.Models;

namespace TransportadoraService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "ITrazabilidadService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface ITrazabilidadService
    {
        [OperationContract]
        List<Trazabilidad> Listar(long Id);

        [OperationContract]
        Trazabilidad BuscarTraza(long Id);

        [OperationContract]
        void AgregarTraza(Trazabilidad traza);

        [OperationContract]
        void EditarTraza(long Id, Trazabilidad traza);

        [OperationContract]
        void EliminarTraza(long Id);

        [OperationContract]
        void Confirmacion(long Id);

        
    }
}
