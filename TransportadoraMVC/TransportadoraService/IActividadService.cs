using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TransportadoraService.Models;

namespace TransportadoraService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IActividadService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IActividadService
    {
        [OperationContract]
        List<ActividadDTO> ListarActividades();

        [OperationContract]
        Actividad BuscarActividad(long Id);

        [OperationContract]
        void AgregarActividad(Actividad actividad);

        [OperationContract]
        void EditarActividad(long Id, Actividad actividad);

        [OperationContract]
        void Confirmacion(long Id);

        [OperationContract]
        void EliminarActividad(long Id);

    }
}
