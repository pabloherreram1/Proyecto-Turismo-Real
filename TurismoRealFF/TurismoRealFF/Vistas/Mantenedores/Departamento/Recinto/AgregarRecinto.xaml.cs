using System;
using System.Collections.Generic;
using System.IO;
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
using Application = System.Windows.Forms.Application;
using MessageBox = System.Windows.Forms.MessageBox;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;
using Region = TurismoRealFF.Modelo.Region;


namespace TurismoRealFF.Vistas.Mantenedores.Departamento.Recinto
{
    /// <summary>
    /// Lógica de interacción para AgregarRecinto.xaml
    /// </summary>
    public partial class AgregarRecinto : Window
    {
        public AgregarRecinto()
        {
            InitializeComponent();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
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

        private void agregarRecinto_Loaded(object sender, RoutedEventArgs e)
        {
            ClCliente clc = new ClCliente();
            //Llenar combox region
            clc.CRegiones(cmb_region);
            cmb_region.SelectedIndex = 0;
            cmb_provincia.SelectedIndex = 0;
            cmb_ciudad.SelectedIndex = 0;
        }

        private void btn_agregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int img = 0;
                if (txt_nombreRecinto.Text == "" | txt_direccion.Text == "")
                {
                    DialogResult resultado = MessageBox.Show("Debe completar todos los campos",
                    "Mensaje Importante",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                }
                else
                {
                    ClRecinto clr = new ClRecinto();
                    clr.Nombre = txt_nombreRecinto.Text;
                    clr.Direccion = txt_direccion.Text;
                    Ciudad c = (Ciudad)cmb_ciudad.SelectedValue;
                    clr.CiudadId = c.ID;
                    clr.EstadoRecintoId = 2;
                    if (txt_imagePath.Text == "")
                    {
                        img = 0;
                    }
                    else
                    {
                        img = 1;
                        clr.ImagePath = txt_imagePath.Text;
                    }


                    DialogResult resultado = MessageBox.Show("¿Está seguro que desea Ingresar el Recinto " + txt_nombreRecinto.Text + "?",
                    "Mensaje Importante",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Exclamation);
                    if (resultado == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (img == 0)
                        {
                            var r = clr.Registrar();
                            if (r)
                            {
                                MessageBox.Show("Recinto agregado correctamente",
                                "Mensaje Importante",
                                MessageBoxButtons.OK);

                                MenuRecinto mr = new MenuRecinto();
                                Hide();
                                mr.ShowDialog();
                                Close();
                            }
                            else
                            {
                                MessageBox.Show("No se pudo Ingresar el Recinto",
                                "Mensaje Importante",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Stop);
                            }
                        }
                        else
                        {
                            var r = clr.Registrar2();
                            if (r)
                            {
                                MessageBox.Show("Recinto agregado correctamente",
                                "Mensaje Importante",
                                MessageBoxButtons.OK);

                                MenuRecinto mr = new MenuRecinto();
                                Hide();
                                mr.ShowDialog();
                                Close();
                            }
                            else
                            {
                                MessageBox.Show("No se pudo Ingresar el Recinto",
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
                MessageBox.Show("Error al ingresar el recinto: " + ex.Message);
                throw;
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
    }
    
}
