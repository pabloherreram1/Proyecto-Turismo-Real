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
    public class Depto
    {
        public int ID { get; set; }
        public string NOMBRE { get; set; }
        public string DESCRIPCION { get; set; }
        public int N_DORMITORIO { get; set; }
        public int N_BANOS { get; set; }
        public int DIMENSION { get; set; }
        public int PRECIO { get; set; }
        public int RECINTO_ID { get; set; }
        public int ESTADO_DPTO_ID { get; set; }
        public DateTime CREATED_AT { get; set; }
        public DateTime UPDATED_AT { get; set; }

        public Depto()
        {

        }

        public Depto(int id, string nombre, string descripcion, int n_dormitorio, int n_banos, int dimension, int precio, int recinto_id, int estado_dpto_id, DateTime created_at, DateTime updated_at)
        {
            ID = id;
            NOMBRE = nombre;
            DESCRIPCION = descripcion;
            N_DORMITORIO = n_dormitorio;
            N_BANOS = n_banos;
            DIMENSION = dimension;
            PRECIO = precio;
            RECINTO_ID = recinto_id;
            ESTADO_DPTO_ID = estado_dpto_id;
            CREATED_AT = created_at;
            UPDATED_AT = updated_at;
        }

        public int InsertarD(string nombre, string descripcion, int n_dormitorio, int n_banos, int dimension, int precio, int recinto_id)
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();
                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_DEPTO.INSERTAR_DEPTO", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_NOMBRE", OracleType.VarChar).Value = nombre;
                cmd.Parameters.Add("PRM_DESCRIPCION", OracleType.VarChar).Value = descripcion;
                cmd.Parameters.Add("PRM_N_DORMITORIO", OracleType.Int32).Value = n_dormitorio;
                cmd.Parameters.Add("PRM_N_BANOS", OracleType.Int32).Value = n_banos;
                cmd.Parameters.Add("PRM_DIMENSION", OracleType.Int32).Value = dimension;
                cmd.Parameters.Add("PRM_PRECIO", OracleType.Int32).Value = precio;
                cmd.Parameters.Add("PRM_RECINTO_ID", OracleType.Int32).Value = recinto_id;
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
        public int InsertarD2(string nombre, string descripcion, int n_dormitorio, int n_banos, int dimension, int precio, int recinto_id, string image_path)
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();
                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_DEPTO.INSERTAR_DEPTO2", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_NOMBRE", OracleType.VarChar).Value = nombre;
                cmd.Parameters.Add("PRM_DESCRIPCION", OracleType.VarChar).Value = descripcion;
                cmd.Parameters.Add("PRM_N_DORMITORIO", OracleType.Int32).Value = n_dormitorio;
                cmd.Parameters.Add("PRM_N_BANOS", OracleType.Int32).Value = n_banos;
                cmd.Parameters.Add("PRM_DIMENSION", OracleType.Int32).Value = dimension;
                cmd.Parameters.Add("PRM_PRECIO", OracleType.Int32).Value = precio;
                cmd.Parameters.Add("PRM_RECINTO_ID", OracleType.Int32).Value = recinto_id;
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

        public int ModificarD(int id, string nombre, string descripcion, int n_dormitorio, int n_banos, int dimension, int precio, int estado)
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();
                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_DEPTO.MODIFICAR_DEPTO", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_ID", OracleType.Int32).Value = id;
                cmd.Parameters.Add("PRM_NOMBRE", OracleType.VarChar).Value = nombre;
                cmd.Parameters.Add("PRM_DESCRIPCION", OracleType.VarChar).Value = descripcion;
                cmd.Parameters.Add("PRM_N_DORMITORIO", OracleType.Int32).Value = n_dormitorio;
                cmd.Parameters.Add("PRM_N_BANOS", OracleType.Int32).Value = n_banos;
                cmd.Parameters.Add("PRM_DIMENSION", OracleType.Int32).Value = dimension;
                cmd.Parameters.Add("PRM_PRECIO", OracleType.Int32).Value = precio;
                cmd.Parameters.Add("PRM_ESTADO", OracleType.Int32).Value = estado;
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

        public int EliminarD(int id)
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();
                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_DEPTO.ELIMINAR_DEPTO", onn);
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

        public List<Depto> ListarD(int recinto_id)
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();
                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_DEPTO.LISTAR_DEPTO", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_RECINTO_ID", OracleType.Int32).Value = recinto_id;
                cmd.Parameters.Add("PRM_LISTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<Depto> Lista = new List<Depto>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Depto r = new Depto();
                    r.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    r.NOMBRE = dt.Rows[i]["NOMBRE"].ToString();
                    r.DESCRIPCION = dt.Rows[i]["DESCRIPCION"].ToString(); ;
                    r.N_DORMITORIO = Convert.ToInt32(dt.Rows[i]["N_DORMITORIO"]);
                    r.N_BANOS = Convert.ToInt32(dt.Rows[i]["N_BANOS"]);
                    r.DIMENSION = Convert.ToInt32(dt.Rows[i]["DIMENSION"]);
                    r.PRECIO = Convert.ToInt32(dt.Rows[i]["PRECIO"]);
                    r.RECINTO_ID = Convert.ToInt32(dt.Rows[i]["RECINTO_ID"]);
                    r.ESTADO_DPTO_ID = Convert.ToInt32(dt.Rows[i]["ESTADO_DPTO_ID"]);
                    r.CREATED_AT = Convert.ToDateTime(dt.Rows[i]["FECHA CREACIÓN"]);
                    r.UPDATED_AT = Convert.ToDateTime(dt.Rows[i]["FECHA MODIFICACIÓN"]);
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

        public List<Depto> BuscarD(int iddepto)
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();
                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_DEPTO.LISTAR_DEPTO", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_IDDEPTO", OracleType.Int32).Value = iddepto;
                cmd.Parameters.Add("PRM_LISTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<Depto> Lista = new List<Depto>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Depto r = new Depto();
                    r.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    r.NOMBRE = dt.Rows[i]["NOMBRE"].ToString();
                    r.DESCRIPCION = dt.Rows[i]["DESCRIPCION"].ToString(); ;
                    r.N_DORMITORIO = Convert.ToInt32(dt.Rows[i]["N_DORMITORIO"]);
                    r.N_BANOS = Convert.ToInt32(dt.Rows[i]["N_BANOS"]);
                    r.DIMENSION = Convert.ToInt32(dt.Rows[i]["DIMENSION"]);
                    r.PRECIO = Convert.ToInt32(dt.Rows[i]["PRECIO"]);
                    r.RECINTO_ID = Convert.ToInt32(dt.Rows[i]["RECINTO_ID"]);
                    r.ESTADO_DPTO_ID = Convert.ToInt32(dt.Rows[i]["ESTADO_DPTO_ID"]);
                    r.CREATED_AT = Convert.ToDateTime(dt.Rows[i]["FECHA CREACIÓN"]);
                    r.UPDATED_AT = Convert.ToDateTime(dt.Rows[i]["FECHA MODIFICACIÓN"]);
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
