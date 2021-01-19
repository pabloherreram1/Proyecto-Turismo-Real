using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TurismoRealFF.Modelo
{
    public class Cliente
    {
        public int ID { get; set; }
        public string DIGITO { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDO { get; set; }
        public int TELEFONO { get; set; }
        public int USERID { get; set; }
        public int CIUDADID { get; set; }
        public string CIUDAD { get; set; }
        public string EMAIL { get; set; }
        public string PASS { get; set; }
        public DateTime CREATED_AT { get; set; }
        public DateTime UPDATED_AT { get; set; }

        public Cliente() 
        {

        }

        public Cliente(int Id, string Digito, string Nombre, string Apellido, int Telefono, int Userid, int Ciudadid, string Ciudad, string Email, string Pass, DateTime Created_at, DateTime Updated_at)
        {
            ID = Id;
            DIGITO = Digito;
            NOMBRE = Nombre;
            APELLIDO = Apellido;
            TELEFONO = Telefono;
            USERID = Userid;
            CIUDADID = Ciudadid;
            CIUDAD = Ciudad;
            EMAIL = Email;
            PASS = Pass;
            CREATED_AT = Created_at;
            UPDATED_AT = Updated_at;
        }

        DataTable dt;
        OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");

        // MODIFICAR CLIENTE
        /// <summary>
        /// Método para utilizar el procedimiento Modificar_Cliente, el cual modifica la información del Cliente en la base de datos Oracle
        /// </summary>
        /// <param name="idc"></param>
        /// <param name="nombrec"></param>
        /// <param name="apellidoc"></param>
        /// <param name="telefonoc"></param>
        /// <param name="useridc"></param>
        /// <param name="ciudadidc"></param>
        /// <param name="emailc"></param>
        /// <param name="passc"></param>
        /// <returns></returns>
        public int modificarC(int idc, string nombrec, string apellidoc, int telefonoc, int useridc, int ciudadidc, string emailc, string passc)
        {
            try
            {
                onn.Open();
                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_CLIENTE.MODIFICAR_CLIENTE", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_ID", OracleType.Int32).Value = idc;
                cmd.Parameters.Add("PRM_NOMBRE", OracleType.VarChar).Value = nombrec;
                cmd.Parameters.Add("PRM_APELLIDO", OracleType.VarChar).Value = apellidoc;
                cmd.Parameters.Add("PRM_TELEFONO", OracleType.Int32).Value = telefonoc;
                cmd.Parameters.Add("PRM_USERID", OracleType.Int32).Value = useridc;
                cmd.Parameters.Add("PRM_CIUDADID", OracleType.Int32).Value = ciudadidc;
                cmd.Parameters.Add("PRM_EMAIL", OracleType.VarChar).Value = emailc;
                cmd.Parameters.Add("PRM_PASS", OracleType.VarChar).Value = passc;
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

        // ELIMINAR CLIENTE
        /// <summary>
        /// Método para utilizar el procedimiento Eliminar_Cliente, el cual elimina un cliente de la base de datos Oracle(Modifica al usuario como uno NO ACTIVO)
        /// </summary>
        /// <param name="usidc"></param>}
        /// <returns></returns>
        public int eliminarC(int usidc)
        {
            try
            {

                onn.Open();
                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_CLIENTE.ELIMINAR_CLIENTE", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_UID", OracleType.Int32).Value = usidc;
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

        /// <summary>
        /// Método para utilizar el procedimiento Listar_Cliente, el cual llena la tabla con los datos de todos los cliente ACTIVOS 
        /// </summary>
        /// <param name="dgv"></param>
        public List<Cliente> listarCliente()
        {
            try
            {

                onn.Open();
                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_CLIENTE.LISTAR_CLIENTE", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_LISTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;
                dt = new DataTable();
                da.Fill(dt);

                List<Cliente> listarCliente = new List<Cliente>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Cliente c = new Cliente();
                    c.ID = Convert.ToInt32(dt.Rows[i]["RUT"]);
                    c.DIGITO = dt.Rows[i]["DV"].ToString();
                    c.NOMBRE = dt.Rows[i]["NOMBRE"].ToString();
                    c.APELLIDO = dt.Rows[i]["APELLIDO"].ToString();
                    c.TELEFONO = Convert.ToInt32(dt.Rows[i]["TELÉFONO"]);
                    c.USERID = Convert.ToInt32(dt.Rows[i]["ID USUARIO"]);
                    c.CIUDADID = Convert.ToInt32(dt.Rows[i]["ID CIUDAD"]);
                    c.CIUDAD = dt.Rows[i]["CIUDAD"].ToString();
                    c.EMAIL = dt.Rows[i]["EMAIL"].ToString();
                    c.PASS = dt.Rows[i]["CONTRASEÑA"].ToString();
                    c.CREATED_AT = Convert.ToDateTime(dt.Rows[i]["FECHA CREACIÓN"]);
                    c.UPDATED_AT = Convert.ToDateTime(dt.Rows[i]["FECHA MODIFICACIÓN"]);
                    listarCliente.Add(c);
                }
                onn.Close();
                return listarCliente;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public List<Cliente> buscarCliente(int idc, string dvc)
        {
            try
            {

                onn.Open();
                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_CLIENTE.BUSCAR_CLIENTE", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_ID", OracleType.Int32).Value = idc;
                cmd.Parameters.Add("PRM_DIGITO", OracleType.VarChar).Value = dvc;
                cmd.Parameters.Add("PRM_LISTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;
                dt = new DataTable();
                da.Fill(dt);
                List<Cliente> buscarCliente = new List<Cliente>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Cliente c = new Cliente();
                    c.ID = Convert.ToInt32(dt.Rows[i]["RUT"]);
                    c.DIGITO = dt.Rows[i]["DV"].ToString();
                    c.NOMBRE = dt.Rows[i]["NOMBRE"].ToString();
                    c.APELLIDO = dt.Rows[i]["APELLIDO"].ToString();
                    c.TELEFONO = Convert.ToInt32(dt.Rows[i]["TELÉFONO"]);
                    c.USERID = Convert.ToInt32(dt.Rows[i]["ID USUARIO"]);
                    c.CIUDADID = Convert.ToInt32(dt.Rows[i]["ID CIUDAD"]);
                    c.CIUDAD = dt.Rows[i]["CIUDAD"].ToString();
                    c.EMAIL = dt.Rows[i]["EMAIL"].ToString();
                    c.PASS = dt.Rows[i]["CONTRASEÑA"].ToString();
                    c.CREATED_AT = Convert.ToDateTime(dt.Rows[i]["FECHA CREACIÓN"]);
                    c.UPDATED_AT = Convert.ToDateTime(dt.Rows[i]["FECHA MODIFICACIÓN"]);
                    buscarCliente.Add(c);
                }
                onn.Close();
                return buscarCliente;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public ArrayList cargarRegion()
        {
            Region r = new Region();
            ArrayList listarRegiones = new ArrayList(r.listarRegion());
            return listarRegiones;
        }
        public ArrayList cargarProvincia()
        {
            Provincia p = new Provincia();
            ArrayList listarProvincia = new ArrayList(p.listarProvincia());
            return listarProvincia;
        }

        public ArrayList cargarProvi(int idr)
        {
            Provincia p = new Provincia();
            ArrayList listarProvincia = new ArrayList(p.listarProvinciaBuscada(idr));
            return listarProvincia;
        }
        public ArrayList cargarCiudad()
        {
            Ciudad c = new Ciudad();
            ArrayList listarCiudad = new ArrayList(c.listarCiudad());
            return listarCiudad;
        }

        public ArrayList cargarCiu(int idp)
        {
            Ciudad c = new Ciudad();
            ArrayList listarCiudad = new ArrayList(c.listarCiudadBuscada(idp));
            return listarCiudad;
        }
    }
}
