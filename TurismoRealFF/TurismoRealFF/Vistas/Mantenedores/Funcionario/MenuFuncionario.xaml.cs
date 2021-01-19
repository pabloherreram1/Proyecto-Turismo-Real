using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TurismoRealFF.Vistas.Mantenedores.Funcionario
{
    /// <summary>
    /// Lógica de interacción para MenuFuncionario.xaml
    /// </summary>
    public partial class MenuFuncionario : Window
    {
        public MenuFuncionario()
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

        private void ButtonAtras_Click(object sender, RoutedEventArgs e)
        {
            MenuMantenedores men = new MenuMantenedores();
            Hide();
            men.ShowDialog();
            Close();
        }
    }
}
