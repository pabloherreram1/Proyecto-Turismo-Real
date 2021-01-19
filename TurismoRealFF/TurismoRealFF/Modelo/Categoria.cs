using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoRealFF.Modelo
{
    public class Categoria
    {
        public int ID { get; set; }
        public string DESCRIPCION { get; set; }

        public Categoria()
        {

        }

        public Categoria(int id, string descripcion)
        {
            ID = id;
            DESCRIPCION = descripcion;
        }

        public List<Categoria> ListarCategoria()
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();
                OracleCommand cmd = new OracleCommand("SELECT ID, DESCRIPCION FROM CATEGORIA ORDER BY ID ASC", onn);
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<Categoria> listarCategoria = new List<Categoria>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Categoria c = new Categoria
                    {
                        ID = Convert.ToInt32(dt.Rows[i]["ID"]),
                        DESCRIPCION = dt.Rows[i]["DESCRIPCION"].ToString()
                    };
                    listarCategoria.Add(c);
                }
                onn.Close();
                return listarCategoria;
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
