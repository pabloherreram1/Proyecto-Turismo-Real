using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TurismoRealFF.Modelo
{
    public class ServicioExtra
    {
        public int ID { get; set; }
        public string NOMBRE { get; set; }
        public string DESCRIPCION { get; set; }
        public int PRECIO { get; set; }
        public DateTime CREATED_AT { get; set; }
        public DateTime UPDATED_AT { get; set; }

        public ServicioExtra()
        {

        }

        public ServicioExtra(int id, string nombre, string descripcion, int precio, DateTime created_at, DateTime updated_at)
        {
            ID = id;
            NOMBRE = nombre;
            DESCRIPCION = descripcion;
            PRECIO = precio;
            CREATED_AT = created_at;
            UPDATED_AT = updated_at;
        }

        //CREAR SERVICIO EXTRA
        /// <summary>
        /// Método para utilizar el procedimiento Insertar_ServicioExtra, el cual crea un servicio extra en la base de datos Oracle
        /// </summary>
        /// <param name="nombres"></param>
        /// <param name="descripcions"></param>
        /// <param name="precios"></param>
        /// <returns></returns>
        public int insertarS(string nombres, string descripcions, int precios)
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();
                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_SERVICIOEXTRA.INSERTAR_SERVICIOEXTRA", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_NOMBRE", OracleType.VarChar).Value = nombres;
                cmd.Parameters.Add("PRM_DESCRIPCION", OracleType.VarChar).Value = descripcions;
                cmd.Parameters.Add("PRM_PRECIO", OracleType.Int32).Value = precios;
                int resp = cmd.ExecuteNonQuery();
                onn.Close();
                cmd.Dispose();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        // MODIFICAR SERVICIO EXTRA
        /// <summary>
        /// Método para utilizar el procedimiento Modificar_ServicioExtra, el cual modifica la información del servicio extra en la base de datos Oracle
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="nombres"></param>
        /// <param name="descripcions"></param>
        /// <param name="precios"></param>
        /// <returns></returns>
        public int modificarS(int ids, string nombres, string descripcions, int precios)
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();
                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_SERVICIOEXTRA.MODIFICAR_SERVICIOEXTRA", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_ID", OracleType.Int32).Value = ids;
                cmd.Parameters.Add("PRM_NOMBRE", OracleType.VarChar).Value = nombres;
                cmd.Parameters.Add("PRM_DESCRIPCION", OracleType.VarChar).Value = descripcions;
                cmd.Parameters.Add("PRM_PRECIO", OracleType.Int32).Value = precios;
                int resp = cmd.ExecuteNonQuery();
                onn.Close();
                cmd.Dispose();
                if (resp != 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }

            }
            catch (Exception)
            {
                return 0;
            }
        }


        // ELIMINAR SERVICIO EXTRA
        /// <summary>
        /// Método para utilizar el procedimiento Eliminar_ServicioExtra, el cual elimina un servicio extra de la base de datos Oracle(Modifica al usuario como uno NO ACTIVO)
        /// </summary>
        /// <param name="ids"></param>}
        /// <returns></returns>
        public int eliminarS(int ids)
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();
                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_SERVICIOEXTRA.ELIMINAR_SERVICIOEXTRA", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_ID", OracleType.Int32).Value = ids;
                int resp = cmd.ExecuteNonQuery();
                onn.Close();
                cmd.Dispose();
                if (resp != 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// Método que te lista los servicios extra que estan "Activos"
        /// </summary>
        /// <returns></returns>
        public List<ServicioExtra> listarServicioExtra()
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();

                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_SERVICIOEXTRA.LISTAR_SERVICIOEXTRA", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_LISTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);

                List<ServicioExtra> listarServicioExtra = new List<ServicioExtra>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ServicioExtra s = new ServicioExtra();
                    s.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    s.NOMBRE = dt.Rows[i]["NOMBRE"].ToString();
                    s.DESCRIPCION = dt.Rows[i]["DESCRIPCION"].ToString();
                    s.PRECIO = Convert.ToInt32(dt.Rows[i]["PRECIO"]);
                    s.CREATED_AT = Convert.ToDateTime(dt.Rows[i]["FECHA CREACIÓN"]);
                    s.UPDATED_AT = Convert.ToDateTime(dt.Rows[i]["FECHA MODIFICACIÓN"]);
                    listarServicioExtra.Add(s);
                }
                onn.Close();
                return listarServicioExtra;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Método que te busca los Servicios Extra que estan activos segun su id 
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public List<ServicioExtra> buscarServicioExtra(string nom)
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();

                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_SERVICIOEXTRA.BUSCAR_SERVICIOEXTRA", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_NOM", OracleType.VarChar).Value = nom;
                cmd.Parameters.Add("PRM_LISTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<ServicioExtra> buscarServicioExtra = new List<ServicioExtra>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ServicioExtra s = new ServicioExtra();
                    s.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    s.NOMBRE = dt.Rows[i]["NOMBRE"].ToString();
                    s.DESCRIPCION = dt.Rows[i]["DESCRIPCION"].ToString();
                    s.PRECIO = Convert.ToInt32(dt.Rows[i]["PRECIO"]);
                    s.CREATED_AT = Convert.ToDateTime(dt.Rows[i]["FECHA CREACIÓN"]);
                    s.UPDATED_AT = Convert.ToDateTime(dt.Rows[i]["FECHA MODIFICACIÓN"]);
                    buscarServicioExtra.Add(s);
                }
                onn.Close();
                return buscarServicioExtra;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
