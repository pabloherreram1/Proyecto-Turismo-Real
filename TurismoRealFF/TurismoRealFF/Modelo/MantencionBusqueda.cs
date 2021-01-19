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
    public class MantencionBusqueda
    {
        public int ID { get; set; }
        public string RECINTO { get; set; }
        public string DEPTO { get; set; }
        public string PRODUCTO { get; set; }
        public string DESCRIPCION { get; set; }
        public int TOTAL { get; set; }
        public DateTime FECHA_INI { get; set; }
        public DateTime FECHA_TER { get; set; }

        public MantencionBusqueda()
        {
                     
        }

        public MantencionBusqueda(int id, string recinto, string depto, string producto, string descripcion, int total, DateTime fecha_ini, DateTime fecha_ter)
        {
            ID = id;
            RECINTO = recinto;
            DEPTO = depto;
            PRODUCTO = producto;
            DESCRIPCION = descripcion;
            TOTAL = total;
            FECHA_INI = fecha_ini;
            FECHA_TER = fecha_ter;
        }

        public List<MantencionBusqueda> BuscarMantencion(int idDe)
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();

                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_MANTENCION.BUSCAR_MANTENCION", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_IDDEPTO", OracleType.Int32).Value = idDe;
                cmd.Parameters.Add("PRM_LISTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<MantencionBusqueda> buscarMantencion = new List<MantencionBusqueda>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    MantencionBusqueda m = new MantencionBusqueda();
                    m.ID = Convert.ToInt32(dt.Rows[i]["MANTENCION_ID"]);
                    m.RECINTO = dt.Rows[i]["RECINTO"].ToString();
                    m.DEPTO = dt.Rows[i]["DEPTO"].ToString();
                    m.PRODUCTO = dt.Rows[i]["PRODUCTO"].ToString();
                    m.DESCRIPCION = dt.Rows[i]["DESCRIPCION"].ToString();
                    m.TOTAL = Convert.ToInt32(dt.Rows[i]["TOTAL"]);
                    m.FECHA_INI = Convert.ToDateTime(dt.Rows[i]["FECHA_INI_M"]);
                    m.FECHA_TER = Convert.ToDateTime(dt.Rows[i]["FECHA_TER_M"]);
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


    }
}
