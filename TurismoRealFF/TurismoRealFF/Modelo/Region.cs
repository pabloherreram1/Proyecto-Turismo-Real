using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoRealFF.Modelo
{
    public class Region
    {
        public int ID { get; set; }
        public string DESCRIPCION { get; set; }

        public Region()
        {

        }

        public Region(int id, string descripcion)
        {
            ID = id;
            DESCRIPCION = descripcion;
        }

        public List<Region> listarRegion()
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();
                OracleCommand cmd = new OracleCommand("SELECT ID, DESCRIPCION FROM REGION", onn);
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<Region> listarRegion = new List<Region>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Region r = new Region
                    {
                        ID = Convert.ToInt32(dt.Rows[i]["ID"]),
                        DESCRIPCION = dt.Rows[i]["DESCRIPCION"].ToString()
                    };
                    listarRegion.Add(r);
                }
                onn.Close();
                return listarRegion;
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
