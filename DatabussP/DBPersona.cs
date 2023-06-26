using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityP;
using System.Configuration;

namespace DatabussP
{
    public class DBPersona
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);

        public List<EntPerson> obtener()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from personas", conexion);
            da.Fill(dt);

            List<EntPerson> ls = new List<EntPerson>();
            foreach (DataRow dr in dt.Rows)
            {
                EntPerson ep = new EntPerson();

                ep.id = Convert.ToInt32(dr["id"]);
                ep.nombre = dr["nombre"].ToString();
                ep.edad = Convert.ToInt32(dr["edad"]);
                ep.fechalta = Convert.ToDateTime(dr["fechaalta"]);
                ep.paterno = dr["paterno"].ToString();
                ep.materno = dr["materno"].ToString();

                ls.Add(ep);
            }
            return ls;
        }

        public EntPerson obtenerid(int id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter($"select * from personas where id = {id}", conexion);
            da.Fill(dt);
            DataRow dr = dt.Rows[0];

            EntPerson ep = new EntPerson();
            ep.id = Convert.ToInt32(dr["id"]);
            ep.nombre = dr["nombre"].ToString();
            ep.edad = Convert.ToInt32(dr["edad"]);
            ep.fechalta = Convert.ToDateTime(dr["fechaalta"]);
            ep.paterno = dr["paterno"].ToString();
            ep.materno = dr["materno"].ToString();

            return ep;
        }

        public void agregar(EntPerson ep)
        {
            int fila = 0;
            SqlCommand com = new SqlCommand($"insert into personas values ('{ep.nombre}', '{ep.edad}', '{DateTime.Now.ToString("yyyy/MM/dd")}', '{ep.paterno}', '{ep.materno}')", conexion);

            try
            {
                conexion.Open();
                fila = com.ExecuteNonQuery();
                conexion.Close();

                if (fila != 1)
                {
                    throw new ApplicationException("error al agregar");
                }
            }
            catch (Exception)
            {
                conexion.Close();
                throw;
            }
        }

        public void editar(EntPerson ep)
        {
            int fila = 0;
            SqlCommand com = new SqlCommand($"update personas set nombre = '{ep.nombre}', edad = '{ep.edad}', fechaalta = '{DateTime.Now.ToString("yyyy/MM/dd")}', paterno = '{ep.paterno}', materno = '{ep.materno}' where id = {ep.id}", conexion);

            try
            {
                conexion.Open();
                fila = com.ExecuteNonQuery();
                conexion.Close();

                if (fila != 1)
                {
                    throw new ApplicationException("error al editar");
                }
            }
            catch (Exception)
            {
                conexion.Close();
                throw;
            }
        }

        public void eliminar(EntPerson ep)
        {            
            SqlCommand com = new SqlCommand($"delete personas where id = {ep.id}", conexion);

            try
            {
                conexion.Open();
                int fila = com.ExecuteNonQuery();
                conexion.Close();

            }
            catch (Exception)
            {
                conexion.Close();
                throw;
            }
        }

        public List<EntPerson> buscar(string palabra)
        {
            SqlDataAdapter da = new SqlDataAdapter($"select * from personas where nombre like '%{palabra}%' or paterno like '%{palabra}%'", conexion);
            DataTable dt = new DataTable();
            da.Fill(dt);

            List<EntPerson> ls = new List<EntPerson>();
            foreach (DataRow dr in dt.Rows)
            {
                EntPerson ep = new EntPerson();

                ep.id = Convert.ToInt32(dr["id"]);
                ep.nombre = dr["nombre"].ToString();
                ep.edad = Convert.ToInt32(dr["edad"]);
                ep.fechalta = Convert.ToDateTime(dr["fechaalta"]);
                ep.paterno = dr["paterno"].ToString();
                ep.materno = dr["materno"].ToString();

                ls.Add(ep);
            }
            return ls;
        }

        public void validar(EntPerson ep)
        {
            int fila = 0;
            SqlCommand com = new SqlCommand($"select 1 from personas where nombre = '{ep.nombre}' and paterno = '{ep.paterno}'", conexion);

            try
            {
                conexion.Open();
                fila = Convert.ToInt32(com.ExecuteScalar());
                conexion.Close ();
                if (fila == 1)
                {
                    throw new ApplicationException("Este nombre de usuario ya existe");
                }
            }
            catch (Exception)
            {
                conexion.Close();
                throw;
            }
        }
    }
}
