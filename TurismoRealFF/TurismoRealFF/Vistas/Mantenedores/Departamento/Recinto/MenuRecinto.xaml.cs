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

namespace TurismoRealFF.Vistas.Mantenedores.Departamento.Recinto
{
    /// <summary>
    /// Lógica de interacción para MenuRecinto.xaml
    /// </summary>
    public partial class MenuRecinto : Window
    {
        public MenuRecinto()
        {
            InitializeComponent();
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
            MenuDepartamento med = new MenuDepartamento();
            Hide();
            med.ShowDialog();
            Close();
        }
    }
}
