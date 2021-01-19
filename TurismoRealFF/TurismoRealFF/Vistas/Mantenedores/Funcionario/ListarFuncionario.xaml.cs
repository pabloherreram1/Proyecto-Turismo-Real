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
using Application = System.Windows.Application;
using DataGrid = System.Windows.Controls.DataGrid;
using DataGridCell = System.Windows.Controls.DataGridCell;
using MessageBox = System.Windows.Forms.MessageBox;

namespace TurismoRealFF.Vistas.Mantenedores.Funcionario
{
    /// <summary>
    /// Lógica de interacción para ListarFuncionario.xaml
    /// </summary>
    public partial class ListarFuncionario : Window
    {
        public ListarFuncionario()
        {
            InitializeComponent();
        }

        private void listar_funcionario_Loaded(object sender, RoutedEventArgs e)
        {
            ClFuncionario cl = new ClFuncionario();
            dt_lista.ItemsSource = cl.lista();
        }

        private void btn_buscar_Click(object sender, RoutedEventArgs e)
        {
            ClFuncionario f = new ClFuncionario();
            f.Id = int.Parse(txt_rut.Text);
            f.Digito = txt_dv.Text;
            dt_lista.ItemsSource = f.busqueda();
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
                    txt_rutf.Text = ((TextBlock)rc0.Content).Text;

                    DataGridCell rc1 = d.Columns[1].GetCellContent(r).Parent as DataGridCell;
                    txt_dvf.Text = ((TextBlock)rc1.Content).Text;

                    DataGridCell rc2 = d.Columns[2].GetCellContent(r).Parent as DataGridCell;
                    txt_nombre.Text = ((TextBlock)rc2.Content).Text;
                    txt_nombre1.Text = ((TextBlock)rc2.Content).Text;

                    DataGridCell rc3 = d.Columns[3].GetCellContent(r).Parent as DataGridCell;
                    txt_apellido.Text = ((TextBlock)rc3.Content).Text;

                    DataGridCell rc4 = d.Columns[4].GetCellContent(r).Parent as DataGridCell;
                    txt_telefono.Text = ((TextBlock)rc4.Content).Text;

                    DataGridCell rc5 = d.Columns[5].GetCellContent(r).Parent as DataGridCell;
                    txt_userid.Text = ((TextBlock)rc5.Content).Text;

                    DataGridCell rc6 = d.Columns[6].GetCellContent(r).Parent as DataGridCell;
                    txt_email.Text = ((TextBlock)rc6.Content).Text;

                    DataGridCell rc7 = d.Columns[7].GetCellContent(r).Parent as DataGridCell;
                    txt_pass.Text = ((TextBlock)rc7.Content).Text;

                    lbl_nombre.Visibility = Visibility;
                    txt_nombre.Visibility = Visibility;
                    lbl_apellido.Visibility = Visibility;
                    txt_apellido.Visibility = Visibility;
                    lbl_telefono.Visibility = Visibility;
                    txt_telefono.Visibility = Visibility;
                    lbl_email.Visibility = Visibility;
                    txt_email.Visibility = Visibility;
                    lbl_pass.Visibility = Visibility;
                    txt_pass.Visibility = Visibility;
                    btn_modificar.Visibility = Visibility;
                    btn_eliminar.Visibility = Visibility;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex);
            }
        }

        private void btn_modificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txt_rutf.Text == "" || txt_dvf.Text == "")
                {
                    DialogResult resultado = MessageBox.Show("Debe seleccionar un funcionario de la lista",
                    "Mensaje Importante",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                }
                else
                {
                    if (txt_nombre.Text == "" || txt_apellido.Text == "" || txt_pass.Text == "" || txt_telefono.Text == "")
                    {
                        DialogResult resultado = MessageBox.Show("Debe completar todos los campos como el Nombre, Apellido, Teléfono y Contraseña",
                        "Mensaje Importante",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    }
                    else
                    {
                        ClFuncionario fun = new ClFuncionario();
                        fun.Id = int.Parse(txt_rutf.Text);
                        fun.Nombre = txt_nombre.Text;
                        fun.Apellido = txt_apellido.Text;
                        fun.Email = txt_email.Text;
                        fun.Pass = txt_pass.Text;
                        fun.Telefono = int.Parse(txt_telefono.Text);
                        fun.UserId = int.Parse(txt_userid.Text);
                        DialogResult resultado = MessageBox.Show("¿Está seguro que desea modificar al funcionario " + txt_nombre1.Text + "?",
                        "Mensaje Importante",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Exclamation);
                        if (resultado == System.Windows.Forms.DialogResult.Yes)
                        {
                            var r = fun.actualizar();
                            if (r)
                            {
                                MessageBox.Show("Funcionario Modificado correctamente", "Mensaje Importante",
                                MessageBoxButtons.OK);
                                txt_nombre.Clear();
                                txt_nombre1.Clear();
                                txt_apellido.Clear();
                                txt_telefono.Clear();
                                txt_email.Clear();
                                txt_pass.Clear();
                                txt_rutf.Clear();
                                txt_dvf.Clear();
                                txt_userid.Clear();
                                lbl_nombre.Visibility = Visibility.Hidden;
                                txt_nombre.Visibility = Visibility.Hidden;
                                lbl_apellido.Visibility = Visibility.Hidden;
                                txt_apellido.Visibility = Visibility.Hidden;
                                lbl_telefono.Visibility = Visibility.Hidden;
                                txt_telefono.Visibility = Visibility.Hidden;
                                lbl_email.Visibility = Visibility.Hidden;
                                txt_email.Visibility = Visibility.Hidden;
                                lbl_pass.Visibility = Visibility.Hidden;
                                txt_pass.Visibility = Visibility.Hidden;
                                btn_modificar.Visibility = Visibility.Hidden;
                                btn_eliminar.Visibility = Visibility.Hidden;
                                dt_lista.Items.Refresh();
                                dt_lista.ItemsSource = fun.lista();
                                dt_lista.Items.Refresh();
                            }
                            else
                            {
                                MessageBox.Show("No se pudo Modificar el funcionario", "Mensaje Importante",
                                MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_eliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txt_rutf.Text == "" || txt_dvf.Text == "")
                {
                    DialogResult result = MessageBox.Show("Debe seleccionar un funcionario de la lista",
                    "Mensaje Importante",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                }
                else
                {
                    ClFuncionario clf = new ClFuncionario();
                    clf.UserId = int.Parse(txt_userid.Text);
                    DialogResult resultado = MessageBox.Show("¿Está seguro que desea eliminar al funcionario " + txt_nombre1.Text + "?",
                    "Mensaje Importante", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (resultado == System.Windows.Forms.DialogResult.Yes)
                    {
                        var r = clf.eliminar();

                        if (r)
                        {
                            MessageBox.Show("Funcionario Eliminado correctamente", "Mensaje Importante",
                            MessageBoxButtons.OK);

                            txt_nombre.Clear();
                            txt_nombre1.Clear();
                            txt_apellido.Clear();
                            txt_telefono.Clear();
                            txt_email.Clear();
                            txt_pass.Clear();
                            txt_rutf.Clear();
                            txt_dvf.Clear();
                            txt_userid.Clear();
                            lbl_nombre.Visibility = Visibility.Hidden;
                            txt_nombre.Visibility = Visibility.Hidden;
                            lbl_apellido.Visibility = Visibility.Hidden;
                            txt_apellido.Visibility = Visibility.Hidden;
                            lbl_telefono.Visibility = Visibility.Hidden;
                            txt_telefono.Visibility = Visibility.Hidden;
                            lbl_email.Visibility = Visibility.Hidden;
                            txt_email.Visibility = Visibility.Hidden;
                            lbl_pass.Visibility = Visibility.Hidden;
                            txt_pass.Visibility = Visibility.Hidden;
                            btn_modificar.Visibility = Visibility.Hidden;
                            btn_eliminar.Visibility = Visibility.Hidden;
                            dt_lista.ItemsSource = clf.lista();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo Eliminar el funcionario",
                            "Mensaje Importante", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
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

        private void ButtonAtras_Click(object sender, RoutedEventArgs e)
        {
            MenuFuncionario mf = new MenuFuncionario();
            Hide();
            mf.ShowDialog();
            Close();
        }
    }
}
