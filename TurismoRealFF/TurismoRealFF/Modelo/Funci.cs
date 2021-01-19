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
    public class Funci
    {
        public int ID { get; set; }
        public string NOMBRE { get; set; }

        public Funci()
        {

        }

        public Funci(int id, string nombre)
        {
            ID = id;
            NOMBRE = nombre;
        }

        public List<Funci> ListarF()
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();
                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_RECINTO.LISTAR_FUNCIONARIO", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_LISTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<Funci> Lista = new List<Funci>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Funci f = new Funci();
                    f.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    f.NOMBRE = dt.Rows[i]["NOMBRE_COMPLETO"].ToString();
                    
                    Lista.Add(f);
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
