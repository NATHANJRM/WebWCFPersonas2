using DatabussP;
using EntityP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WebWCFPersonas2
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        public respuesta obtener()
        {
            respuesta res = new respuesta();
            try
            {
                DBPersona data = new DBPersona();
                List<EntPerson> ls = data.obtener();
                res.Listp = ls;
                res.Mensaje = "bien";
                res.Error = false;
                return res;
            }
            catch (Exception ex)
            {
                res.Error = true;
                res.Mensaje = ex.Message;
                return res;
            }
        }

        public respuesta obtenerid(int id)
        {
            respuesta res = new respuesta();
            try
            {
                DBPersona data = new DBPersona();
                EntPerson ep = data.obtenerid(id);
                res.Entp = ep;
                res.Mensaje = "bien";
                res.Error = false;
                return res;
            }
            catch (Exception ex )
            {
                res.Error = true;
                res.Mensaje = ex.Message;
                return res;
            }
        }

        public respuesta agregar(EntPerson ep)
        {
            respuesta res = new respuesta();
            try
            {
                DBPersona data = new DBPersona();
                data.agregar(ep);
                res.Mensaje = "Se agrego correctamente";
                res.Error = false; 
                return res;
            }
            catch (Exception ex)
            {
                res.Error = true;
                res.Mensaje = ex.Message;
                return res;
            }
        }

        public respuesta editar(EntPerson ep)
        {
            respuesta res = new respuesta();
            try
            {
                DBPersona data = new DBPersona();
                data.editar(ep);
                res.Mensaje = "Se edito correctamente";
                res.Error = false;
                return res;

            }
            catch (Exception ex)
            {
                res.Mensaje = ex.Message;
                res.Error = true;
                return res;
            }
        }

        public respuesta eliminar(EntPerson ep)
        {
            respuesta res = new respuesta();
            try
            {
                DBPersona data = new DBPersona();
                data.eliminar(ep);
                res.Mensaje = "Se elimino correctamente";
                res.Error = false;
                return res;
            }
            catch (Exception ex)
            {
                res.Mensaje = ex.Message;
                res.Error = true;
                return res;
            }
        }

        public respuesta buscar(string palabra)
        {
            respuesta res = new respuesta();
            try
            {
                DBPersona data = new DBPersona();
                List<EntPerson> ls = data.buscar(palabra);
                res.Listp = ls;
                res.Mensaje = "bien";
                res.Error = false;
                return res;
            }
            catch (Exception ex)
            {
                res.Error = true;
                res.Mensaje = ex.Message;
                return res;
            }
        }

        public respuesta validar(EntPerson ep)
        {
            respuesta res = new respuesta();
            try
            {
                DBPersona data = new DBPersona();
                res.Mensaje = "Este nombre de Usuario ya existe";
                res.Error = false;
                data.validar(ep);
            }
            catch (Exception ex)
            {
                res.Error = true;
                res.Mensaje = ex.Message;                
            }
            return res;
        }
    }    
}
