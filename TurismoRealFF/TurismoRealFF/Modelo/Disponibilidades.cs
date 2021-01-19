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
    public class Disponibilidades
    {
        public int ID_MANTENCION { get; set; }
        public int ID_RESERVA { get; set; }
        public DateTime FECHA_INI_M { get; set; }
        public DateTime FECHA_TER_M { get; set; }
        public DateTime FECHA_INI_R { get; set; }
        public DateTime FECHA_TER_R { get; set; }

        public Disponibilidades()
        {

        }

        public Disponibilidades(int id_mantencion, int id_reserva, DateTime fecha_ini_m, DateTime fecha_ter_m, DateTime fecha_ini_r, DateTime fecha_ter_r)
        {
            ID_MANTENCION = id_mantencion;
            ID_RESERVA = id_reserva;
            FECHA_INI_M = fecha_ini_m;
            FECHA_TER_M = fecha_ter_m;
            FECHA_INI_R = fecha_ini_r;
            FECHA_TER_R = fecha_ter_r;
        }

        public List<Disponibilidades> ListarDisponibilidad(int idDepto)
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();

                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_MANTENCION.BUSCAR_DISPONIBILIDAD", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_IDDEPTO", OracleType.Int32).Value = idDepto;
                cmd.Parameters.Add("PRM_LISTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<Disponibilidades> listarDisponibilidad = new List<Disponibilidades>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Disponibilidades d = new Disponibilidades();
                    d.ID_MANTENCION = Convert.ToInt32(dt.Rows[i]["MANTENCION_ID"] is DBNull ? 0 : dt.Rows[i]["MANTENCION_ID"]);
                    d.ID_RESERVA = Convert.ToInt32(dt.Rows[i]["RESERVA_ID"] is DBNull ? 0 : dt.Rows[i]["RESERVA_ID"]);
                    d.FECHA_INI_M = Convert.ToDateTime(dt.Rows[i]["FECHA_INI_M"] is DBNull ? null : dt.Rows[i]["FECHA_INI_M"]);
                    d.FECHA_TER_M = Convert.ToDateTime(dt.Rows[i]["FECHA_TER_M"] is DBNull ? null : dt.Rows[i]["FECHA_TER_M"]);
                    d.FECHA_INI_R = Convert.ToDateTime(dt.Rows[i]["FECHA_INI_R"] is DBNull ? null : dt.Rows[i]["FECHA_INI_R"]);
                    d.FECHA_TER_R = Convert.ToDateTime(dt.Rows[i]["FECHA_TER_R"] is DBNull ? null : dt.Rows[i]["FECHA_TER_R"]);
                    listarDisponibilidad.Add(d);
                }
                onn.Close();
                return listarDisponibilidad;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
