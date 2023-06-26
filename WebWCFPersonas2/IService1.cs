using EntityP;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WebWCFPersonas2
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        respuesta obtener();

        [OperationContract]
        respuesta obtenerid(int id);

        [OperationContract]
        respuesta agregar(EntPerson ep);

        [OperationContract]
        respuesta editar(EntPerson ep);

        [OperationContract]
        respuesta eliminar(EntPerson ep);

        [OperationContract]
        respuesta buscar(string palabra);

        [OperationContract]
        respuesta validar(EntPerson ep);
    }
}
