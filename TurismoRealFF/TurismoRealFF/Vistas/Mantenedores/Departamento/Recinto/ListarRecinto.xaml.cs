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
using DataGrid = System.Windows.Controls.DataGrid;
using DataGridCell = System.Windows.Controls.DataGridCell;
using Application = System.Windows.Application;

namespace TurismoRealFF.Vistas.Mantenedores.Departamento.Recinto
{
    /// <summary>
    /// Lógica de interacción para ListarRecinto.xaml
    /// </summary>
    public partial class ListarRecinto : Window
    {
        public ListarRecinto()
        {
            InitializeComponent();
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
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonAgregarR_Click(object sender, RoutedEventArgs e)
        {
            AgregarRecinto ar = new AgregarRecinto();
            Hide();
            ar.ShowDialog();
            Close();
        }

        private void ButtonListarR_Click(object sender, RoutedEventArgs e)
        {
            ListarRecinto lr = new ListarRecinto();
            Hide();
            lr.ShowDialog();
            Close();
        }

        private void ButtonAtras_Click(object sender, RoutedEventArgs e)
        {
            MenuRecinto mr = new MenuRecinto();
            Hide();
            mr.ShowDialog();
            Close();
        }

        private void ListarRecinto1_Loaded(object sender, RoutedEventArgs e)
        {
            ClRecinto clr = new ClRecinto();
            clr.CFuncionario(cmb_funcionario);
            dt_lista.ItemsSource = clr.Lista();

            cmb_estado.Items.Add("DISPONIBLE");
            cmb_estado.Items.Add("MANTENCION");

            ClProducto clp = new ClProducto();
            clp.CRecinto(cmb_recinto);
            cmb_recinto.SelectedIndex = 0;

            //Llenar combox region
            ClCliente clc = new ClCliente();
            clc.CRegiones(cmb_region);
            cmb_region.SelectedIndex = 0;
            cmb_provincia.SelectedIndex = 0;
            cmb_ciudad.SelectedIndex = 0;

        }

        private void btn_buscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                ClRecinto clr = new ClRecinto();
                Modelo.Recinto r = new Modelo.Recinto();
                r = (Modelo.Recinto)cmb_recinto.SelectedValue;
                clr.Id = r.ID;
                dt_lista.ItemsSource = clr.Busqueda();
                
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
                if (txt_id.Text == "")
                {
                    DialogResult result = MessageBox.Show("Debe seleccionar un recinto de la lista",
                    "Mensaje Importante",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                }
                else
                {
                    ClRecinto clr = new ClRecinto();
                    clr.Id = int.Parse(txt_id.Text);
                    DialogResult resultado = MessageBox.Show("¿Está seguro que desea eliminar al recinto " + txt_nombre1.Text + "?",
                    "Mensaje Importante", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (resultado == System.Windows.Forms.DialogResult.Yes)
                    {
                        var r = clr.EliminarR();

                        if (r)
                        {
                            MessageBox.Show("Recinto Eliminado correctamente", "Mensaje Importante",
                            MessageBoxButtons.OK);

                            txt_nombre.Clear();
                            txt_nombre1.Clear();
                            txt_id.Clear();
                            txt_direccion.Clear();
                            cmb_funcionario.SelectedIndex = 0;
                            cmb_region.SelectedIndex = 0;
                            cmb_provincia.SelectedIndex = 0;
                            cmb_ciudad.SelectedIndex = 0;
                            cmb_estado.SelectedIndex = 0;
                            txt_path_image.Clear();
                            dt_lista.ItemsSource = null;
                            dt_lista.ItemsSource = clr.Lista();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo Eliminar el recinto",
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
                if (txt_id.Text == "")
                {
                    DialogResult resultado = MessageBox.Show("Debe seleccionar un recinto de la lista",
                    "Mensaje Importante",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                }
                else
                {
                    if (txt_nombre.Text == "" || txt_direccion.Text == "" || txt_path_image.Text == "")
                    {
                        DialogResult resultado = MessageBox.Show("Debe completar todos los campos como el Nombre, Direccion y URL Imagen",
                        "Mensaje Importante",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    }
                    else
                    {
                        Ciudad c = (Ciudad)cmb_ciudad.SelectedValue;
                        Funci f = (Funci)cmb_funcionario.SelectedValue;
                        
                        ClRecinto clr = new ClRecinto();
                        clr.Id = int.Parse(txt_id.Text);
                        clr.Nombre = txt_nombre.Text;
                        clr.Direccion = txt_direccion.Text;
                        clr.FuncionarioId = f.ID;
                        clr.CiudadId = c.ID;
                        clr.EstadoRecintoId = cmb_estado.SelectedIndex + 1;
                        clr.ImagePath = txt_path_image.Text;


                        DialogResult resultado = MessageBox.Show("¿Está seguro que desea modificar al recinto " + txt_nombre1.Text + "?",
                        "Mensaje Importante",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Exclamation);
                        if (resultado == System.Windows.Forms.DialogResult.Yes)
                        {
                            var r = clr.ModificarR();
                            if (r)
                            {
                                MessageBox.Show("Recinto Modificado correctamente", "Mensaje Importante",
                                MessageBoxButtons.OK);
                                txt_nombre.Clear();
                                txt_nombre1.Clear();
                                txt_id.Clear();
                                txt_direccion.Clear();
                                cmb_funcionario.SelectedIndex = 0;
                                cmb_region.SelectedIndex = 0;
                                cmb_provincia.SelectedIndex = 0;
                                cmb_ciudad.SelectedIndex = 0;
                                cmb_estado.SelectedIndex = 0;
                                txt_path_image.Clear();
                                dt_lista.ItemsSource = clr.Lista();

                            }
                            else
                            {
                                MessageBox.Show("No se pudo Modificar el recinto", "Mensaje Importante",
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

        private void dt_lista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (dt_lista.SelectedIndex != -1)
                {

                    DataGrid d = sender as DataGrid;
                    DataGridRow r = (DataGridRow)d.ItemContainerGenerator.ContainerFromIndex(d.SelectedIndex);
                    DataGridCell rc0 = d.Columns[0].GetCellContent(r).Parent as DataGridCell;
                    txt_id.Text = ((TextBlock)rc0.Content).Text;

                    DataGridCell rc1 = d.Columns[1].GetCellContent(r).Parent as DataGridCell;
                    txt_nombre.Text = ((TextBlock)rc1.Content).Text;
                    txt_nombre1.Text = ((TextBlock)rc1.Content).Text;

                    DataGridCell rc2 = d.Columns[2].GetCellContent(r).Parent as DataGridCell;
                    txt_direccion.Text = ((TextBlock)rc2.Content).Text;
                    
                    DataGridCell rc5 = d.Columns[5].GetCellContent(r).Parent as DataGridCell;
                    cmb_estado.SelectedIndex = int.Parse(((TextBlock)rc5.Content).Text) - 1;

                    DataGridCell rc8 = d.Columns[8].GetCellContent(r).Parent as DataGridCell;
                    txt_path_image.Text = ((TextBlock)rc8.Content).Text;

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
