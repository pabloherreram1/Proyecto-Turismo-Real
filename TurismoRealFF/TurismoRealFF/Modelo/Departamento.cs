using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoRealFF.Modelo
{
    public class Departamento
    {
        public int ID { get; set; }
        public string NOMBRE { get; set; }
        public int RECINTO_ID { get; set; }

        public Departamento()
        {

        }

        public Departamento(int id, string nombre, int recinto_id)
        {
            ID = id;
            NOMBRE = nombre;
            RECINTO_ID = recinto_id;
        }


        public List<Departamento> ListarDeptoBuscada(int idrecinto)
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();
                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_PRODUCTO.BUSCAR_DEPTO", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_IDR", OracleType.Int32).Value = idrecinto;
                cmd.Parameters.Add("PRM_LISTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                var n = da.Fill(dt);
                List<Departamento> listarDepto = new List<Departamento>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Departamento d = new Departamento();
                    d.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    d.NOMBRE = dt.Rows[i]["NOMBRE"].ToString();
                    d.RECINTO_ID = Convert.ToInt32(dt.Rows[i]["RECINTO_ID"]);
                    listarDepto.Add(d);
                }
                onn.Close();
                return listarDepto;
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
