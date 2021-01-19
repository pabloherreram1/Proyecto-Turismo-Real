using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using TurismoRealFF.Modelo;
using ComboBox = System.Windows.Controls.ComboBox;

namespace TurismoRealFF.Controlador
{
    public class ClRecinto
    {
        Reci r = new Reci();

        public int Id { get; set; }
        public string Nombre{ get; set; }
        public string Direccion { get; set; }
        public int FuncionarioId { get; set; }
        public int CiudadId { get; set; }
        public int EstadoRecintoId { get; set; }
        public string ImagePath { get; set; }

        public bool Registrar()
        {
            int re = r.InsertarR(Nombre, Direccion, CiudadId);
            if (re == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Registrar2()
        {
            int re = r.InsertarR2(Nombre, Direccion, CiudadId, ImagePath);
            if (re == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool EliminarR()
        {
            int re = r.EliminarR(Id);
            if (re == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ModificarR()
        {
            int re = r.ModificarR(Id, Nombre, Direccion, FuncionarioId,CiudadId, EstadoRecintoId,ImagePath);
            if (re == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public ArrayList Lista()
        {
            ArrayList lista = new ArrayList(r.ListarR());
            return lista;
        }

        public ArrayList Busqueda()
        {
            ArrayList busqueda = new ArrayList(r.BuscarR(Id));
            return busqueda;
        }

        Funci f = new Funci();
        public ArrayList BusquedaFuncionario()
        {
            ArrayList busqueda = new ArrayList(f.ListarF());
            return busqueda;
        }


        public void CFuncionario(ComboBox cb)
        {
            try
            {
                ArrayList busqueda = new ArrayList(f.ListarF());
                cb.Items.Clear();

                for (int i = 0; i < busqueda.Count; i++)
                {
                    cb.Items.Add(busqueda.ToArray()[i]);
                }

                cb.SelectedItem = "ID";
                cb.DisplayMemberPath = "NOMBRE";


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }

        }
    }
}
