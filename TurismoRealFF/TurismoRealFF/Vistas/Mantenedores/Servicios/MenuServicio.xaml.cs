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

namespace TurismoRealFF.Vistas.Mantenedores.Servicios
{
    /// <summary>
    /// Lógica de interacción para MenuServicio.xaml
    /// </summary>
    public partial class MenuServicio : Window
    {
        public MenuServicio()
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

        private void ButtonServicioE_Click(object sender, RoutedEventArgs e)
        {
            ServicioExtra.MenuServicioExtra ms = new ServicioExtra.MenuServicioExtra();
            Hide();
            ms.ShowDialog();
            Close();
        }

        private void ButtonTransporte_Click(object sender, RoutedEventArgs e)
        {
            Transporte.PlanificarTransporte tp = new Transporte.PlanificarTransporte();
            Hide();
            tp.ShowDialog();
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
