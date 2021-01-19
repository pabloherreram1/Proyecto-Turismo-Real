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

namespace TurismoRealFF.Vistas.Mantenedores.Departamento.Depto
{
    /// <summary>
    /// Lógica de interacción para ImagenDepartamento.xaml
    /// </summary>
    public partial class ImagenDepartamento : Window
    {
        public ImagenDepartamento()
        {
            InitializeComponent();
        }

        private void ButtonImagenD_Click(object sender, RoutedEventArgs e)
        {
            ImagenDepartamento idp = new ImagenDepartamento();
            Hide();
            idp.ShowDialog();
            Close();
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

        private void ButtonAtras_Click(object sender, RoutedEventArgs e)
        {
            MenuDepartamento md = new MenuDepartamento();
            Hide();
            md.ShowDialog();
            Close();
        }


        private void ImagenDepto_Loaded(object sender, RoutedEventArgs e)
        {
            ClProducto clp = new ClProducto();

            clp.CRecinto(cmb_recinto);
            cmb_recinto.SelectedIndex = 0;
        }


        private void btn_buscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                Modelo.Departamento d = (Modelo.Departamento)cmb_depto.SelectedValue;
                ClDepartamento cld = new ClDepartamento
                {
                    Id = d.ID
                };
                var s = cld.BusquedaImg();
                if (s != null)
                {
                    dt_lista.ItemsSource = s;
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

        private void btn_eliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txt_id.Text == "")
                {
                    DialogResult result = MessageBox.Show("Debe seleccionar un elemento de la lista",
                    "Mensaje Importante",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                }
                else
                {

                    ClDepartamento cld = new ClDepartamento();
                    Modelo.Departamento d = (Modelo.Departamento)cmb_depto.SelectedValue;

                    cld.Id = d.ID;

                    int id = int.Parse(txt_id.Text);
                    
                    DialogResult resultado = MessageBox.Show("¿Está seguro que desea eliminar la URL Imagen " + txt_image_path2.Text + " del departamento " + d.NOMBRE + "?",
                    "Mensaje Importante", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (resultado == System.Windows.Forms.DialogResult.Yes)
                    {
                        cld.Id = id;
                        var r = cld.EliminarImg();

                        if (r)
                        {
                            MessageBox.Show("URL Imagen Eliminado correctamente", "Mensaje Importante",
                            MessageBoxButtons.OK);

                            txt_id.Clear();
                            txt_image_path.Clear();
                            txt_image_path2.Clear();
                            dt_lista.ItemsSource = null;
                            dt_lista.ItemsSource = cld.BusquedaImg();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo Eliminar la URL Imagen",
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

        private void btn_agregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txt_image_path.Text == txt_image_path2.Text)
                {
                    DialogResult resultado = MessageBox.Show("Ya existe esta url imagen",
                        "Mensaje Importante",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                else
                {
                    if (txt_image_path.Text == "")
                    {
                        DialogResult resultado = MessageBox.Show("Debe completar el campo de URL Imagen",
                        "Mensaje Importante",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    }
                    else
                    {
                        ClDepartamento cld = new ClDepartamento();
                        Modelo.Departamento d = (Modelo.Departamento)cmb_depto.SelectedValue;

                        cld.Id = d.ID;
                        string image = txt_image_path.Text;

                        DialogResult resultado = MessageBox.Show("¿Está seguro que desea Ingresar la URL Imagen " + txt_image_path.Text + "?",
                        "Mensaje Importante",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Exclamation);
                        if (resultado == System.Windows.Forms.DialogResult.Yes)
                        {
                            var r = cld.RegistrarImg(image);
                            if (r)
                            {
                                MessageBox.Show("URL Imagen agregada correctamente",
                                "Mensaje Importante",
                                MessageBoxButtons.OK);

                                MenuDepartamentos mr = new MenuDepartamentos();
                                Hide();
                                mr.ShowDialog();
                                Close();
                            }
                            else
                            {
                                MessageBox.Show("No se pudo Ingresar la URL Imagen",
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
                MessageBox.Show("Error al ingresar la URL Imagen: " + ex.Message);
                throw;
            }
        }

        private void btn_modificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txt_id.Text == "")
                {
                    DialogResult resultado = MessageBox.Show("Debe seleccionar el campo de URL Imagen",
                    "Mensaje Importante",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                }
                else
                {
                    int id = int.Parse(txt_id.Text);
                    int iddpto = int.Parse(txt_iddepto.Text);
                    string imagen = txt_image_path.Text;
                    string imagen2 = txt_image_path2.Text;

                    Modelo.Departamento d = (Modelo.Departamento)cmb_depto.SelectedValue;
                    if (d.ID == iddpto)
                    {
                        if (imagen == imagen2)
                        {
                            DialogResult resultado = MessageBox.Show("¿Está seguro que desea modificar la URL Imagen " + txt_image_path.Text + "?",
                            "Mensaje Importante",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Exclamation);
                            if (resultado == System.Windows.Forms.DialogResult.Yes)
                            {
                                ClDepartamento cld = new ClDepartamento();
                                cld.Id = d.ID;
                                var r = cld.ModificarImg(imagen,id);
                                if (r)
                                {
                                    MessageBox.Show("URL Imagen Modificado correctamente", "Mensaje Importante",
                                    MessageBoxButtons.OK);
                                    txt_id.Clear();
                                    txt_iddepto.Clear();
                                    txt_image_path.Clear();
                                    txt_image_path2.Clear();
                                    dt_lista.ItemsSource = null;
                                    dt_lista.ItemsSource = cld.BusquedaImg();

                                }
                                else
                                {
                                    MessageBox.Show("No se pudo Modificar la URL Imagen", "Mensaje Importante",
                                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                }
                            }
                        }
                        else
                        {
                            DialogResult resultado = MessageBox.Show("¿Está seguro que desea modificar la URL Imagen " + txt_image_path2.Text + " por " + txt_image_path.Text + "?",
                            "Mensaje Importante",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Exclamation);
                            if (resultado == System.Windows.Forms.DialogResult.Yes)
                            {
                                ClDepartamento cld = new ClDepartamento();
                                cld.Id = d.ID;
                                var r = cld.ModificarImg(imagen, id);
                                if (r)
                                {
                                    MessageBox.Show("URL Imagen Modificado correctamente", "Mensaje Importante",
                                    MessageBoxButtons.OK);
                                    txt_id.Clear();
                                    txt_iddepto.Clear();
                                    txt_image_path.Clear();
                                    txt_image_path2.Clear();
                                    dt_lista.ItemsSource = null;
                                    dt_lista.ItemsSource = cld.BusquedaImg();

                                }
                                else
                                {
                                    MessageBox.Show("No se pudo Modificar la URL Imagen", "Mensaje Importante",
                                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                }
                            }
                        }
                    }
                    else
                    {
                        DialogResult resul = MessageBox.Show("¿Está seguro que desea modificar la ubicacion del URL Imagen " + txt_image_path + " del departamento " + d.NOMBRE + "?",
                            "Mensaje Importante",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Exclamation);
                        if (resul == System.Windows.Forms.DialogResult.Yes)
                        {
                            ClDepartamento cld = new ClDepartamento();
                            cld.Id = d.ID;
                            var r = cld.ModificarImg(imagen, id);
                            if (r)
                            {
                                MessageBox.Show("URL Imagen Modificado correctamente", "Mensaje Importante",
                                MessageBoxButtons.OK);
                                txt_id.Clear();
                                txt_iddepto.Clear();
                                txt_image_path.Clear();
                                txt_image_path2.Clear();
                                dt_lista.ItemsSource = null;
                                dt_lista.ItemsSource = cld.BusquedaImg();

                            }
                            else
                            {
                                MessageBox.Show("No se pudo Modificar la URL Imagen", "Mensaje Importante",
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
                    txt_image_path.Text = ((TextBlock)rc1.Content).Text;
                    txt_image_path2.Text = ((TextBlock)rc1.Content).Text;

                    DataGridCell rc2 = d.Columns[2].GetCellContent(r).Parent as DataGridCell;
                    txt_iddepto.Text = ((TextBlock)rc2.Content).Text;
                }
            }
            catch (Exception)
            {

                throw;
            }
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
    }
}
