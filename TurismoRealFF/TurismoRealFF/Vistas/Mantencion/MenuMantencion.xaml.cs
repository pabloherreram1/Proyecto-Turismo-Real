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

namespace TurismoRealFF.Vistas.Mantencion
{
    /// <summary>
    /// Lógica de interacción para MenuMantencion.xaml
    /// </summary>
    public partial class MenuMantencion : Window
    {
        public MenuMantencion()
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
            MenuPrincipal mp = new MenuPrincipal();
            Hide();
            mp.ShowDialog();
            Close();
        }

        private void ButtonDisponibilidad_Click(object sender, RoutedEventArgs e)
        {
            Disponibilidad d = new Disponibilidad();
            Hide();
            d.ShowDialog();
            Close();
        }

        private void ButtonIngresarM_Click(object sender, RoutedEventArgs e)
        {
            IngresarMantencion im = new IngresarMantencion();
            Hide();
            im.ShowDialog();
            Close();
        }

        private void ButtonListarM_Click(object sender, RoutedEventArgs e)
        {
            ListarMantencion lm = new ListarMantencion();
            Hide();
            lm.ShowDialog();
            Close();
        }
    }
}
