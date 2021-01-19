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
using DataGrid = System.Windows.Controls.DataGrid;
using DataGridCell = System.Windows.Controls.DataGridCell;
using MessageBox = System.Windows.Forms.MessageBox;

namespace TurismoRealFF.Vistas.Mantenedores.Clientes
{
    /// <summary>
    /// Lógica de interacción para Modificar_cliente.xaml
    /// </summary>
    public partial class Modificar_cliente : Window
    {
        public Modificar_cliente()
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
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonMenuM_Click(object sender, RoutedEventArgs e)
        {
            MenuMantenedores mm = new MenuMantenedores();
            Hide();
            mm.ShowDialog();
            Close();
        }

        private void modificar_cliente_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                ClCliente clc = new ClCliente();
                dt_lista.ItemsSource = clc.lista();

                //Llenar combox region
                clc.CRegiones(cmb_region);
                cmb_region.SelectedIndex = 0;
                cmb_provincia.SelectedIndex = 0;
                cmb_ciudad.SelectedIndex = 0;
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
                if (txt_rut.Text == "" || txt_dv.Text == "")
                {
                    MessageBox.Show("Debe ingresar un rut y un digito verificador");
                }
                else
                {
                    ClCliente c = new ClCliente();
                    c.Id = int.Parse(txt_rut.Text);
                    c.Digito = txt_dv.Text;
                    dt_lista.ItemsSource = c.busqueda();
                }
            }
            catch (Exception)
            {
                throw;
            }
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
                    txt_rutc.Text = ((TextBlock)rc0.Content).Text;

                    DataGridCell rc1 = d.Columns[1].GetCellContent(r).Parent as DataGridCell;
                    txt_dvc.Text = ((TextBlock)rc1.Content).Text;

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
                    txt_ciudadidc.Text = ((TextBlock)rc6.Content).Text;

                    DataGridCell rc8 = d.Columns[8].GetCellContent(r).Parent as DataGridCell;
                    txt_email.Text = ((TextBlock)rc8.Content).Text;

                    DataGridCell rc9 = d.Columns[9].GetCellContent(r).Parent as DataGridCell;
                    txt_pass.Text = ((TextBlock)rc9.Content).Text;

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
                    lbl_region.Visibility = Visibility;
                    cmb_region.Visibility = Visibility;
                    lbl_provincia.Visibility = Visibility;
                    cmb_provincia.Visibility = Visibility;
                    lbl_ciudad.Visibility = Visibility;
                    cmb_ciudad.Visibility = Visibility;
                    btn_modificar.Visibility = Visibility;
                    btn_eliminar.Visibility = Visibility;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btn_eliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txt_rutc.Text == "" || txt_dvc.Text == "")
                {
                    DialogResult result = MessageBox.Show("Debe seleccionar un cliente de la lista",
                    "Mensaje Importante",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                }
                else
                {
                    ClCliente clf = new ClCliente();
                    clf.UserId = int.Parse(txt_userid.Text);
                    DialogResult resultado = MessageBox.Show("¿Está seguro que desea eliminar al cliente " + txt_nombre1.Text + "?",
                    "Mensaje Importante", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (resultado == System.Windows.Forms.DialogResult.Yes)
                    {
                        var r = clf.eliminar();

                        if (r)
                        {
                            MessageBox.Show("Cliente Eliminado correctamente", "Mensaje Importante",
                            MessageBoxButtons.OK);

                            txt_nombre.Clear();
                            txt_apellido.Clear();
                            txt_telefono.Clear();
                            txt_email.Clear();
                            txt_pass.Clear();
                            txt_rutc.Clear();
                            txt_dvc.Clear();
                            txt_userid.Clear();
                            dt_lista.ItemsSource = clf.lista();

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
                            lbl_region.Visibility = Visibility.Hidden;
                            cmb_region.Visibility = Visibility.Hidden;
                            lbl_provincia.Visibility = Visibility.Hidden;
                            cmb_provincia.Visibility = Visibility.Hidden;
                            lbl_ciudad.Visibility = Visibility.Hidden;
                            cmb_ciudad.Visibility = Visibility.Hidden;
                            btn_modificar.Visibility = Visibility.Hidden;
                            btn_eliminar.Visibility = Visibility.Hidden;
                        }
                        else
                        {
                            MessageBox.Show("No se pudo Eliminar el cliente",
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
                if (txt_rutc.Text == "" || txt_dvc.Text == "")
                {
                    DialogResult resultado = MessageBox.Show("Debe seleccionar un cliente de la lista",
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
                        Ciudad c = (Ciudad)cmb_ciudad.SelectedValue;
                        ClCliente cli = new ClCliente();
                        cli.Id = int.Parse(txt_rutc.Text);
                        cli.Nombre = txt_nombre.Text;
                        cli.Apellido = txt_apellido.Text;
                        cli.Email = txt_email.Text;
                        cli.Pass = txt_pass.Text;
                        cli.Telefono = int.Parse(txt_telefono.Text);
                        cli.UserId = int.Parse(txt_userid.Text);
                        cli.CiudadId = c.ID;
                        DialogResult resultado = MessageBox.Show("¿Está seguro que desea modificar al cliente " + txt_nombre1.Text + "?",
                        "Mensaje Importante",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Exclamation);
                        if (resultado == System.Windows.Forms.DialogResult.Yes)
                        {
                            var r = cli.actualizar();
                            if (r)
                            {
                                MessageBox.Show("Cliente Modificado correctamente", "Mensaje Importante",
                                MessageBoxButtons.OK);
                                txt_nombre.Clear();
                                txt_apellido.Clear();
                                txt_telefono.Clear();
                                txt_email.Clear();
                                txt_pass.Clear();
                                txt_rutc.Clear();
                                txt_dvc.Clear();
                                txt_userid.Clear();
                                txt_userid.Clear();
                                dt_lista.Items.Refresh();
                                dt_lista.ItemsSource = cli.lista();
                                dt_lista.Items.Refresh();

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
                                lbl_region.Visibility = Visibility.Hidden;
                                cmb_region.Visibility = Visibility.Hidden;
                                lbl_provincia.Visibility = Visibility.Hidden;
                                cmb_provincia.Visibility = Visibility.Hidden;
                                lbl_ciudad.Visibility = Visibility.Hidden;
                                cmb_ciudad.Visibility = Visibility.Hidden;
                                btn_modificar.Visibility = Visibility.Hidden;
                                btn_eliminar.Visibility = Visibility.Hidden;

                            }
                            else
                            {
                                MessageBox.Show("No se pudo Modificar el cliente", "Mensaje Importante",
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

        private void cmb_region_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Region r = (Region)cmb_region.SelectedValue;

            if (cmb_region.SelectedIndex.ToString() != null)
            {

                int p = r.ID;
                ClCliente clc = new ClCliente();
                clc.CProvinciaB(cmb_provincia, p);
                cmb_provincia.SelectedIndex = 0;
                cmb_ciudad.SelectedIndex = 0;
            }
        }

        private void cmb_provincia_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cmb_provincia.SelectedValue != null)
                {
                    Provincia p = (Provincia)cmb_provincia.SelectedValue;


                    if (cmb_provincia.SelectedIndex.ToString() != null)
                    {
                        int c = p.ID;
                        ClCliente clc = new ClCliente();
                        clc.CCiudadB(cmb_ciudad, c);
                        cmb_ciudad.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
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
