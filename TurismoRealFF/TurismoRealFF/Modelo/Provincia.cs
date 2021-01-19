using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoRealFF.Modelo
{
    public class Provincia
    {
        public int ID { get; set; }
        public string DESCRIPCION { get; set; }
        public int IDREGION { get; set; }

        public Provincia()
        {

        }

        public Provincia(int id, string descripcion, int idregion)
        {
            ID = id;
            DESCRIPCION = descripcion;
            IDREGION = idregion;
        }

        public List<Provincia> listarProvincia()
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();
                OracleCommand cmd = new OracleCommand("SELECT ID, DESCRIPCION, REGION_ID FROM PROVINCIA", onn);
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<Provincia> listarProvi = new List<Provincia>();
                for (int i = 1; i < dt.Rows.Count; i++)
                {
                    Provincia p = new Provincia
                    {
                        ID = Convert.ToInt32(dt.Rows[i]["ID"]),
                        DESCRIPCION = dt.Rows[i]["DESCRIPCION"].ToString(),
                        IDREGION = Convert.ToInt32(dt.Rows[i]["REGION_ID"])
                    };
                    listarProvi.Add(p);
                }
                onn.Close();
                return listarProvi;
            }
            catch (Exception)
            {

                return null;
            }
        }


        public List<Provincia> listarProvinciaBuscada(int idregion)
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();
                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_REGPROVCIU.BUSCAR_PROVINCIA", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_IDR", OracleType.Int32).Value = idregion;
                cmd.Parameters.Add("PRM_LISTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<Provincia> listarProvi = new List<Provincia>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Provincia p = new Provincia();
                    p.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    p.DESCRIPCION = dt.Rows[i]["DESCRIPCION"].ToString();
                    p.IDREGION = Convert.ToInt32(dt.Rows[i]["REGION_ID"]);
                    listarProvi.Add(p);
                }
                onn.Close();
                return listarProvi;
            }
            catch (Exception)
            {

                return null;
            }
        }
        //public List<Provincia> mps(int idregion)
        //{
        //var llenar = (from m in 
        //              where m.IDREGION = idregion
        //              select new { ID, DESCRIPCION, IDREGION }).ToList();
        //return llenar;
        //cbxIdModalidadContrato.ItemsSource = llenarCoffe;
        //cbxIdModalidadContrato.SelectedValuePath = "idt";
        //cbxIdModalidadContrato.DisplayMemberPath = "nomb";
        //}
    }
}
