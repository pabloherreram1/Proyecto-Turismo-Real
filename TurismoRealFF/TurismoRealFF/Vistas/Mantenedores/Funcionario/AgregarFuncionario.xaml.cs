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
using MessageBox = System.Windows.Forms.MessageBox;

namespace TurismoRealFF.Vistas.Mantenedores.Funcionario
{
    /// <summary>
    /// Lógica de interacción para AgregarFuncionario.xaml
    /// </summary>
    public partial class AgregarFuncionario : Window
    {
        public AgregarFuncionario()
        {
            InitializeComponent();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
           // Application.Current.Shutdown();
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

        private void ButtonAgregarF_Click(object sender, RoutedEventArgs e)
        {
            AgregarFuncionario af = new AgregarFuncionario();
            Hide();
            af.ShowDialog();
            Close();
        }

        private void ButtonListarF_Click(object sender, RoutedEventArgs e)
        {
            ListarFuncionario lf = new ListarFuncionario();
            Hide();
            lf.ShowDialog();
            Close();
        }

        private void btn_registrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txt_rut.Text == "" || txt_nombre.Text == "" || txt_apellido.Text == "" || txt_dv.Text == "" || txt_email.Text == "" || txt_pass.Text == "" || txt_telefono.Text == "")
                {
                    DialogResult resultado = MessageBox.Show("Debe completar todos los campos",
                    "Mensaje Importante",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                }
                else
                {
                    ClFuncionario func = new ClFuncionario();
                    func.Id = int.Parse(txt_rut.Text);
                    func.Digito = txt_dv.Text;
                    func.Nombre = txt_nombre.Text;
                    func.Apellido = txt_apellido.Text;
                    func.Email = txt_email.Text + "@funcionario.cl";
                    func.Pass = txt_pass.Text;
                    func.Telefono = int.Parse(txt_telefono.Text);

                    DialogResult resultado = MessageBox.Show("¿Está seguro que desea registrar al funcionario " + txt_nombre.Text + "?",
                    "Mensaje Importante",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Exclamation);
                    if (resultado == System.Windows.Forms.DialogResult.Yes)
                    {
                        var r = func.registrar();
                        if (r)
                        {
                            MessageBox.Show("Funcionario agregado correctamente",
                            "Mensaje Importante",
                            MessageBoxButtons.OK);

                            MenuFuncionario mf = new MenuFuncionario();
                            Hide();
                            mf.ShowDialog();
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo Ingresar el funcionario",
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
            MenuFuncionario mf = new MenuFuncionario();
            Hide();
            mf.ShowDialog();
            Close();
        }
    }
}
