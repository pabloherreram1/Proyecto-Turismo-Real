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
using TurismoRealFF.Vistas.Mantenedores.Departamento.Depto;

namespace TurismoRealFF.Vistas.Mantenedores.Departamento
{
    /// <summary>
    /// Lógica de interacción para MenuDepartamento.xaml
    /// </summary>
    public partial class MenuDepartamento : Window
    {
        public MenuDepartamento()
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

        private void ButtonAtras_Click(object sender, RoutedEventArgs e)
        {
            MenuMantenedores men = new MenuMantenedores();
            Hide();
            men.ShowDialog();
            Close();
        }

        private void ButtonRecinto_Click(object sender, RoutedEventArgs e)
        {
            Recinto.MenuRecinto rm = new Recinto.MenuRecinto();
            Hide();
            rm.ShowDialog();
            Close();
        }

        private void Buttondepartamento_Click(object sender, RoutedEventArgs e)
        {
            MenuDepartamentos md = new MenuDepartamentos();
            Hide();
            md.ShowDialog();
            Close();
        }
    }
}
