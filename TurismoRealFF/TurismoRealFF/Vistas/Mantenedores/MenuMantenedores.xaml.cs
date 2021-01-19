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

namespace TurismoRealFF.Vistas.Mantenedores
{
    /// <summary>
    /// Lógica de interacción para MenuMantenedores.xaml
    /// </summary>
    public partial class MenuMantenedores : Window
    {
        public MenuMantenedores()
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

        private void ButtonCliente_Click(object sender, RoutedEventArgs e)
        {
            Clientes.Modificar_cliente cm = new Clientes.Modificar_cliente();
            Hide();
            cm.ShowDialog();
            Close();
        }

        private void ButtonDepartamento_Click(object sender, RoutedEventArgs e)
        {
            Departamento.MenuDepartamento dm = new Departamento.MenuDepartamento();
            Hide();
            dm.ShowDialog();
            Close();
        }

        private void ButtonFuncionario_Click(object sender, RoutedEventArgs e)
        {
            Funcionario.MenuFuncionario fn = new Funcionario.MenuFuncionario();
            Hide();
            fn.ShowDialog();
            Close();
        }

        private void ButtonInventario_Click(object sender, RoutedEventArgs e)
        {
            Inventario.ListarInventario il = new Inventario.ListarInventario();
            Hide();
            il.ShowDialog();
            Close();
        }

        private void ButtonAtras_Click(object sender, RoutedEventArgs e)
        {
            MenuPrincipal mp = new MenuPrincipal();
            Hide();
            mp.ShowDialog();
            Close();
        }

        private void ButtonServicios_Click(object sender, RoutedEventArgs e)
        {
            Servicios.MenuServicio ms = new Servicios.MenuServicio();
            Hide();
            ms.ShowDialog();
            Close();
        }
    }
}
