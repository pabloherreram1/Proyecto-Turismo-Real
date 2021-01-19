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

namespace TurismoRealFF.Vistas
{
    /// <summary>
    /// Lógica de interacción para MenuPrincipal.xaml
    /// </summary>
    public partial class MenuPrincipal : Window
    {
        public MenuPrincipal()
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

        private void ButtonInformes_Click(object sender, RoutedEventArgs e)
        {
            Informes.MenuInformes im = new Informes.MenuInformes();
            Hide();
            im.ShowDialog();
            Close();
        }

        private void ButtonMantencion_Click(object sender, RoutedEventArgs e)
        {
            Mantencion.MenuMantencion mm = new Mantencion.MenuMantencion();
            Hide();
            mm.ShowDialog();
            Close();
        }



        private void ButtonMantenedores_Click(object sender, RoutedEventArgs e)
        {
            Mantenedores.MenuMantenedores mme = new Mantenedores.MenuMantenedores();
            Hide();
            mme.ShowDialog();
            Close();
        }

        private void ButtonAtras_Click(object sender, RoutedEventArgs e)
        {
            Login l = new Login();
            Hide();
            l.ShowDialog();
            Close();
        }
    }
}
