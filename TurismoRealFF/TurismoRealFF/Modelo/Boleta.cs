using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoRealFF.Modelo
{
    public class Boleta
    {
        public int ID { get; set; }
        public int ABONO { get; set; }
        public int TOTAL { get; set; }
        public int ESTADO_BOLETA_ID { get; set; }
        public string ESTADO_BOLETA { get; set; }
        public DateTime CREATED_AT { get; set; }
        public DateTime UPDATED_AT { get; set; }
        public int RESERVA_ID { get; set; }

        public Boleta()
        {

        }

        public Boleta(int id, int abono, int total, int reserva_id, int estado_boleta_id, string estado_boleta, DateTime created_at, DateTime updated_at)
        {
            ID = id;
            ABONO = abono;
            TOTAL = total;
            RESERVA_ID = reserva_id;
            ESTADO_BOLETA_ID = estado_boleta_id;
            ESTADO_BOLETA = estado_boleta;
            CREATED_AT = created_at;
            UPDATED_AT = updated_at;
        }

        public List<Boleta> ListarBoleta()
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();
                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_RESERVA.LISTAR_BOLETA", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_LISTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<Boleta> listarBo = new List<Boleta>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Boleta b = new Boleta();
                    b.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    b.ABONO = Convert.ToInt32(dt.Rows[i]["ABONO"]);
                    b.TOTAL = Convert.ToInt32(dt.Rows[i]["TOTAL"]);
                    b.RESERVA_ID = Convert.ToInt32(dt.Rows[i]["RESERVA_ID"]);
                    b.ESTADO_BOLETA_ID = Convert.ToInt32(dt.Rows[i]["ESTADO_BOLETA_ID"]);
                    b.ESTADO_BOLETA = dt.Rows[i]["ESTADO_BOLETA"].ToString();
                    b.CREATED_AT = Convert.ToDateTime(dt.Rows[i]["CREATED_AT"]);
                    b.UPDATED_AT = Convert.ToDateTime(dt.Rows[i]["UPDATED_AT"]);
                    listarBo.Add(b);
                }
                onn.Close();
                return listarBo;
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
