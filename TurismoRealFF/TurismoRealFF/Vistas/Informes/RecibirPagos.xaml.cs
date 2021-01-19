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
using TurismoRealFF.Controlador;

namespace TurismoRealFF.Vistas.Informes
{
    /// <summary>
    /// Lógica de interacción para RecibirPagos.xaml
    /// </summary>
    public partial class RecibirPagos : Window
    {
        public RecibirPagos()
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

       
        private void recibirPago_Loaded(object sender, RoutedEventArgs e)
        {
            ClBoleta clb = new ClBoleta();
            dt_lista.ItemsSource = clb.Listar();
        }

        private void ButtonAtras_Click(object sender, RoutedEventArgs e)
        {
            MenuInformes mi = new MenuInformes();
            Hide();
            mi.ShowDialog();
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
