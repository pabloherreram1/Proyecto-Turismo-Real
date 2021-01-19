using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoRealFF.Modelo
{
    public class Ciudad
    {
        public int ID { get; set; }
        public string DESCRIPCION { get; set; }
        public int IDPROVINCIA { get; set; }

        public Ciudad()
        {

        }

        public Ciudad(int id, string descripcion, int idprovincia)
        {
            ID = id;
            DESCRIPCION = descripcion;
            IDPROVINCIA = idprovincia;
        }

        public List<Ciudad> listarCiudad()
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();
                OracleCommand cmd = new OracleCommand("SELECT ID, DESCRIPCION, PROVINCIA_ID FROM CIUDAD", onn);
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<Ciudad> listarCiudad = new List<Ciudad>();
                for (int i = 1; i <= dt.Rows.Count; i++)
                {
                    Ciudad c = new Ciudad
                    {
                        ID = Convert.ToInt32(dt.Rows[i]["ID"]),
                        DESCRIPCION = dt.Rows[i]["DESCRIPCION"].ToString(),
                        IDPROVINCIA = Convert.ToInt32(dt.Rows[i]["PROVINCIA_ID"])
                    };
                    listarCiudad.Add(c);
                }
                onn.Close();
                return listarCiudad;
            }
            catch (Exception)
            {

                return null;
            }
        }


        public List<Ciudad> listarCiudadBuscada(int idprovincia)
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();
                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_REGPROVCIU.BUSCAR_CIUDAD", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_IDP", OracleType.Int32).Value = idprovincia;
                cmd.Parameters.Add("PRM_LISTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<Ciudad> listarCiu = new List<Ciudad>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Ciudad c = new Ciudad();
                    c.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    c.DESCRIPCION = dt.Rows[i]["DESCRIPCION"].ToString();
                    c.IDPROVINCIA = Convert.ToInt32(dt.Rows[i]["PROVINCIA_ID"]);
                    listarCiu.Add(c);
                }
                onn.Close();
                return listarCiu;
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
