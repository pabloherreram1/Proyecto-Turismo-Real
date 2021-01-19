using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TurismoRealFF.Modelo;
//using TurismoRealFF.Vistas.Mantenedores.Cliente;

namespace TurismoRealFF.Controlador
{
    public class ClCliente
    {
        Cliente cli = new Cliente();

        public int Id { get; set; }
        public string Digito { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Telefono { get; set; }
        public int UserId { get; set; }
        public int CiudadId { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public bool actualizar()
        {
            int resp = cli.modificarC(Id, Nombre, Apellido, Telefono, UserId, CiudadId, Email, Pass);
            if (resp == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool eliminar()
        {
            int el = cli.eliminarC(UserId);
            if (el == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public ArrayList lista()
        {
            ArrayList lista = new ArrayList(cli.listarCliente());
            return lista;
        }

        public ArrayList busqueda()
        {
            ArrayList busqueda = new ArrayList(cli.buscarCliente(Id, Digito));
            return busqueda;
        }

        public void CRegiones(ComboBox cb)
        {
            try
            {
                ArrayList Regiones = new ArrayList(cli.cargarRegion());
                cb.Items.Clear();

                for (int i = 0; i < Regiones.Count; i++)
                {
                    cb.Items.Add(Regiones.ToArray()[i]);
                }

                cb.SelectedItem = "ID";
                cb.DisplayMemberPath = "DESCRIPCION";

               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
            
        }

        public void CProvincia(ComboBox cb)
        {
            try
            {
                ArrayList Provincias = new ArrayList(cli.cargarProvincia());
                cb.Items.Clear();

                for (int i = 0; i < Provincias.Count; i++)
                {
                    cb.Items.Add(Provincias.ToArray()[i]);
                }

                cb.SelectedItem = "ID";
                cb.DisplayMemberPath = "DESCRIPCION";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }

        }

        public void CProvinciaB(ComboBox cb, int idregion)
        {
            try
            {
                ArrayList Provincias = new ArrayList(cli.cargarProvi(idregion));
                cb.Items.Clear();

                for (int i = 0; i < Provincias.Count; i++)
                {
                    cb.Items.Add(Provincias.ToArray()[i]);
                }

                cb.SelectedItem = "ID";
                cb.DisplayMemberPath = "DESCRIPCION";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }

        }


        public void CCiudad(ComboBox cb)
        {
            try
            {
                ArrayList Ciudades = new ArrayList(cli.cargarCiudad());
                cb.Items.Clear();

                for (int i = 0; i < Ciudades.Count; i++)
                {
                    cb.Items.Add(Ciudades.ToArray()[i]);
                }

                cb.SelectedItem = "ID";
                cb.DisplayMemberPath = "DESCRIPCION";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }

        }

        public void CCiudadB(ComboBox cb, int idpovincia)
        {
            try
            {
                ArrayList Ciudades = new ArrayList(cli.cargarCiu(idpovincia));
                cb.Items.Clear();

                for (int i = 0; i < Ciudades.Count; i++)
                {
                    cb.Items.Add(Ciudades.ToArray()[i]);
                }

                cb.SelectedItem = "ID";
                cb.DisplayMemberPath = "DESCRIPCION";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }

        }
    }
}
