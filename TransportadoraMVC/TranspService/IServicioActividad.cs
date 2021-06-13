using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TranspService.Modelos;

namespace TranspService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServicioActividad" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioActividad
    {
        [OperationContract]
        List<Actividad> ListarActivida();

        [OperationContract]
        void AgregarActividad(Actividad act);

        [OperationContract]
        void EditarActividad(long Id, Actividad act);

        [OperationContract]
        void EliminarActividad(long Id);

        [OperationContract]
        Actividad BuscarActividad(long Id);
    }
}
