using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoRealFF.Modelo
{
    public class Recinto
    {
        public int ID { get; set; }
        public string NOMBRE { get; set; }
        public string DIRECCION { get; set; }

        public Recinto()
        {

        }

        public Recinto(int id, string nombre, string direccion)
        {
            ID = id;
            NOMBRE = nombre;
            DIRECCION = direccion;
        }

        

        public List<Recinto> ListarRecinto()
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();
                OracleCommand cmd = new OracleCommand("SELECT ID, NOMBRE, DIRECCION FROM RECINTO WHERE ESTADO_RECINTO_ID = 1 ORDER BY ID ASC", onn);
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<Recinto> listarRecinto = new List<Recinto>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Recinto r = new Recinto
                    {
                        ID = Convert.ToInt32(dt.Rows[i]["ID"]),
                        NOMBRE = dt.Rows[i]["NOMBRE"].ToString(),
                        DIRECCION = dt.Rows[i]["DIRECCION"].ToString()
                    };
                    listarRecinto.Add(r);
                }
                onn.Close();
                return listarRecinto;
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
