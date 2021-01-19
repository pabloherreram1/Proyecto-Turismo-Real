using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using ComboBox = System.Windows.Controls.ComboBox;
using TurismoRealFF.Modelo;

namespace TurismoRealFF.Controlador
{
    public class ClProducto
    {
        Producto pro = new Producto();
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Color { get; set; }
        public string Peso { get; set; }
        public string Dimension { get; set; }
        public int Precio { get; set; }
        public int CategoriaId { get; set; }
        public string Categoria { get; set; }
        public int InventarioId { get; set; }
        public int DepartamentoId { get; set; }

        public bool Insertar()
        {
            int re = pro.InsertarP(Nombre, Color, Peso, Dimension, CategoriaId, InventarioId, Precio);
            if (re == 1)
            {
                return true;
            }
            else
            {
                return false;
            };
        }
        public Task<ArrayList> ListarAsync()
        {
            return Task.Run(() =>
            {
                ArrayList lista = new ArrayList(pro.ListarProducto());
                return lista;
            });
        }

        public ArrayList BuscarPorDepto()
        {
            ArrayList busqueda = new ArrayList(pro.BuscarProductoDepto(DepartamentoId));
            return busqueda;
        }


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

        public void BuscarInventario(System.Windows.Controls.TextBox t)
        {
            try
            {
                int v = pro.BuscarInventario(DepartamentoId);
                
                t.Text = v.ToString();
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void CCategoria(ComboBox cb)
        {
            try
            {
                Categoria c = new Categoria();
                ArrayList Categoria = new ArrayList(c.ListarCategoria());
                cb.Items.Clear();

                for (int i = 0; i < Categoria.Count; i++)
                {
                    cb.Items.Add(Categoria.ToArray()[i]);
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

