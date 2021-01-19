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

namespace TurismoRealFF.Vistas.Mantenedores.Departamento.Depto
{
    /// <summary>
    /// Lógica de interacción para MenuDepartamento.xaml
    /// </summary>
    public partial class MenuDepartamentos : Window
    {
        public MenuDepartamentos()
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

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ButtonAtras_Click(object sender, RoutedEventArgs e)
        {
            MenuDepartamento md = new MenuDepartamento();
            Hide();
            md.ShowDialog();
            Close();
        }

        private void ButtonImagenD_Click(object sender, RoutedEventArgs e)
        {
            ImagenDepartamento idp = new ImagenDepartamento();
            Hide();
            idp.ShowDialog();
            Close();
        }
    }
}
