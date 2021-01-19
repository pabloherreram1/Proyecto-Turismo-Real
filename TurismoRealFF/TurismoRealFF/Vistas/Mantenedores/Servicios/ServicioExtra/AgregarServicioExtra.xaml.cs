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

namespace TurismoRealFF.Vistas.Mantenedores.Servicios.ServicioExtra
{
    /// <summary>
    /// Lógica de interacción para AgregarServicioExtra.xaml
    /// </summary>
    public partial class AgregarServicioExtra : Window
    {
        public AgregarServicioExtra()
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

        private void btn_registrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txt_nombre.Text == "" || txt_precio.Text == "" || txt_descripcion.Text == "")
                {
                    DialogResult resultado = MessageBox.Show("Debe completar todos los campos",
                    "Mensaje Importante",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                }
                else
                {
                    ClServicioExtra se = new ClServicioExtra();
                    se.Nombre = txt_nombre.Text;
                    se.Descripcion = txt_descripcion.Text;
                    se.Precio = int.Parse(txt_precio.Text);

                    DialogResult resultado = MessageBox.Show("¿Está seguro que desea registrar el servicio extra " + txt_nombre.Text + "?",
                    "Mensaje Importante",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Exclamation);
                    if (resultado == System.Windows.Forms.DialogResult.Yes)
                    {
                        var r = se.registrar();
                        if (r)
                        {
                            MessageBox.Show("Servicio Extra agregado correctamente",
                            "Mensaje Importante",
                            MessageBoxButtons.OK);

                            MenuServicioExtra mse = new MenuServicioExtra();
                            Hide();
                            mse.ShowDialog();
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo Ingresar el servicio extra",
                            "Mensaje Importante",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Stop);
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
