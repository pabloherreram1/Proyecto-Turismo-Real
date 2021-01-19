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
    public class Finanza
    {
        public int ID { get; set; }
        public string NOMBRE { get; set; }
        public int PRECIO { get; set; }
        public DateTime FECHA { get; set; }
        public string TIPO { get; set; }

        public Finanza()
        {

        }

        public Finanza(int id, string nombre, int precio, DateTime fecha, string tipo)
        {
            ID = id;
            NOMBRE = nombre;
            PRECIO = precio;
            FECHA = fecha;
            TIPO = tipo;
        }

        public List<Finanza> BusquedaID(int mes,int dia)
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();
                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_FINANZA.BUSCAR_INGRESOS_DIA", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_MES", OracleType.VarChar).Value = mes.ToString();
                cmd.Parameters.Add("PRM_DIA", OracleType.VarChar).Value = dia.ToString();
                cmd.Parameters.Add("PRM_LISTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<Finanza> BusquedaID = new List<Finanza>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Finanza f = new Finanza();
                    f.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    f.NOMBRE = dt.Rows[i]["NOMBRE"].ToString();
                    f.PRECIO = Convert.ToInt32(dt.Rows[i]["PRECIO"]);
                    f.FECHA = Convert.ToDateTime(dt.Rows[i]["UPDATED_AT"]);
                    if (dt.Rows[i]["TIPO"].ToString() == "1")
                    {
                        f.TIPO = "Ingreso";
                    }
                    else
                    {
                        f.TIPO = "Egreso";
                    }
                    BusquedaID.Add(f);
                }
                onn.Close();
                return BusquedaID;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return null;
            }
        }
        public List<Finanza> BusquedaIM(int mes)
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();
                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_FINANZA.BUSCAR_INGRESOS_MES", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_MES", OracleType.VarChar).Value = mes.ToString();
                cmd.Parameters.Add("PRM_LISTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<Finanza> BusquedaID = new List<Finanza>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Finanza f = new Finanza();
                    f.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    f.NOMBRE = dt.Rows[i]["NOMBRE"].ToString();
                    f.PRECIO = Convert.ToInt32(dt.Rows[i]["PRECIO"]);
                    f.FECHA = Convert.ToDateTime(dt.Rows[i]["UPDATED_AT"]);
                    if (dt.Rows[i]["TIPO"].ToString() == "1")
                    {
                        f.TIPO = "Ingreso";
                    }
                    else
                    {
                        f.TIPO = "Egreso";
                    }
                    BusquedaID.Add(f);
                }
                onn.Close();
                return BusquedaID;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return null;
            }
        }
        public List<Finanza> BusquedaIA(int anio)
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();
                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_FINANZA.BUSCAR_INGRESOS_ANIO", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_ANIO", OracleType.VarChar).Value = anio.ToString();
                cmd.Parameters.Add("PRM_LISTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<Finanza> BusquedaID = new List<Finanza>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Finanza f = new Finanza();
                    f.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    f.NOMBRE = dt.Rows[i]["NOMBRE"].ToString();
                    f.PRECIO = Convert.ToInt32(dt.Rows[i]["PRECIO"]);
                    f.FECHA = Convert.ToDateTime(dt.Rows[i]["UPDATED_AT"]);
                    if (dt.Rows[i]["TIPO"].ToString() == "1")
                    {
                        f.TIPO = "Ingreso";
                    }
                    else
                    {
                        f.TIPO = "Egreso";
                    }
                    BusquedaID.Add(f);
                }
                onn.Close();
                return BusquedaID;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return null;
            }
        }
        public List<Finanza> BusquedaED(int mes, int dia)
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();
                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_FINANZA.BUSCAR_EGRESOS_DIA", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_MES", OracleType.VarChar).Value = mes.ToString();
                cmd.Parameters.Add("PRM_DIA", OracleType.VarChar).Value = dia.ToString();
                cmd.Parameters.Add("PRM_LISTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<Finanza> BusquedaID = new List<Finanza>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Finanza f = new Finanza();
                    f.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    f.NOMBRE = dt.Rows[i]["NOMBRE"].ToString();
                    f.PRECIO = Convert.ToInt32(dt.Rows[i]["PRECIO"]);
                    f.FECHA = Convert.ToDateTime(dt.Rows[i]["UPDATED_AT"]);
                    if (dt.Rows[i]["TIPO"].ToString() == "1")
                    {
                        f.TIPO = "Ingreso";
                    }
                    else
                    {
                        f.TIPO = "Egreso";
                    }
                    BusquedaID.Add(f);
                }
                onn.Close();
                return BusquedaID;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return null;
            }
        }
        public List<Finanza> BusquedaEM(int mes)
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();
                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_FINANZA.BUSCAR_EGRESOS_MES", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_MES", OracleType.VarChar).Value = mes.ToString();
                cmd.Parameters.Add("PRM_LISTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<Finanza> BusquedaID = new List<Finanza>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Finanza f = new Finanza();
                    f.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    f.NOMBRE = dt.Rows[i]["NOMBRE"].ToString();
                    f.PRECIO = Convert.ToInt32(dt.Rows[i]["PRECIO"]);
                    f.FECHA = Convert.ToDateTime(dt.Rows[i]["UPDATED_AT"]);
                    if (dt.Rows[i]["TIPO"].ToString() == "1")
                    {
                        f.TIPO = "Ingreso";
                    }
                    else
                    {
                        f.TIPO = "Egreso";
                    }
                    BusquedaID.Add(f);
                }
                onn.Close();
                return BusquedaID;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return null;
            }
        }
        public List<Finanza> BusquedaEA(int anio)
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();
                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_FINANZA.BUSCAR_EGRESOS_ANIO", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_ANIO", OracleType.VarChar).Value = anio.ToString();
                cmd.Parameters.Add("PRM_LISTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<Finanza> BusquedaID = new List<Finanza>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Finanza f = new Finanza();
                    f.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    f.NOMBRE = dt.Rows[i]["NOMBRE"].ToString();
                    f.PRECIO = Convert.ToInt32(dt.Rows[i]["PRECIO"]);
                    f.FECHA = Convert.ToDateTime(dt.Rows[i]["UPDATED_AT"]);
                    if (dt.Rows[i]["TIPO"].ToString() == "1")
                    {
                        f.TIPO = "Ingreso";
                    }
                    else
                    {
                        f.TIPO = "Egreso";
                    }
                    BusquedaID.Add(f);
                }
                onn.Close();
                return BusquedaID;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return null;
            }
        }
        public List<Finanza> BusquedaTD(int mes, int dia)
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();
                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_FINANZA.BUSCAR_TODO_DIA", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_MES", OracleType.VarChar).Value = mes.ToString();
                cmd.Parameters.Add("PRM_DIA", OracleType.VarChar).Value = dia.ToString();
                cmd.Parameters.Add("PRM_LISTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<Finanza> BusquedaID = new List<Finanza>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Finanza f = new Finanza();
                    f.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    f.NOMBRE = dt.Rows[i]["NOMBRE"].ToString();
                    f.PRECIO = Convert.ToInt32(dt.Rows[i]["PRECIO"]);
                    f.FECHA = Convert.ToDateTime(dt.Rows[i]["UPDATED_AT"]);
                    if (dt.Rows[i]["TIPO"].ToString() == "1")
                    {
                        f.TIPO = "Ingreso";
                    }
                    else
                    {
                        f.TIPO = "Egreso";
                    }
                    BusquedaID.Add(f);
                }
                onn.Close();
                return BusquedaID;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return null;
            }
        }
        public List<Finanza> BusquedaTM(int mes)
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();
                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_FINANZA.BUSCAR_TODO_MES", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_MES", OracleType.VarChar).Value = mes.ToString();
                cmd.Parameters.Add("PRM_LISTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<Finanza> BusquedaID = new List<Finanza>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Finanza f = new Finanza();
                    f.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    f.NOMBRE = dt.Rows[i]["NOMBRE"].ToString();
                    f.PRECIO = Convert.ToInt32(dt.Rows[i]["PRECIO"]);
                    f.FECHA = Convert.ToDateTime(dt.Rows[i]["UPDATED_AT"]);
                    if (dt.Rows[i]["TIPO"].ToString() == "1")
                    {
                        f.TIPO = "Ingreso";
                    }
                    else
                    {
                        f.TIPO = "Egreso";
                    }
                    BusquedaID.Add(f);
                }
                onn.Close();
                return BusquedaID;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return null;
            }
        }
        public List<Finanza> BusquedaTA(int anio)
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();
                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_FINANZA.BUSCAR_TODO_ANIO", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_ANIO", OracleType.VarChar).Value = anio.ToString();
                cmd.Parameters.Add("PRM_LISTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<Finanza> BusquedaID = new List<Finanza>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Finanza f = new Finanza();
                    f.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    f.NOMBRE = dt.Rows[i]["NOMBRE"].ToString();
                    f.PRECIO = Convert.ToInt32(dt.Rows[i]["PRECIO"]);
                    f.FECHA = Convert.ToDateTime(dt.Rows[i]["UPDATED_AT"]);
                    if (dt.Rows[i]["TIPO"].ToString() == "1")
                    {
                        f.TIPO = "Ingreso";
                    }
                    else
                    {
                        f.TIPO = "Egreso";
                    }
                    BusquedaID.Add(f);
                }
                onn.Close();
                return BusquedaID;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return null;
            }
        }
    }
}
