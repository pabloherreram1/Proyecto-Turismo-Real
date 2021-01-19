using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TurismoRealFF.Modelo
{
    public class Producto
    {
        public int ID { get; set; }
        public string NOMBRE { get; set; }
        public string COLOR { get; set; }
        public string PESO { get; set; }
        public string DIMENSION { get; set; }
        public int CATEGORIA_ID { get; set; }
        public string CATEGORIA { get; set; }
        public int INVENTARIO_ID { get; set; }
        public int DEPARTAMENTO_ID { get; set; }
        public int PRECIO { get; set; }

        public Producto()
        {

        }

        public Producto(int id, string nombre, string color, string peso, string dimension, int categoria_id, string categoria, int inventario_id, int departamento_id, int precio)
        {
            ID = id;
            NOMBRE = nombre;
            COLOR = color;
            PESO = peso;
            DIMENSION = dimension;
            CATEGORIA_ID = categoria_id;
            CATEGORIA = categoria;
            INVENTARIO_ID = inventario_id;
            DEPARTAMENTO_ID = departamento_id;
            PRECIO = precio;
        }


        public int InsertarP(string nombrep, string colorp, string pesop, string dimensionp, int categoriaidp, int inventarioidp, int preciop)
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();
                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_PRODUCTO.INSERTAR_PRODUCTO", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_NOMBRE", OracleType.VarChar).Value = nombrep;
                cmd.Parameters.Add("PRM_COLOR", OracleType.VarChar).Value = colorp;
                cmd.Parameters.Add("PRM_PESO", OracleType.VarChar).Value = pesop;
                cmd.Parameters.Add("PRM_DIMENSION", OracleType.VarChar).Value = dimensionp;
                cmd.Parameters.Add("PRM_INVENTARIOID", OracleType.Int32).Value = inventarioidp;
                cmd.Parameters.Add("PRM_CATEGORIAID", OracleType.Int32).Value = categoriaidp;
                cmd.Parameters.Add("PRM_PRECIO", OracleType.Int32).Value = preciop;
                int resp = cmd.ExecuteNonQuery();
                onn.Close();
                cmd.Dispose();
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public List<Producto> ListarProducto()
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();

                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_PRODUCTO.LISTAR_PRODUCTO", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_LISTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);

                List<Producto> listarProducto = new List<Producto>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Producto p = new Producto();
                    p.INVENTARIO_ID = Convert.ToInt32(dt.Rows[i]["INVENTARIO_ID"]);
                    p.DEPARTAMENTO_ID = Convert.ToInt32(dt.Rows[i]["DEPARTAMENTO_ID"]);
                    p.CATEGORIA_ID = Convert.ToInt32(dt.Rows[i]["CATEGORIA_ID"]);
                    p.CATEGORIA = dt.Rows[i]["DESCRIPCION"].ToString();
                    p.ID = Convert.ToInt32(dt.Rows[i]["PRODUCTO_ID"]);
                    p.NOMBRE = dt.Rows[i]["NOMBRE_PRO"].ToString();
                    p.COLOR = dt.Rows[i]["COLOR"].ToString();
                    p.PESO = dt.Rows[i]["PESO"].ToString();
                    p.DIMENSION = dt.Rows[i]["DIMENSION"].ToString();
                    p.PRECIO = Convert.ToInt32(dt.Rows[i]["PRECIO"]);
                    listarProducto.Add(p);
                }
                onn.Close();
                return listarProducto;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public List<Producto> BuscarProductoDepto(int iddepto)
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();

                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_PRODUCTO.BUSCAR_PRODUCTO_DEPTO", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_IDDPTO", OracleType.Int32).Value = iddepto;
                cmd.Parameters.Add("PRM_LISTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<Producto> buscarProductoDepto = new List<Producto>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Producto p = new Producto();
                    p.INVENTARIO_ID = Convert.ToInt32(dt.Rows[i]["INVENTARIO_ID"]);
                    p.DEPARTAMENTO_ID = Convert.ToInt32(dt.Rows[i]["DEPARTAMENTO_ID"]);
                    p.CATEGORIA_ID = Convert.ToInt32(dt.Rows[i]["CATEGORIA_ID"]);
                    p.CATEGORIA = dt.Rows[i]["DESCRIPCION"].ToString();
                    p.ID = Convert.ToInt32(dt.Rows[i]["PRODUCTO_ID"]);
                    p.NOMBRE = dt.Rows[i]["NOMBRE_PRO"].ToString();
                    p.COLOR = dt.Rows[i]["COLOR"].ToString();
                    p.PESO = dt.Rows[i]["PESO"].ToString();
                    p.DIMENSION = dt.Rows[i]["DIMENSION"].ToString();
                    p.PRECIO = Convert.ToInt32(dt.Rows[i]["PRECIO"]);
                    buscarProductoDepto.Add(p);
                }
                onn.Close();
                return buscarProductoDepto;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public int BuscarInventario(int iddepto)
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();

                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_PRODUCTO.BUSCAR_INVENTARIO", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_IDDPTO", OracleType.Int32).Value = iddepto;
                cmd.Parameters.Add("PRM_IDINV", OracleType.Int32).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                Producto p = new Producto();
                p.INVENTARIO_ID = Convert.ToInt32(cmd.Parameters["PRM_IDINV"].Value);
                int var = p.INVENTARIO_ID;
                onn.Close();
                return var;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
    }
}
