using System;
using System.Windows;

namespace TurismoRealFF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ButtonOpenMenu.Visibility = Visibility.Collapsed;
                ButtonCloseMenu.Visibility = Visibility.Visible;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
                throw;
            }
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            Vistas.Login Vl = new Vistas.Login();
            Hide();
            Vl.ShowDialog();
            Close();
        }
    }
}
