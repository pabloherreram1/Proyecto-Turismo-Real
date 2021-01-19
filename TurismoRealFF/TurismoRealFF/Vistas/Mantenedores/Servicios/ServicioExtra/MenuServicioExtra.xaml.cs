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

namespace TurismoRealFF.Vistas.Mantenedores.Servicios.ServicioExtra
{
    /// <summary>
    /// Lógica de interacción para MenuServicioExtra.xaml
    /// </summary>
    public partial class MenuServicioExtra : Window
    {
        public MenuServicioExtra()
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

        private void ButtonAtras_Click(object sender, RoutedEventArgs e)
        {
            MenuServicio ms = new MenuServicio();
            Hide();
            ms.ShowDialog();
            Close();
        }
    }
}
