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
using DataGrid = System.Windows.Controls.DataGrid;
using DataGridCell = System.Windows.Controls.DataGridCell;
using MessageBox = System.Windows.Forms.MessageBox;

namespace TurismoRealFF.Vistas.Mantenedores.Servicios.ServicioExtra
{
    /// <summary>
    /// Lógica de interacción para ListarServicioExtra.xaml
    /// </summary>
    public partial class ListarServicioExtra : Window
    {
        public ListarServicioExtra()
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

        private void ButtonAgregarSE_Click(object sender, RoutedEventArgs e)
        {
            AgregarServicioExtra ase = new AgregarServicioExtra();
            Hide();
            ase.ShowDialog();
            Close();
        }

        private void ButtonListarSE_Click(object sender, RoutedEventArgs e)
        {
            ListarServicioExtra lse = new ListarServicioExtra();
            Hide();
            lse.ShowDialog();
            Close();
        }

        private void listarServicioExtra_Loaded(object sender, RoutedEventArgs e)
        {
            ClServicioExtra cse = new ClServicioExtra();
            dt_lista.ItemsSource = cse.lista();
        }

        private void btn_buscar_Click(object sender, RoutedEventArgs e)
        {
            ClServicioExtra s = new ClServicioExtra();
            s.Nombre = txt_nservicioex.Text;
            dt_lista.ItemsSource = s.busqueda();
        }

        private void dt_lista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (dt_lista.SelectedIndex != -1)
                {
                    DataGrid d = sender as DataGrid;
                    DataGridRow r = (DataGridRow)d.ItemContainerGenerator.ContainerFromIndex(d.SelectedIndex);
                    DataGridCell rc0 = d.Columns[0].GetCellContent(r).Parent as DataGridCell;
                    txt_idservicio.Text = ((TextBlock)rc0.Content).Text;

                    DataGridCell rc1 = d.Columns[1].GetCellContent(r).Parent as DataGridCell;
                    txt_nombre.Text = ((TextBlock)rc1.Content).Text;
                    txt_nombre1.Text = ((TextBlock)rc1.Content).Text;

                    DataGridCell rc2 = d.Columns[2].GetCellContent(r).Parent as DataGridCell;
                    txt_descripcion.Text = ((TextBlock)rc2.Content).Text;

                    DataGridCell rc3 = d.Columns[3].GetCellContent(r).Parent as DataGridCell;
                    txt_precio.Text = ((TextBlock)rc3.Content).Text;

                    lbl_nombre.Visibility = Visibility;
                    txt_nombre.Visibility = Visibility;
                    lbl_precio.Visibility = Visibility;
                    txt_precio.Visibility = Visibility;
                    lbl_descripcion.Visibility = Visibility;
                    txt_descripcion.Visibility = Visibility;
                    btn_modificar.Visibility = Visibility;
                    btn_eliminar.Visibility = Visibility;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex);
            }
        }

        private void btn_eliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txt_idservicio.Text == "")
                {
                    DialogResult result = MessageBox.Show("Debe seleccionar un servicio extra de la lista",
                    "Mensaje Importante",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                }
                else
                {
                    ClServicioExtra cse = new ClServicioExtra();
                    cse.Id = int.Parse(txt_idservicio.Text);
                    DialogResult resultado = MessageBox.Show("¿Está seguro que desea eliminar el servicio extra " + txt_nombre1.Text + "?",
                    "Mensaje Importante", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (resultado == System.Windows.Forms.DialogResult.Yes)
                    {
                        var r = cse.eliminar();

                        if (r)
                        {
                            MessageBox.Show("Servicio Extra Eliminado correctamente", "Mensaje Importante",
                            MessageBoxButtons.OK);
                            txt_nombre.Clear();
                            txt_nombre1.Clear();
                            txt_descripcion.Clear();
                            txt_precio.Clear();
                            txt_idservicio.Clear();
                            txt_nservicioex.Clear();
                            lbl_nombre.Visibility = Visibility.Hidden;
                            txt_nombre.Visibility = Visibility.Hidden;
                            lbl_descripcion.Visibility = Visibility.Hidden;
                            txt_descripcion.Visibility = Visibility.Hidden;
                            lbl_precio.Visibility = Visibility.Hidden;
                            txt_precio.Visibility = Visibility.Hidden;
                            btn_modificar.Visibility = Visibility.Hidden;
                            btn_eliminar.Visibility = Visibility.Hidden;
                            dt_lista.Items.Refresh();
                            dt_lista.ItemsSource = cse.lista();
                            dt_lista.Items.Refresh();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo Eliminar el servicio extra",
                            "Mensaje Importante", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_modificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txt_idservicio.Text == "")
                {
                    DialogResult resultado = MessageBox.Show("Debe seleccionar un funcionario de la lista",
                    "Mensaje Importante",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                }
                else
                {
                    if (txt_nombre.Text == "" || txt_descripcion.Text == "" || txt_precio.Text == "")
                    {
                        DialogResult resultado = MessageBox.Show("Debe completar todos los campos como el Nombre, Descripcion, y Precio",
                        "Mensaje Importante",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    }
                    else
                    {
                        ClServicioExtra cse = new ClServicioExtra();
                        cse.Id = int.Parse(txt_idservicio.Text);
                        cse.Nombre = txt_nombre.Text;
                        cse.Descripcion = txt_descripcion.Text;
                        cse.Precio = int.Parse(txt_precio.Text);
                        DialogResult resultado = MessageBox.Show("¿Está seguro que desea modificar el servicio extra " + txt_nombre1.Text + "?",
                        "Mensaje Importante",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Exclamation);
                        if (resultado == System.Windows.Forms.DialogResult.Yes)
                        {
                            var r = cse.actualizar();
                            if (r)
                            {
                                MessageBox.Show("Servicio Extra Modificado correctamente", "Mensaje Importante",
                                MessageBoxButtons.OK);
                                txt_nombre.Clear();
                                txt_nombre1.Clear();
                                txt_descripcion.Clear();
                                txt_precio.Clear();
                                txt_idservicio.Clear();
                                txt_nservicioex.Clear();
                                lbl_nombre.Visibility = Visibility.Hidden;
                                txt_nombre.Visibility = Visibility.Hidden;
                                lbl_descripcion.Visibility = Visibility.Hidden;
                                txt_descripcion.Visibility = Visibility.Hidden;
                                lbl_precio.Visibility = Visibility.Hidden;
                                txt_precio.Visibility = Visibility.Hidden;
                                btn_modificar.Visibility = Visibility.Hidden;
                                btn_eliminar.Visibility = Visibility.Hidden;
                                dt_lista.Items.Refresh();
                                dt_lista.ItemsSource = cse.lista();
                                dt_lista.Items.Refresh();
                            }
                            else
                            {
                                MessageBox.Show("No se pudo Modificar el servicio extra", "Mensaje Importante",
                                MessageBoxButtons.OK, MessageBoxIcon.Stop);
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

        private void ButtonAtras_Click(object sender, RoutedEventArgs e)
        {
            MenuServicioExtra mse = new MenuServicioExtra();
            Hide();
            mse.ShowDialog();
            Close();
        }
    }
}
