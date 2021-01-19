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
    public class Reci
    {
        public int ID { get; set; }
        public string NOMBRE { get; set; }
        public string DIRECCION { get; set; }
        public int FUNCIONARIO_ID { get; set; }
        public int CIUDAD_ID { get; set; }
        public int ESTADO_RECINTO_ID { get; set; }
        public DateTime CREATED_AT { get; set; }
        public DateTime UPDATED_AT { get; set; }
        public string IMAGE_PATH { get; set; }

        public Reci()
        {

        }

        public Reci(int id, string nombre, string direccion, int funcionario_id, int ciudad_id, int estado_recinto_id, DateTime created_at, DateTime updated_at, string image_path)
        {
            ID = id;
            NOMBRE = nombre;
            DIRECCION = direccion;
            FUNCIONARIO_ID = funcionario_id;
            CIUDAD_ID = ciudad_id;
            ESTADO_RECINTO_ID = estado_recinto_id;
            CREATED_AT = created_at;
            UPDATED_AT = updated_at;
            IMAGE_PATH = image_path;
        }

        public int InsertarR(string nombrer, string direccionr, int ciudadidr)
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();
                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_RECINTO.INSERTAR_RECINTO", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_NOMBRE", OracleType.VarChar).Value = nombrer;
                cmd.Parameters.Add("PRM_DIRECCION", OracleType.VarChar).Value = direccionr;
                cmd.Parameters.Add("PRM_CIUDAD_ID", OracleType.Int32).Value = ciudadidr;
                int resp = cmd.ExecuteNonQuery();
                onn.Close();
                cmd.Dispose();
                return 1;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        public int InsertarR2(string nombrer, string direccionr, int ciudadidr, string image_path)
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();
                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_RECINTO.INSERTAR_RECINTO2", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_NOMBRE", OracleType.VarChar).Value = nombrer;
                cmd.Parameters.Add("PRM_DIRECCION", OracleType.VarChar).Value = direccionr;
                cmd.Parameters.Add("PRM_CIUDAD_ID", OracleType.Int32).Value = ciudadidr;
                cmd.Parameters.Add("PRM_IMAGE_PATH", OracleType.VarChar).Value = image_path;
                int resp = cmd.ExecuteNonQuery();
                onn.Close();
                cmd.Dispose();
                return 1;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public int ModificarR(int id, string nombrer, string direccionr, int funcionario_id, int ciudadidr, int estado_id, string image_path)
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();
                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_RECINTO.MODIFICAR_RECINTO", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_ID", OracleType.Int32).Value = id;
                cmd.Parameters.Add("PRM_NOMBRE", OracleType.VarChar).Value = nombrer;
                cmd.Parameters.Add("PRM_DIRECCION", OracleType.VarChar).Value = direccionr;
                cmd.Parameters.Add("PRM_FUNCIONARIO_ID", OracleType.Int32).Value = funcionario_id;
                cmd.Parameters.Add("PRM_CIUDAD_ID", OracleType.Int32).Value = ciudadidr;
                cmd.Parameters.Add("PRM_ESTADO", OracleType.Int32).Value = estado_id;
                cmd.Parameters.Add("PRM_IMAGE_PATH", OracleType.VarChar).Value = image_path;
                int resp = cmd.ExecuteNonQuery();
                onn.Close();
                cmd.Dispose();
                return 1;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public int EliminarR(int id)
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();
                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_RECINTO.ELIMINAR_RECINTO", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_ID", OracleType.Int32).Value = id;
                int resp = cmd.ExecuteNonQuery();
                onn.Close();
                cmd.Dispose();
                return 1;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public List<Reci> ListarR()
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();
                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_RECINTO.LISTAR_RECINTO", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_LISTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<Reci> Lista = new List<Reci>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Reci r = new Reci();
                    r.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    r.NOMBRE = dt.Rows[i]["NOMBRE"].ToString();
                    r.DIRECCION = dt.Rows[i]["DIRECCION"].ToString(); ;
                    r.FUNCIONARIO_ID = Convert.ToInt32(dt.Rows[i]["FUNCIONARIO_ID"]);
                    r.CIUDAD_ID = Convert.ToInt32(dt.Rows[i]["CIUDAD_ID"]);
                    r.ESTADO_RECINTO_ID = Convert.ToInt32(dt.Rows[i]["ESTADO_RECINTO_ID"]);
                    r.CREATED_AT = Convert.ToDateTime(dt.Rows[i]["FECHA CREACIÓN"]);
                    r.UPDATED_AT = Convert.ToDateTime(dt.Rows[i]["FECHA MODIFICACIÓN"]);
                    r.IMAGE_PATH = dt.Rows[i]["IMAGE_PATH"].ToString();
                    Lista.Add(r);
                }
                onn.Close();
                return Lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return null;
            }
        }

        public List<Reci> BuscarR(int id)
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();
                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_RECINTO.BUSCAR_RECINTO", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_IDRECI", OracleType.Int32).Value = id;
                cmd.Parameters.Add("PRM_LISTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<Reci> Lista = new List<Reci>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Reci r = new Reci();
                    r.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    r.NOMBRE = dt.Rows[i]["NOMBRE"].ToString();
                    r.DIRECCION = dt.Rows[i]["DIRECCION"].ToString(); ;
                    r.FUNCIONARIO_ID = Convert.ToInt32(dt.Rows[i]["FUNCIONARIO_ID"]);
                    r.CIUDAD_ID = Convert.ToInt32(dt.Rows[i]["CIUDAD_ID"]);
                    r.ESTADO_RECINTO_ID = Convert.ToInt32(dt.Rows[i]["ESTADO_RECINTO_ID"]);
                    r.CREATED_AT = Convert.ToDateTime(dt.Rows[i]["FECHA CREACIÓN"]);
                    r.UPDATED_AT = Convert.ToDateTime(dt.Rows[i]["FECHA MODIFICACIÓN"]);
                    r.IMAGE_PATH = dt.Rows[i]["IMAGE_PATH"].ToString();
                    Lista.Add(r);
                }
                onn.Close();
                return Lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return null;
            }
        }
    }
}
