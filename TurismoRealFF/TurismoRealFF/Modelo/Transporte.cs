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
    public class Transporte
    {
        public int ID { get; set; }
        public string DESTINO { get; set; }
        public int PRECIO { get; set; }
        public int CIUDAD_ID { get; set; }
        public string CIUDAD { get; set; }
        public int CONDUCTOR_ID { get; set; }
        public DateTime CREATED_AT { get; set; }
        public DateTime UPDATED_AT { get; set; }

        public Transporte()
        {

        }

        public Transporte(int id, string destino, int precio, int ciudad_id, string ciudad, int conductor_id, DateTime created_at, DateTime updated_at)
        {
            ID = id;
            DESTINO = destino;
            PRECIO = precio;
            CIUDAD_ID = ciudad_id;
            CIUDAD = ciudad;
            CONDUCTOR_ID = conductor_id;
            CREATED_AT = created_at;
            UPDATED_AT = updated_at;
        }

        public List<Transporte> listartransporte()
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();

                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_TRANSPORTE.LISTAR_TRANSPORTE", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_LISTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);

                List<Transporte> listarTransporte = new List<Transporte>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Transporte t = new Transporte();
                    t.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    t.DESTINO = dt.Rows[i]["DESTINO"].ToString();
                    t.CIUDAD_ID = Convert.ToInt32(dt.Rows[i]["CIUDAD_ID"]);
                    t.CIUDAD = dt.Rows[i]["DESCRIPCION"].ToString();
                    t.CREATED_AT = Convert.ToDateTime(dt.Rows[i]["CREATED_AT"]);
                    t.UPDATED_AT = Convert.ToDateTime(dt.Rows[i]["UPDATED_AT"]);
                    listarTransporte.Add(t);
                }
                onn.Close();
                return listarTransporte;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public int ModificarT(int idt, int preciot, int conductoridt, string fechat)
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();
                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_TRANSPORTE.MODIFICAR_TRANSPORTE", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_ID", OracleType.Int32).Value = idt;
                cmd.Parameters.Add("PRM_PRECIO", OracleType.Int32).Value = preciot;
                cmd.Parameters.Add("PRM_CONDUCTORID", OracleType.Int32).Value = conductoridt;
                cmd.Parameters.Add("PRM_FECHA", OracleType.VarChar).Value = fechat;
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


    }
}
