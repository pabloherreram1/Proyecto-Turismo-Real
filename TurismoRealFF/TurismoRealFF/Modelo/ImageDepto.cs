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
    public class ImageDepto
    {
        public int ID { get; set; }
        public string IMAGE_PATH { get; set; }
        public int DEPARTAMENTO_ID { get; set; }
        public DateTime CREATED_AT { get; set; }
        public DateTime UPDATED_AT { get; set; }

        public ImageDepto()
        {

        }

        public ImageDepto(int id, string image_path, int departamento_id, DateTime created_at, DateTime updated_at)
        {
            ID = id;
            IMAGE_PATH = image_path;
            DEPARTAMENTO_ID = departamento_id;
            CREATED_AT = created_at;
            UPDATED_AT = updated_at;
        }


        public List<ImageDepto> BuscarID(int iddepto)
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();
                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_DEPTO.BUSCAR_DEPTO_IMAGE", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_IDDEPTO", OracleType.Int32).Value = iddepto;
                cmd.Parameters.Add("PRM_LISTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<ImageDepto> Lista = new List<ImageDepto>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ImageDepto r = new ImageDepto();
                    r.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    r.IMAGE_PATH = dt.Rows[i]["IMAGE_PATH"].ToString();
                    r.DEPARTAMENTO_ID = Convert.ToInt32(dt.Rows[i]["DEPARTAMENTO_ID"]);
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
        public int InsertarID(string image_path, int iddepto)
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();
                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_DEPTO.INSERTAR_IMAGEN", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_IMAGE_PATH", OracleType.VarChar).Value = image_path;
                cmd.Parameters.Add("PRM_IDDEPTO", OracleType.Int32).Value = iddepto;
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
        public int ModificarID(string image_path, int id, int iddepto)
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();
                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_DEPTO.MODIFICAR_IMAGEN", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_IMAGE_PATH", OracleType.VarChar).Value = image_path;
                cmd.Parameters.Add("PRM_IDDEPTO", OracleType.Int32).Value = iddepto;
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
        public int EliminarID(int id)
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();
                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_DEPTO.ELIMINAR_IMAGEN", onn);
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
    }
}
