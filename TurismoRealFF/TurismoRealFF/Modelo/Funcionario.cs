using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;
using System.Data;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace TurismoRealFF.Modelo
{
    public class Funcionario
    {
        
        public int ID { get; set; }
        public string DIGITO { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDO { get; set; }
        public int TELEFONO { get; set; }
        public int USERID { get; set; }
        public string EMAIL { get; set; }
        public string PASS { get; set; }
        public DateTime CREATED_AT { get; set; }
        public DateTime UPDATED_AT { get; set; }

        public Funcionario()
        {

        }
        public Funcionario(int id, string digito, string nombre, string apellido, int telefono, int userId, string email, string pass, DateTime created_at, DateTime updated_at)
        {
            ID = id;
            DIGITO = digito;
            NOMBRE = nombre;
            APELLIDO = apellido;
            TELEFONO = telefono;
            USERID = userId;
            EMAIL = email;
            PASS = pass;
            CREATED_AT = created_at;
            UPDATED_AT = updated_at;
        }

        //CREAR FUNCIONARIO
        /// <summary>
        /// Método para utilizar el procedimiento Insertar_Funcionario, el cual crea un funcionario en la base de datos Oracle
        /// </summary>
        /// <param name="idf"></param>
        /// <param name="digitof"></param>
        /// <param name="nombref"></param>
        /// <param name="apellidof"></param>
        /// <param name="telefonof"></param>
        /// <param name="emailf"></param>
        /// <param name="passf"></param>
        /// <returns></returns>
        public int insertarF(int idf, string digitof, string nombref, string apellidof, int telefonof, string emailf, string passf)
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();
                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_FUNCIONARIO.INSERTAR_FUNCIONARIO", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_ID", OracleType.Int32).Value = idf;
                cmd.Parameters.Add("PRM_DIGITO", OracleType.Char).Value = digitof;
                cmd.Parameters.Add("PRM_NOMBRE", OracleType.VarChar).Value = nombref;
                cmd.Parameters.Add("PRM_APELLIDO", OracleType.VarChar).Value = apellidof;
                cmd.Parameters.Add("PRM_TELEFONO", OracleType.Int32).Value = telefonof;
                cmd.Parameters.Add("PRM_EMAIL", OracleType.VarChar).Value = emailf;
                cmd.Parameters.Add("PRM_PASS", OracleType.VarChar).Value = passf;
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

        // MODIFICAR FUNCIONARIO
        /// <summary>
        /// Método para utilizar el procedimiento Modificar_Funcionario, el cual modifica la información del funcionario en la base de datos Oracle
        /// </summary>
        /// <param name="idf"></param>
        /// <param name="nombref"></param>
        /// <param name="apellidof"></param>
        /// <param name="telefonof"></param>
        /// <param name="emailf"></param>
        /// <param name="passf"></param>
        /// <returns></returns>
        public int modificarF(int idf, string nombref, string apellidof, int telefonof, string emailf, string passf, int useridf)
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();
                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_FUNCIONARIO.MODIFICAR_FUNCIONARIO", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_ID", OracleType.Int32).Value = idf;
                cmd.Parameters.Add("PRM_NOMBRE", OracleType.VarChar).Value = nombref;
                cmd.Parameters.Add("PRM_APELLIDO", OracleType.VarChar).Value = apellidof;
                cmd.Parameters.Add("PRM_TELEFONO", OracleType.Int32).Value = telefonof;
                cmd.Parameters.Add("PRM_EMAIL", OracleType.VarChar).Value = emailf;
                cmd.Parameters.Add("PRM_PASS", OracleType.VarChar).Value = passf;
                cmd.Parameters.Add("PRM_USERID", OracleType.Int32).Value = useridf;
                int resp = cmd.ExecuteNonQuery();
                onn.Close();
                cmd.Dispose();
                if (resp != 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }

            }
            catch (Exception)
            {
                return 0;
            }
        }


        // ELIMINAR FUNCIONARIO
        /// <summary>
        /// Método para utilizar el procedimiento Eliminar_Funcionario, el cual elimina un funcionario de la base de datos Oracle(Modifica al usuario como uno NO ACTIVO)
        /// </summary>
        /// <param name="usidf"></param>}
        /// <returns></returns>
        public int eliminarF(int usidf)
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();
                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_FUNCIONARIO.ELIMINAR_FUNCIONARIO", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_UID", OracleType.Int32).Value = usidf;
                int resp = cmd.ExecuteNonQuery();
                onn.Close();
                cmd.Dispose();
                if (resp != 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public List<Funcionario> listarFuncionarios()
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();

                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_FUNCIONARIO.LISTAR_FUNCIONARIO", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_LISTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                
                List<Funcionario> listarFuncionarios = new List<Funcionario>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Funcionario f = new Funcionario();
                    f.ID = Convert.ToInt32(dt.Rows[i]["RUT"]);
                    f.DIGITO = dt.Rows[i]["DV"].ToString();
                    f.NOMBRE = dt.Rows[i]["NOMBRE"].ToString();
                    f.APELLIDO = dt.Rows[i]["APELLIDO"].ToString();
                    f.TELEFONO = Convert.ToInt32(dt.Rows[i]["TELÉFONO"]);
                    f.USERID = Convert.ToInt32(dt.Rows[i]["ID USUARIO"]);
                    f.EMAIL = dt.Rows[i]["EMAIL"].ToString();
                    f.PASS = dt.Rows[i]["CONTRASEÑA"].ToString();
                    f.CREATED_AT = Convert.ToDateTime(dt.Rows[i]["FECHA CREACIÓN"]);
                    f.UPDATED_AT = Convert.ToDateTime(dt.Rows[i]["FECHA MODIFICACIÓN"]);
                    listarFuncionarios.Add(f);
                }
                onn.Close();
                return listarFuncionarios;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public List<Funcionario> buscarfuncionario(int idf, string dvf)
        {
            try
            {
                OracleConnection onn = new OracleConnection("DATA SOURCE = xe ; PASSWORD = TURISMOREAL ; USER ID = TURISMOREAL");
                onn.Open();

                OracleCommand cmd = new OracleCommand("PKG_TURISMOREAL_FUNCIONARIO.BUSCAR_FUNCIONARIO", onn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("PRM_ID", OracleType.Int32).Value = idf;
                cmd.Parameters.Add("PRM_DIGITO", OracleType.VarChar).Value = dvf;
                cmd.Parameters.Add("PRM_LISTA", OracleType.Cursor).Direction = ParameterDirection.Output;
                OracleDataAdapter da = new OracleDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                List<Funcionario> buscarFuncionario = new List<Funcionario>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Funcionario f = new Funcionario();
                    f.ID = Convert.ToInt32(dt.Rows[i]["RUT"]);
                    f.DIGITO = dt.Rows[i]["DV"].ToString();
                    f.NOMBRE = dt.Rows[i]["NOMBRE"].ToString();
                    f.APELLIDO = dt.Rows[i]["APELLIDO"].ToString();
                    f.TELEFONO = Convert.ToInt32(dt.Rows[i]["TELÉFONO"]);
                    f.USERID = Convert.ToInt32(dt.Rows[i]["ID USUARIO"]);
                    f.EMAIL = dt.Rows[i]["EMAIL"].ToString();
                    f.PASS = dt.Rows[i]["CONTRASEÑA"].ToString();
                    f.CREATED_AT = Convert.ToDateTime(dt.Rows[i]["FECHA CREACIÓN"]);
                    f.UPDATED_AT = Convert.ToDateTime(dt.Rows[i]["FECHA MODIFICACIÓN"]);
                    buscarFuncionario.Add(f);
                }
                onn.Close();
                return buscarFuncionario;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex,"ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return null;
            }
        }

    }
}
