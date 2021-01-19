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
using MessageBox = System.Windows.Forms.MessageBox;

namespace TurismoRealFF.Vistas.Mantenedores.Departamento.Depto
{
    /// <summary>
    /// Lógica de interacción para AgregarDepartamento.xaml
    /// </summary>
    public partial class AgregarDepartamento : Window
    {
        public AgregarDepartamento()
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

        private void AgregarDepto_Loaded(object sender, RoutedEventArgs e)
        {
            ClProducto clp = new ClProducto();

            clp.CRecinto(cmb_recinto);
            cmb_recinto.SelectedIndex = 0;

        }

        private void btn_agregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int img = 0;
                if (txt_nombre.Text == "" | txt_descripcion.Text == "" | txt_ndormitorio.Text == "" | txt_nbanos.Text == "" | txt_dimension.Text == "" | txt_precio.Text == "")
                {
                    DialogResult resultado = MessageBox.Show("Debe completar todos los campos",
                    "Mensaje Importante",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                }
                else
                {
                    ClDepartamento cld = new ClDepartamento();
                    cld.Nombre = txt_nombre.Text;
                    cld.Descripcion = txt_descripcion.Text;
                    cld.NDormitorio = int.Parse(txt_ndormitorio.Text);
                    cld.NBanos = int.Parse(txt_nbanos.Text);
                    cld.Dimension = int.Parse(txt_dimension.Text);
                    cld.Precio = int.Parse(txt_precio.Text);

                    Modelo.Recinto r = (Modelo.Recinto)cmb_recinto.SelectedValue;
                    cld.RecintoId = r.ID;
                    if (txt_image_path.Text == "")
                    {
                        img = 0;
                    }
                    else
                    {
                        img = 1;
                    }


                    DialogResult resultado = MessageBox.Show("¿Está seguro que desea Ingresar el Dormitorio " + txt_nombre.Text + "?",
                    "Mensaje Importante",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Exclamation);
                    if (resultado == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (img == 0)
                        {
                            var reg = cld.Registrar();
                            if (reg)
                            {
                                MessageBox.Show("Departamento agregado correctamente",
                                "Mensaje Importante",
                                MessageBoxButtons.OK);

                                MenuDepartamentos md = new MenuDepartamentos();
                                Hide();
                                md.ShowDialog();
                                Close();
                            }
                            else
                            {
                                MessageBox.Show("No se pudo Ingresar el Departamento",
                                "Mensaje Importante",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Stop);
                            }
                        }
                        else
                        {

                            string ImagePath = txt_image_path.Text;
                            var reg = cld.Registrar2(ImagePath);
                            if (reg)
                            {
                                MessageBox.Show("Departamento agregado correctamente",
                                "Mensaje Importante",
                                MessageBoxButtons.OK);

                                MenuDepartamentos md = new MenuDepartamentos();
                                Hide();
                                md.ShowDialog();
                                Close();
                            }
                            else
                            {
                                MessageBox.Show("No se pudo Ingresar el Departamento",
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
                MessageBox.Show("Error al ingresar el Departamento: " + ex.Message);
                throw;
            }
        }
    }
}
