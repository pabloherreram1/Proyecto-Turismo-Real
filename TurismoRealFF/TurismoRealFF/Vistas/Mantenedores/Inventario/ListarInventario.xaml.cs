using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TurismoRealFF.Controlador;
using TurismoRealFF.Modelo;
using MessageBox = System.Windows.Forms.MessageBox;

namespace TurismoRealFF.Vistas.Mantenedores.Inventario
{
    /// <summary>
    /// Lógica de interacción para ListarInventario.xaml
    /// </summary>
    public partial class ListarInventario : Window
    {
        public ListarInventario()
        {
            InitializeComponent();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            //Application.Current.Shutdown();
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
        }

        private void listarProducto_Loaded(object sender, RoutedEventArgs e)
        {
            //ClFuncionario cl = new ClFuncionario();
            //dt_lista.ItemsSource = cl.lista();
            ClProducto clp = new ClProducto();
            //dt_lista.ItemsSource = await clp.ListarAsync();

            clp.CRecinto(cmb_recinto);
            cmb_recinto.SelectedIndex = 0;

            clp.CCategoria(cmb_categoria);
            cmb_categoria.SelectedIndex = 0;
        }

        private void cmb_recinto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Modelo.Recinto r = (Modelo.Recinto)cmb_recinto.SelectedValue;
                int s = -1;
                if (cmb_recinto.SelectedIndex.ToString() != s.ToString())
                {

                    int p = r.ID;
                    ClProducto clp = new ClProducto();
                    clp.CDeptoB(cmb_depto, p);
                    cmb_depto.SelectedIndex = 0;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btn_buscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                Modelo.Departamento d = (Modelo.Departamento)cmb_depto.SelectedValue;
                ClProducto p = new ClProducto
                {
                    DepartamentoId = d.ID
                };
                var s = p.BuscarPorDepto();
                if (s != null)
                {
                    dt_lista.ItemsSource = p.BuscarPorDepto();
                    p.BuscarInventario(txt_inventarioId);
                }
                else
                {
                    dt_lista.ItemsSource = null;
                }
            }
            catch (Exception)
            {
                dt_lista.ItemsSource = null;
                throw;
            }
        }

        private void btn_ingresar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txt_inventarioId.Text == "")
                {
                    DialogResult resultado = MessageBox.Show("Debe Buscar un departamento en específico",
                        "Mensaje Importante",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else
                {
                    if (txt_precio.Text == "" || txt_nombre.Text == "" || txt_peso.Text == "" || txt_dimension.Text == "" || txt_color.Text == "")
                    {
                        DialogResult resultado = MessageBox.Show("Debe completar todos los campos",
                        "Mensaje Importante",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    }
                    else
                    {
                        Categoria c = (Categoria)cmb_categoria.SelectedValue;
                        ClProducto prod = new ClProducto
                        {
                            Nombre = txt_nombre.Text,
                            Color = txt_color.Text,
                            Peso = txt_peso.Text,
                            Dimension = txt_dimension.Text,
                            InventarioId = int.Parse(txt_inventarioId.Text),
                            CategoriaId = c.ID,
                            Precio = int.Parse(txt_precio.Text)
                        };
                        DialogResult resultado = MessageBox.Show("¿Está seguro que desea ingresar el producto " + txt_nombre.Text + "?",
                        "Mensaje Importante",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Exclamation);
                        if (resultado == System.Windows.Forms.DialogResult.Yes)
                        {
                            var r = prod.Insertar();
                            if (r)
                            {
                                MessageBox.Show("Producto agregado correctamente",
                                "Mensaje Importante",
                                MessageBoxButtons.OK);

                                Modelo.Departamento d = (Modelo.Departamento)cmb_depto.SelectedValue;
                                prod.DepartamentoId = d.ID;
                                dt_lista.ItemsSource = prod.BuscarPorDepto();

                                txt_nombre.Clear();
                                txt_color.Clear();
                                txt_peso.Clear();
                                txt_dimension.Clear();
                                txt_inventarioId.Clear();
                                txt_precio.Clear();


                            }
                            else
                            {
                                MessageBox.Show("No se pudo Ingresar el Producto",
                                "Mensaje Importante",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Stop);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dt_lista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ButtonAtras_Click(object sender, RoutedEventArgs e)
        {
            MenuMantenedores men = new MenuMantenedores();
            Hide();
            men.ShowDialog();
            Close();
        }
    }
}
