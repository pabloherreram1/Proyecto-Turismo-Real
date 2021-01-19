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
    public class Mantencion
    {
        public int ID { get; set; }
        public string DESCRIPCION { get; set; }
        public int TOTAL { get; set; }
        public int DEPARTAMENTO_ID { get; set; }
        public int PRODUCTO_ID { get; set; }
        public DateTime FECHA_INICIO { get; set; }
        public DateTime FECHA_TERMINO { get; set; }

        public Mantencion()
        {

        }

        public Mantencion(int id, string descripcion, int total, int departamento_id, int producto_id, DateTime fecha_inicio, DateTime fecha_termino)
        {
            ID = id;
            DESCRIPCION = descripcion;
            TOTAL = total;
            DEPARTAMENTO_ID = departamento_id;
            PRODUCTO_ID = producto_id;
            FECHA_INICIO = fecha_inicio;
            FECHA_TERMINO = fecha_termino;
        }

        public List<Mantencion> BuscarMantencion(int idDe, int idPro)
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();

                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_MANTENCION.BUSCAR_MANTENCION", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_IDDEPARTAMENTO", OracleType.Int32).Value = idDe;
                cmd.Parameters.Add("PRM_IDPRODUCTO", OracleType.Int32).Value = idPro;
                cmd.Parameters.Add("PRM_LISTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<Mantencion> buscarMantencion = new List<Mantencion>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Mantencion m = new Mantencion();
                    m.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    m.DESCRIPCION = dt.Rows[i]["DECRIPCION"].ToString();
                    m.TOTAL = Convert.ToInt32(dt.Rows[i]["TOTAL"]);
                    m.DEPARTAMENTO_ID = Convert.ToInt32(dt.Rows[i]["ID DEPARTAMENTO"]);
                    m.PRODUCTO_ID = Convert.ToInt32(dt.Rows[i]["ID PRODUCTO"]);
                    m.FECHA_INICIO = Convert.ToDateTime(dt.Rows[i]["FECHA CREACIÓN"]);
                    m.FECHA_TERMINO = Convert.ToDateTime(dt.Rows[i]["FECHA MODIFICACIÓN"]);
                    buscarMantencion.Add(m);
                }
                onn.Close();
                return buscarMantencion;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public int InsertarMantencionRDP(string descripcionm, int totalm, int departamentoidm, int productoidm, string fechainim, string fechaTer)
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();
                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_MANTENCION.INSERTAR_MANTENCION", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_DESCRIPCION", OracleType.Clob).Value = descripcionm;
                cmd.Parameters.Add("PRM_TOTAL", OracleType.Int32).Value = totalm;
                cmd.Parameters.Add("PRM_DEPARTAMENTOID", OracleType.Int32).Value = departamentoidm;
                cmd.Parameters.Add("PRM_PRODUCTOID", OracleType.Int32).Value = productoidm;
                cmd.Parameters.Add("PRM_FECHAINI", OracleType.VarChar).Value = fechainim;
                cmd.Parameters.Add("PRM_FECHATER", OracleType.VarChar).Value = fechaTer;
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

        public int InsertarMantencionRD(string descripcionm, int totalm, int departamentoidm, string fechainim, string fechaTer)
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();
                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_MANTENCION.INSERTAR_MANTENCION2", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_DESCRIPCION", OracleType.Char).Value = descripcionm;
                cmd.Parameters.Add("PRM_TOTAL", OracleType.Int32).Value = totalm;
                cmd.Parameters.Add("PRM_DEPARTAMENTOID", OracleType.Int32).Value = departamentoidm;
                cmd.Parameters.Add("PRM_FECHAINI", OracleType.VarChar).Value = fechainim;
                cmd.Parameters.Add("PRM_FECHATER", OracleType.VarChar).Value = fechaTer;
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

        public int InsertarMantencionR(string descripcionm, int totalm, int recintoidm, string fechainim, string fechaTer)
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();
                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_MANTENCION.INSERTAR_MANTENCION3", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_DESCRIPCION", OracleType.Char).Value = descripcionm;
                cmd.Parameters.Add("PRM_TOTAL", OracleType.Int32).Value = totalm;
                cmd.Parameters.Add("PRM_RECINTOID", OracleType.Int32).Value = recintoidm;
                cmd.Parameters.Add("PRM_FECHAINI", OracleType.VarChar).Value = fechainim;
                cmd.Parameters.Add("PRM_FECHATER", OracleType.VarChar).Value = fechaTer;
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

        public int ModificarMantencion(int idmantencion, string descripcionm, int totalm, string fechainim, string fechaTer)
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();
                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_MANTENCION.MODIFICAR_MANTENCION", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_ID", OracleType.Int32).Value = idmantencion;
                cmd.Parameters.Add("PRM_DESCRIPCION", OracleType.Char).Value = descripcionm;
                cmd.Parameters.Add("PRM_TOTAL", OracleType.Int32).Value = totalm;
                cmd.Parameters.Add("PRM_FECHAINI", OracleType.VarChar).Value = fechainim;
                cmd.Parameters.Add("PRM_FECHATER", OracleType.VarChar).Value = fechaTer;
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

        public int EliminarMantencion(int idm)
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();
                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_MANTENCION.ELIMINAR_MANTENCION", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_ID", OracleType.Int32).Value = idm;
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
    }
}
