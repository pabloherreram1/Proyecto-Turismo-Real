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
    public class Conductor
    {
        public int ID { get; set; }
        public string DIGITO { get; set; }
        public string NOMBRE { get; set; }
        //public string APELLIDO { get; set; }
        public int TELEFONO { get; set; }
        //public string EMAIL { get; set; }
        //public int VEHICULO_ID { get; set; }
        //public int PROVINCIA_ID { get; set; }
        //public DateTime CREATED_AT { get; set; }
        //public DateTime UPDATED_AT { get; set; }

        public Conductor()
        {

        }

        public Conductor(int id, string digito, string nombre, int telefono)//, string apellido, string email, int vehiculo_id, int provincia_id, DateTime created_at, DateTime updated_at)
        {
            ID = id;
            DIGITO = digito;
            NOMBRE = nombre;
            //APELLIDO = apellido;
            TELEFONO = telefono;
            //EMAIL = email;
            //VEHICULO_ID = vehiculo_id;
            //PROVINCIA_ID = provincia_id;
            //CREATED_AT = created_at;
            //UPDATED_AT = updated_at;
        }

        public List<Conductor> Buscarconductor(int idciu)
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();

                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_TRANSPORTE.BUSCAR_CONDUCTOR", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_IDCIU", OracleType.Int32).Value = idciu;
                cmd.Parameters.Add("PRM_LISTADO", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<Conductor> buscarConductor = new List<Conductor>();
                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Conductor c = new Conductor();
                        c.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                        c.DIGITO = dt.Rows[i]["DIGITO"].ToString();
                        c.NOMBRE = dt.Rows[i]["NOMBRE COMPLETO"].ToString();
                        //c.APELLIDO = dt.Rows[i]["APELLIDO"].ToString();
                        c.TELEFONO = Convert.ToInt32(dt.Rows[i]["TELEFONO"]);
                        buscarConductor.Add(c);
                    }
                }
                else
                {

                    Conductor c = new Conductor();
                    buscarConductor.Add(c);
                }

                onn.Close();
                return buscarConductor;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

    }
}
