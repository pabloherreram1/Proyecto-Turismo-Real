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

namespace TurismoRealFF.Vistas.Informes
{
    /// <summary>
    /// Lógica de interacción para MenuInformes.xaml
    /// </summary>
    public partial class MenuInformes : Window
    {
        public MenuInformes()
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

        private void ButtonRecibirP_Click(object sender, RoutedEventArgs e)
        {
            RecibirPagos rp = new RecibirPagos();
            Hide();
            rp.ShowDialog();
            Close();
        }

        private void ButtonAtras_Click(object sender, RoutedEventArgs e)
        {
            MenuPrincipal mp = new MenuPrincipal();
            Hide();
            mp.ShowDialog();
            Close();
        }

        private void ButtonInformesE_Click(object sender, RoutedEventArgs e)
        {
            ReporteEstadistica re = new ReporteEstadistica();
            Hide();
            re.ShowDialog();
            Close();
        }

        private void ButtonInformesR_Click(object sender, RoutedEventArgs e)
        {
            ReporteReserva rr = new ReporteReserva();
            Hide();
            rr.ShowDialog();
            Close();
        }
    }
}
