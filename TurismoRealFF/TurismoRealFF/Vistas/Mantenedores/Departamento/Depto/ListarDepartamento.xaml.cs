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
using Application = System.Windows.Application;
using DataGrid = System.Windows.Controls.DataGrid;
using DataGridCell = System.Windows.Controls.DataGridCell;
using MessageBox = System.Windows.Forms.MessageBox;

namespace TurismoRealFF.Vistas.Mantenedores.Departamento.Depto
{
    /// <summary>
    /// Lógica de interacción para Listar.xaml
    /// </summary>
    public partial class Listar : Window
    {
        public Listar()
        {
            InitializeComponent();
        }

        private void ButtonAgregarD_Click(object sender, RoutedEventArgs e)
        {
            AgregarDepartamento ad = new AgregarDepartamento();
            Hide();
            ad.ShowDialog();
            Close();
        }

        private void ButtonListarD_Click(object sender, RoutedEventArgs e)
        {
            Listar l = new Listar();
            Hide();
            l.ShowDialog();
            Close();
        }

        private void ButtonAtras_Click(object sender, RoutedEventArgs e)
        {
            MenuDepartamento md = new MenuDepartamento();
            Hide();
            md.ShowDialog();
            Close();
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

        private void ButtonImagenD_Click(object sender, RoutedEventArgs e)
        {
            ImagenDepartamento idp = new ImagenDepartamento();
            Hide();
            idp.ShowDialog();
            Close();
        }


        private void btn_buscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                ClDepartamento cld = new ClDepartamento();
                Modelo.Recinto r = new Modelo.Recinto();
                r = (Modelo.Recinto)cmb_recinto.SelectedValue;
                cld.RecintoId = r.ID;
                dt_lista.ItemsSource = cld.Lista();

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
                    txt_descripcion.Text = ((TextBlock)rc2.Content).Text;

                    DataGridCell rc3 = d.Columns[3].GetCellContent(r).Parent as DataGridCell;
                    txt_ndormitorio.Text = ((TextBlock)rc3.Content).Text;

                    DataGridCell rc4 = d.Columns[4].GetCellContent(r).Parent as DataGridCell;
                    txt_nbanos.Text = ((TextBlock)rc4.Content).Text;

                    DataGridCell rc5 = d.Columns[5].GetCellContent(r).Parent as DataGridCell;
                    txt_dimension.Text = ((TextBlock)rc5.Content).Text;

                    DataGridCell rc6 = d.Columns[6].GetCellContent(r).Parent as DataGridCell;
                    txt_precio.Text = ((TextBlock)rc6.Content).Text;

                    DataGridCell rc7 = d.Columns[7].GetCellContent(r).Parent as DataGridCell;
                    txt_recinto.Text = ((TextBlock)rc7.Content).Text;

                    DataGridCell rc8 = d.Columns[8].GetCellContent(r).Parent as DataGridCell;
                    cmb_estado.SelectedIndex = int.Parse(((TextBlock)rc5.Content).Text) - 1;
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
                if (txt_id.Text == "")
                {
                    DialogResult result = MessageBox.Show("Debe seleccionar un departamento de la lista",
                    "Mensaje Importante",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                }
                else
                {
                    ClDepartamento cld = new ClDepartamento();
                    cld.Id = int.Parse(txt_id.Text);
                    DialogResult resultado = MessageBox.Show("¿Está seguro que desea eliminar al departamento " + txt_nombre1.Text + "?",
                    "Mensaje Importante", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (resultado == System.Windows.Forms.DialogResult.Yes)
                    {
                        var r = cld.EliminarR();

                        if (r)
                        {
                            MessageBox.Show("departamento Eliminado correctamente", "Mensaje Importante",
                            MessageBoxButtons.OK);

                            txt_nombre.Clear();
                            txt_nombre1.Clear();
                            txt_id.Clear();
                            txt_descripcion.Clear();
                            txt_ndormitorio.Clear();
                            txt_nbanos.Clear();
                            txt_dimension.Clear();
                            txt_descripcion.Clear();
                            txt_precio.Clear();
                            cmb_estado.SelectedIndex = 0;
                            dt_lista.ItemsSource = null;
                            dt_lista.ItemsSource = cld.Lista();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo Eliminar el departamento",
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
                    if (txt_nombre.Text == "" || txt_descripcion.Text == "" || txt_ndormitorio.Text == "" || txt_nbanos.Text == "" || txt_dimension.Text == "" || txt_precio.Text == "")
                    {
                        DialogResult resultado = MessageBox.Show("Debe completar todos los campos como el Nombre, Descripción, N° de Dormitorios, N° de Baños, Dimensión y Precio",
                        "Mensaje Importante",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    }
                    else
                    {
                        ClDepartamento cld = new ClDepartamento();
                        cld.Id = int.Parse(txt_id.Text);
                        Modelo.Recinto r = new Modelo.Recinto();
                        r = (Modelo.Recinto)cmb_recinto.SelectedValue;
                        cld.RecintoId = r.ID;
                        cld.Nombre = txt_nombre.Text;
                        cld.Descripcion = txt_descripcion.Text;
                        cld.NDormitorio = int.Parse(txt_ndormitorio.Text);
                        cld.NBanos = int.Parse(txt_nbanos.Text);
                        cld.Dimension = int.Parse(txt_dimension.Text);
                        cld.Precio = int.Parse(txt_precio.Text);

                        cld.EstadoDptoId = cmb_estado.SelectedIndex + 1;
                        

                        DialogResult resultado = MessageBox.Show("¿Está seguro que desea modificar al departamento " + txt_nombre1.Text + "?",
                        "Mensaje Importante",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Exclamation);
                        if (resultado == System.Windows.Forms.DialogResult.Yes)
                        {
                            var re = cld.ModificarR();
                            if (re)
                            {
                                MessageBox.Show("Departamento Modificado correctamente", "Mensaje Importante",
                                MessageBoxButtons.OK);
                                txt_nombre.Clear();
                                txt_nombre1.Clear();
                                txt_id.Clear();
                                txt_descripcion.Clear();
                                txt_ndormitorio.Clear();
                                txt_nbanos.Clear();
                                txt_dimension.Clear();
                                txt_descripcion.Clear();
                                txt_precio.Clear();
                                cmb_estado.SelectedIndex = 0;
                                dt_lista.ItemsSource = null;
                                dt_lista.ItemsSource = cld.Lista();

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

        private void ListarDepto_Loaded(object sender, RoutedEventArgs e)
        {

            cmb_estado.Items.Add("EN USO");
            cmb_estado.Items.Add("DESALOJADO");
            cmb_estado.Items.Add("EN MANTENCION");

            ClProducto clp = new ClProducto();
            clp.CRecinto(cmb_recinto);
            cmb_recinto.SelectedIndex = 0;

            ClDepartamento cld = new ClDepartamento();
            Modelo.Recinto r = new Modelo.Recinto();
            r = (Modelo.Recinto)cmb_recinto.SelectedValue;
            cld.RecintoId = r.ID;
            dt_lista.ItemsSource = cld.Lista();
        }
    }
}
