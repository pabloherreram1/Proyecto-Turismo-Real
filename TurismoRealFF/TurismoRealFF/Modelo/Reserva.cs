using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TurismoRealFF.Controlador;

namespace TurismoRealFF.Modelo
{
    public class Reserva
    {
        public int ID { get; set; }
        public int PRECIO { get; set; }
        public DateTime FECHA_INICIO { get; set; }
        public DateTime FECHA_TERMINO { get; set; }
        public string TIPO { get; set; }

        public Reserva()
        {

        }

        public Reserva(int id, int precio, int departamento, DateTime fecha_inicio, DateTime fecha_termino, string tipo)
        {
            ID = id;
            PRECIO = precio;
            FECHA_INICIO = fecha_inicio;
            FECHA_TERMINO = fecha_termino;
            TIPO = tipo;
        }

        public List<Reserva> BusquedaR(int depto)
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();
                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_RESERVA.BUSCAR_RESERVA", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_DEPTO", OracleType.Number).Value = depto;
                cmd.Parameters.Add("PRM_LISTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<Reserva> BusquedaReserva = new List<Reserva>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Reserva r = new Reserva();
                    r.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    int idr = BusquedaReservaPrecioAcomp(r.ID);
                    r.PRECIO = idr;
                    r.FECHA_INICIO = Convert.ToDateTime(dt.Rows[i]["FECHA_INICIO"]);
                    r.FECHA_TERMINO = Convert.ToDateTime(dt.Rows[i]["FECHA_TERMINO"]);
                    r.TIPO = "RESERVA";
                    BusquedaReserva.Add(r);
                }
                onn.Close();
                return BusquedaReserva;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Error: " + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ClLoggerErrores.Mensaje(ex.ToString());
                return null;
            }
        }

        public List<Reserva> BusquedaRD(int depto, int mes, int dia)
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();
                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_RESERVA.BUSCAR_RESERVA_DIA", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_DEPTO", OracleType.Number).Value = depto;
                cmd.Parameters.Add("PRM_MES", OracleType.VarChar).Value = mes.ToString();
                cmd.Parameters.Add("PRM_DIA", OracleType.VarChar).Value = dia.ToString();
                cmd.Parameters.Add("PRM_LISTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<Reserva> BusquedaReserva = new List<Reserva>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Reserva r = new Reserva();
                    r.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    int idr = BusquedaReservaPrecioAcomp(r.ID);
                    r.PRECIO = idr;
                    r.FECHA_INICIO = Convert.ToDateTime(dt.Rows[i]["FECHA_INICIO"]);
                    r.FECHA_TERMINO = Convert.ToDateTime(dt.Rows[i]["FECHA_TERMINO"]);
                    r.TIPO = "RESERVA";
                    BusquedaReserva.Add(r);
                }
                onn.Close();
                return BusquedaReserva;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Error: " + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ClLoggerErrores.Mensaje(ex.ToString());
                return null;
            }
        }
        public List<Reserva> BusquedaRM(int depto, int mes)
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();
                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_RESERVA.BUSCAR_RESERVA_MES", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_DEPTO", OracleType.Number).Value = depto;
                cmd.Parameters.Add("PRM_MES", OracleType.VarChar).Value = mes.ToString();
                cmd.Parameters.Add("PRM_LISTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<Reserva> BusquedaReserva = new List<Reserva>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Reserva r = new Reserva();
                    r.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    int idr = BusquedaReservaPrecioAcomp(r.ID);
                    r.PRECIO = idr;
                    r.FECHA_INICIO = Convert.ToDateTime(dt.Rows[i]["FECHA_INICIO"]);
                    r.FECHA_TERMINO = Convert.ToDateTime(dt.Rows[i]["FECHA_TERMINO"]);
                    r.TIPO = "RESERVA";
                    BusquedaReserva.Add(r);
                }
                onn.Close();
                return BusquedaReserva;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Error: " + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ClLoggerErrores.Mensaje(ex.ToString());
                return null;
            }
        }
        public List<Reserva> BusquedaRA(int depto, int anio)
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();
                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_RESERVA.BUSCAR_RESERVA_ANIO", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_DEPTO", OracleType.Number).Value = depto;
                cmd.Parameters.Add("PRM_ANIO", OracleType.Number).Value = anio;
                cmd.Parameters.Add("PRM_LISTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<Reserva> BusquedaReserva = new List<Reserva>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Reserva r = new Reserva();
                    r.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    int idr = BusquedaReservaPrecioAcomp(r.ID);
                    r.PRECIO = idr;
                    r.FECHA_INICIO = Convert.ToDateTime(dt.Rows[i]["FECHA_INICIO"]);
                    r.FECHA_TERMINO = Convert.ToDateTime(dt.Rows[i]["FECHA_TERMINO"]);
                    r.TIPO = "RESERVA";
                    BusquedaReserva.Add(r);
                }
                onn.Close();
                return BusquedaReserva;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Error: " + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ClLoggerErrores.Mensaje(ex.ToString());
                return null;
            }
        }
        public int BusquedaReservaPrecioAcomp(int reserva)
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();
                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_RESERVA.BUSCAR_PRESERVA_PRECIO_ACOMP", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_RESERVAS", OracleType.VarChar).Value = reserva;
                cmd.Parameters.Add("PRM_RESULTADO", OracleType.Number).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                int res = Convert.ToInt32(cmd.Parameters["PRM_RESULTADO"].Value);
                
                onn.Close();
                return res;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Error: " + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ClLoggerErrores.Mensaje(ex.ToString());
                return 0;
            }
        }

        public List<Reserva> BusquedaTuD(int depto, int mes, int dia, DateTime fecha_ini, DateTime fecha_ter)
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();
                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_RESERVA.BUSCAR_TURISMO_DIA", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_DEPTO", OracleType.Number).Value = depto;
                cmd.Parameters.Add("PRM_MES", OracleType.VarChar).Value = mes.ToString();
                cmd.Parameters.Add("PRM_DIA", OracleType.VarChar).Value = dia.ToString();
                cmd.Parameters.Add("PRM_LISTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<Reserva> BusquedaTuD = new List<Reserva>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Reserva r = new Reserva();
                    r.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    r.PRECIO = Convert.ToInt32(dt.Rows[i]["precio_tour"]);
                    r.FECHA_INICIO = fecha_ini;
                    r.FECHA_TERMINO = fecha_ter;
                    r.TIPO = "TURISMO";
                    BusquedaTuD.Add(r);
                }
                onn.Close();
                return BusquedaTuD;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Error: " + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ClLoggerErrores.Mensaje(ex.ToString());
                return null;
            }
        }
        public List<Reserva> BusquedaTuM(int depto, int mes, DateTime fecha_ini, DateTime fecha_ter)
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();
                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_RESERVA.BUSCAR_TURISMO_MES", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_DEPTO", OracleType.Number).Value = depto;
                cmd.Parameters.Add("PRM_MES", OracleType.VarChar).Value = mes.ToString();
                cmd.Parameters.Add("PRM_LISTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<Reserva> BusquedaTuM = new List<Reserva>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Reserva r = new Reserva();
                    r.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    r.PRECIO = Convert.ToInt32(dt.Rows[i]["precio_tour"]);
                    r.FECHA_INICIO = fecha_ini;
                    r.FECHA_TERMINO = fecha_ter;
                    r.TIPO = "TURISMO";
                    BusquedaTuM.Add(r);
                }
                onn.Close();
                return BusquedaTuM;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Error: " + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ClLoggerErrores.Mensaje(ex.ToString());
                return null;
            }
        }
        public List<Reserva> BusquedaTuA(int depto, int anio, DateTime fecha_ini, DateTime fecha_ter)
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();
                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_RESERVA.BUSCAR_TURISMO_ANIO", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_DEPTO", OracleType.Number).Value = depto;
                cmd.Parameters.Add("PRM_ANIO", OracleType.VarChar).Value = anio.ToString();
                cmd.Parameters.Add("PRM_LISTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<Reserva> BusquedaTuA = new List<Reserva>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Reserva r = new Reserva();
                    r.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    r.PRECIO = Convert.ToInt32(dt.Rows[i]["precio_tour"]);
                    r.FECHA_INICIO = fecha_ini;
                    r.FECHA_TERMINO = fecha_ter;
                    r.TIPO = "TURISMO";
                    BusquedaTuA.Add(r);
                }
                onn.Close();
                return BusquedaTuA;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Error: " + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ClLoggerErrores.Mensaje(ex.ToString());
                return null;
            }
        }

        public List<Reserva> BusquedaTrD(int depto, int mes, int dia, DateTime fecha_ini, DateTime fecha_ter)
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();
                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_RESERVA.BUSCAR_TRANSPORTE_DIA", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_DEPTO", OracleType.Number).Value = depto;
                cmd.Parameters.Add("PRM_MES", OracleType.VarChar).Value = mes.ToString();
                cmd.Parameters.Add("PRM_DIA", OracleType.VarChar).Value = dia.ToString();
                cmd.Parameters.Add("PRM_LISTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<Reserva> BusquedaTuD = new List<Reserva>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Reserva r = new Reserva();
                    r.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    r.PRECIO = Convert.ToInt32(dt.Rows[i]["precio_transporte"]);
                    r.FECHA_INICIO = fecha_ini;
                    r.FECHA_TERMINO = fecha_ter;
                    r.TIPO = "TRANSPORTE";
                    BusquedaTuD.Add(r);
                }
                onn.Close();
                return BusquedaTuD;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Error: " + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ClLoggerErrores.Mensaje(ex.ToString());
                return null;
            }
        }
        public List<Reserva> BusquedaTrM(int depto, int mes, DateTime fecha_ini, DateTime fecha_ter)
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();
                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_RESERVA.BUSCAR_TRANSPORTE_MES", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_DEPTO", OracleType.Number).Value = depto;
                cmd.Parameters.Add("PRM_MES", OracleType.VarChar).Value = mes.ToString();
                cmd.Parameters.Add("PRM_LISTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<Reserva> BusquedaTuM = new List<Reserva>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Reserva r = new Reserva();
                    r.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    r.PRECIO = Convert.ToInt32(dt.Rows[i]["precio_transporte"]);
                    r.FECHA_INICIO = fecha_ini;
                    r.FECHA_TERMINO = fecha_ter;
                    r.TIPO = "TRANSPORTE";
                    BusquedaTuM.Add(r);
                }
                onn.Close();
                return BusquedaTuM;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Error: " + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ClLoggerErrores.Mensaje(ex.ToString());
                return null;
            }
        }
        public List<Reserva> BusquedaTrA(int depto, int anio, DateTime fecha_ini, DateTime fecha_ter)
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();
                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_RESERVA.BUSCAR_TRANSPORTE_ANIO", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_DEPTO", OracleType.Number).Value = depto;
                cmd.Parameters.Add("PRM_ANIO", OracleType.VarChar).Value = anio.ToString();
                cmd.Parameters.Add("PRM_LISTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<Reserva> BusquedaTuA = new List<Reserva>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Reserva r = new Reserva();
                    r.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    r.PRECIO = Convert.ToInt32(dt.Rows[i]["precio_transporte"]);
                    r.FECHA_INICIO = fecha_ini;
                    r.FECHA_TERMINO = fecha_ter;
                    r.TIPO = "TRANSPORTE";
                    BusquedaTuA.Add(r);
                }
                onn.Close();
                return BusquedaTuA;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Error: " + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ClLoggerErrores.Mensaje(ex.ToString());
                return null;
            }
        }
        public List<Reserva> BusquedaSED(int depto, int mes, int dia, DateTime fecha_ini, DateTime fecha_ter)
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();
                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_RESERVA.BUSCAR_SERVICIOEX_DIA", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_DEPTO", OracleType.Number).Value = depto;
                cmd.Parameters.Add("PRM_MES", OracleType.VarChar).Value = mes.ToString();
                cmd.Parameters.Add("PRM_DIA", OracleType.VarChar).Value = dia.ToString();
                cmd.Parameters.Add("PRM_LISTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<Reserva> BusquedaTuD = new List<Reserva>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Reserva r = new Reserva();
                    r.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    r.PRECIO = Convert.ToInt32(dt.Rows[i]["precio_servicio_extra"]);
                    r.FECHA_INICIO = fecha_ini;
                    r.FECHA_TERMINO = fecha_ter;
                    r.TIPO = "SERVICIO EXTRA";
                    BusquedaTuD.Add(r);
                }
                onn.Close();
                return BusquedaTuD;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Error: " + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ClLoggerErrores.Mensaje(ex.ToString());
                return null;
            }
        }
        public List<Reserva> BusquedaSEM(int depto, int mes, DateTime fecha_ini, DateTime fecha_ter)
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();
                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_RESERVA.BUSCAR_SERVICIOEX_MES", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_DEPTO", OracleType.Number).Value = depto;
                cmd.Parameters.Add("PRM_MES", OracleType.VarChar).Value = mes.ToString();
                cmd.Parameters.Add("PRM_LISTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<Reserva> BusquedaTuM = new List<Reserva>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Reserva r = new Reserva();
                    r.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    r.PRECIO = Convert.ToInt32(dt.Rows[i]["precio_servicio_extra"]);
                    r.FECHA_INICIO = fecha_ini;
                    r.FECHA_TERMINO = fecha_ter;
                    r.TIPO = "SERVICIO EXTRA";
                    BusquedaTuM.Add(r);
                }
                onn.Close();
                return BusquedaTuM;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Error: " + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ClLoggerErrores.Mensaje(ex.ToString());
                return null;
            }
        }
        public List<Reserva> BusquedaSEA(int depto, int anio, DateTime fecha_ini, DateTime fecha_ter)
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();
                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_RESERVA.BUSCAR_SERVICIOEX_ANIO", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_DEPTO", OracleType.Number).Value = depto;
                cmd.Parameters.Add("PRM_ANIO", OracleType.VarChar).Value = anio.ToString();
                cmd.Parameters.Add("PRM_LISTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<Reserva> BusquedaTuA = new List<Reserva>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Reserva r = new Reserva();
                    r.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    r.PRECIO = Convert.ToInt32(dt.Rows[i]["precio_servicio_extra"]);
                    r.FECHA_INICIO = fecha_ini;
                    r.FECHA_TERMINO = fecha_ter;
                    r.TIPO = "SERVICIO EXTRA";
                    BusquedaTuA.Add(r);
                }
                onn.Close();
                return BusquedaTuA;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Error: " + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
                ClLoggerErrores.Mensaje(ex.ToString());
             
                return null;
            }
        }
        public List<Reserva> BusquedaTD(int depto, int mes, int dia, DateTime fecha_ini, DateTime fecha_ter)
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();
                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_RESERVA.BUSCAR_TODO_DIA", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_DEPTO", OracleType.Number).Value = depto;
                cmd.Parameters.Add("PRM_MES", OracleType.VarChar).Value = mes.ToString();
                cmd.Parameters.Add("PRM_DIA", OracleType.VarChar).Value = dia.ToString();
                cmd.Parameters.Add("PRM_LISTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<Reserva> BusquedaTuD = new List<Reserva>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Reserva r = new Reserva();
                    r.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    r.FECHA_INICIO = fecha_ini;
                    r.FECHA_TERMINO = fecha_ter;
                    if (dt.Rows[i]["precio_tour"] != DBNull.Value)
                    {
                        r.PRECIO = Convert.ToInt32(dt.Rows[i]["precio_tour"]);
                        r.TIPO = "TURISMO";
                    }
                    else
                    {
                        if (dt.Rows[i]["precio_transporte"] != DBNull.Value)
                        {
                            r.PRECIO = Convert.ToInt32(dt.Rows[i]["precio_transporte"]);
                            r.TIPO = "TRANSPORTE";
                        }
                        else
                        {
                            if (dt.Rows[i]["precio_servicio_extra"] != DBNull.Value)
                            {
                                r.PRECIO = Convert.ToInt32(dt.Rows[i]["precio_servicio_extra"]);
                                r.TIPO = "SERVICIO EXTRA";
                            }
                            else
                            {
                                r.PRECIO = 0;
                            }
                        }

                    }
                    BusquedaTuD.Add(r); 
                }
                onn.Close();
                return BusquedaTuD;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Error: " + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ClLoggerErrores.Mensaje(ex.ToString());
                return null;
            }
        }
        public List<Reserva> BusquedaTM(int depto, int mes, DateTime fecha_ini, DateTime fecha_ter)
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();
                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_RESERVA.BUSCAR_TODO_MES", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_DEPTO", OracleType.Number).Value = depto;
                cmd.Parameters.Add("PRM_MES", OracleType.VarChar).Value = mes.ToString();
                cmd.Parameters.Add("PRM_LISTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<Reserva> BusquedaTuM = new List<Reserva>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Reserva r = new Reserva();
                    r.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    r.FECHA_INICIO = fecha_ini;
                    r.FECHA_TERMINO = fecha_ter;
                    if (dt.Rows[i]["precio_tour"] != DBNull.Value)
                    {
                        r.PRECIO = Convert.ToInt32(dt.Rows[i]["precio_tour"]);
                        r.TIPO = "TURISMO";
                    }
                    else
                    {
                        if (dt.Rows[i]["precio_transporte"] != DBNull.Value)
                        {
                            r.PRECIO = Convert.ToInt32(dt.Rows[i]["precio_transporte"]);
                            r.TIPO = "TRANSPORTE";
                        }
                        else
                        {
                            if (dt.Rows[i]["precio_servicio_extra"] != DBNull.Value)
                            {
                                r.PRECIO = Convert.ToInt32(dt.Rows[i]["precio_servicio_extra"]);
                                r.TIPO = "SERVICIO EXTRA";
                            }
                            else
                            {
                                r.PRECIO = 0;
                            }
                        }

                    }
                    BusquedaTuM.Add(r);
                }
                onn.Close();
                return BusquedaTuM;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Error: " + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ClLoggerErrores.Mensaje(ex.ToString());
                return null;
            }
        }
        public List<Reserva> BusquedaTA(int depto, int anio, DateTime fecha_ini, DateTime fecha_ter)
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();
                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_RESERVA.BUSCAR_TODO_ANIO", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_DEPTO", OracleType.Number).Value = depto;
                cmd.Parameters.Add("PRM_ANIO", OracleType.VarChar).Value = anio.ToString();
                cmd.Parameters.Add("PRM_LISTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<Reserva> BusquedaTuA = new List<Reserva>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Reserva r = new Reserva();
                    r.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    r.FECHA_INICIO = fecha_ini;
                    r.FECHA_TERMINO = fecha_ter;
                    if (dt.Rows[i]["precio_tour"] != DBNull.Value)
                    {
                        r.PRECIO = Convert.ToInt32(dt.Rows[i]["precio_tour"]);
                        r.TIPO = "TURISMO";
                    }
                    else
                    {
                        if (dt.Rows[i]["precio_transporte"] != DBNull.Value)
                        {
                            r.PRECIO = Convert.ToInt32(dt.Rows[i]["precio_transporte"]);
                            r.TIPO = "TRANSPORTE";
                        }
                        else
                        {
                            if (dt.Rows[i]["precio_servicio_extra"] != DBNull.Value)
                            {
                                r.PRECIO = Convert.ToInt32(dt.Rows[i]["precio_servicio_extra"]);
                                r.TIPO = "SERVICIO EXTRA";
                            }
                            else
                            {
                                r.PRECIO = 0;
                            }
                        }
                        
                    }
                    
                    BusquedaTuA.Add(r);
                }
                onn.Close();
                return BusquedaTuA;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Error: " + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ClLoggerErrores.Mensaje(ex.ToString());
                return null;
            }
        }












        public List<Reserva> ListaTodA(int depto, int anio, DateTime finic, DateTime fterm)
        {
            List<Reserva> re = BusquedaTA(depto, anio, finic, fterm);
            int res = 0;
            List<Reserva> reserv = new List<Reserva>();
            foreach (var ite in re)
            {
                if (ite.ID != res)
                {
                    res = ite.ID;
                    int idre = BusquedaReservaPrecioAcomp(res);
                    Reserva lala = new Reserva();
                    lala.ID = res;
                    lala.PRECIO = idre;
                    lala.FECHA_INICIO = ite.FECHA_INICIO;
                    lala.FECHA_TERMINO = ite.FECHA_TERMINO;
                    lala.TIPO = "RESERVA";
                    reserv.Add(lala);
                    reserv.Add(ite);
                }
                else
                {
                    reserv.Add(ite);
                }
            }
            return reserv;
        }
        public List<Reserva> ListaTodM(int depto, int mes, DateTime finic, DateTime fterm)
        {
            List<Reserva> re = BusquedaTM(depto, mes, finic, fterm);
            int res = 0;
            List<Reserva> reserv = new List<Reserva>();
            foreach (var ite in re)
            {
                if (ite.ID != res)
                {
                    res = ite.ID;
                    int idre = BusquedaReservaPrecioAcomp(res);
                    Reserva lala = new Reserva();
                    lala.ID = res;
                    lala.PRECIO = idre;
                    lala.FECHA_INICIO = ite.FECHA_INICIO;
                    lala.FECHA_TERMINO = ite.FECHA_TERMINO;
                    lala.TIPO = "RESERVA";
                    reserv.Add(lala);
                    reserv.Add(ite);
                }
                else
                {
                    reserv.Add(ite);
                }
            }
            return reserv;
        }
        public List<Reserva> ListaTodD(int depto, int mes, int dia, DateTime finic, DateTime fterm)
        {
            List<Reserva> re = BusquedaTD(depto, mes, dia, finic, fterm);
            int res = 0;
            List<Reserva> reserv = new List<Reserva>();
            foreach (var ite in re)
            {
                if (ite.ID != res)
                {
                    res = ite.ID;
                    int idre = BusquedaReservaPrecioAcomp(res);
                    Reserva lala = new Reserva();
                    lala.ID = res;
                    lala.PRECIO = idre;
                    lala.FECHA_INICIO = ite.FECHA_INICIO;
                    lala.FECHA_TERMINO = ite.FECHA_TERMINO;
                    lala.TIPO = "RESERVA";
                    reserv.Add(lala);
                    reserv.Add(ite);
                }
                else
                {
                    reserv.Add(ite);
                }
            }
            return reserv;
        }
    }
}
