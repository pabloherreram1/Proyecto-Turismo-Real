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
    public class ClMantencion
    {
        readonly Mantencion m = new Mantencion();

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Total { get; set; }
        public int DepartamentoId { get; set; }
        public int ProductoId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaTermino { get; set; }

        public ArrayList Listar()
        {
            ArrayList lista = new ArrayList(m.BuscarMantencion(DepartamentoId, ProductoId));
            return lista;
        }

        public bool RegistrarRDP()
        {
            int re = m.InsertarMantencionRDP(Descripcion, Total, DepartamentoId, ProductoId, FechaInicio.ToString("dd/MM/yyyy HH:mm"), FechaTermino.ToString("dd/MM/yyyy HH:mm"));
            if (re == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool RegistrarRD()
        {
            int re = m.InsertarMantencionRD(Descripcion, Total, DepartamentoId, FechaInicio.ToString("dd/MM/yyyy HH:mm"), FechaTermino.ToString("dd/MM/yyyy HH:mm"));
            if (re == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Modificar()
        {
            int re = m.ModificarMantencion(Id, Descripcion, Total, FechaInicio.ToString("dd/MM/yyyy HH:mm"), FechaTermino.ToString("dd/MM/yyyy HH:mm"));
            if (re == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Eliminar()
        {
            int re = m.EliminarMantencion(Id);
            if (re == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public ArrayList Busqueda()
        {
            MantencionBusqueda mb = new MantencionBusqueda();
            ArrayList lista = new ArrayList(mb.BuscarMantencion(DepartamentoId));
            return lista;
        }
        //Por Terminar

        //public bool RegistrarR()
        //{
        //    int reci = 0;
        //    int re = m.InsertarMantencionR(Descripcion, Total, reci, FechaInicio, FechaTermino);
        //    if (re == 1)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //public ArrayList BuscarPorDepto()
        //{
        //    ArrayList busqueda = new ArrayList(pro.BuscarProductoDepto(DepartamentoId));
        //    return busqueda;
        //}


        public void CRecinto(ComboBox cb)
        {
            try
            {
                Recinto r = new Recinto();
                ArrayList Recinto = new ArrayList(r.ListarRecinto());
                cb.Items.Clear();

                for (int i = 0; i < Recinto.Count; i++)
                {
                    cb.Items.Add(Recinto.ToArray()[i]);
                }

                cb.SelectedItem = "ID";
                cb.DisplayMemberPath = "NOMBRE";


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }

        public void CDeptoB(ComboBox cb, int idrecinto)
        {
            try
            {
                Departamento d = new Departamento();
                ArrayList Depto = new ArrayList(d.ListarDeptoBuscada(idrecinto));
                cb.Items.Clear();

                for (int i = 0; i < Depto.Count; i++)
                {
                    cb.Items.Add(Depto.ToArray()[i]);
                }

                cb.SelectedItem = "ID";
                cb.DisplayMemberPath = "NOMBRE";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }

        }

        public void CProductoB(ComboBox cb, int iddepto)
        {
            try
            {
                Producto p = new Producto();
                ArrayList Produc = new ArrayList(p.BuscarProductoDepto(iddepto));
                cb.Items.Clear();

                for (int i = 0; i < Produc.Count; i++)
                {
                    cb.Items.Add(Produc.ToArray()[i]);
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
