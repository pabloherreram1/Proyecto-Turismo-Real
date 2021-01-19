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

using System.Windows.Forms;
using TurismoRealFF.Controlador;
using TurismoRealFF.Modelo;
using MessageBox = System.Windows.Forms.MessageBox;

namespace TurismoRealFF.Vistas.Informes
{
    /// <summary>
    /// Lógica de interacción para ReporteReserva.xaml
    /// </summary>
    public partial class ReporteReserva : Window
    {

        ClReserva clr = new ClReserva();
        public ReporteReserva()
        {
            InitializeComponent();
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void btn_consultar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dt_lista.ItemsSource = null;
                dt_lista.Items.Refresh();

                Reserva r = new Reserva();

                if (ckb_depto.IsChecked == false)
                {
                    Recinto rec = (Recinto)cmb_recinto.SelectedItem;
                    Departamento departamentos = new Departamento();
                    var departamento = departamentos.ListarDeptoBuscada(rec.ID);
                    foreach (var deptos in departamento)
                    {
                        List<Reserva> lista = new List<Reserva>(r.BusquedaR(deptos.ID));

                        foreach (var reser in lista)
                        {

                            if (cmb_tipo.SelectedIndex == 0)
                            {
                                if (ckb_mes.IsChecked == false)
                                {
                                    int anio = int.Parse(DateTime.Now.ToString("yyyy"));
                                    dt_lista.ItemsSource = r.BusquedaRA(deptos.ID,anio);
                                }
                                else
                                {
                                    if (ckb_dia.IsChecked == false)
                                    {
                                        int mes = cmb_mes.SelectedIndex + 1;
                                        dt_lista.ItemsSource = r.BusquedaRM(deptos.ID, mes);
                                    }
                                    else
                                    {
                                        int mes = cmb_mes.SelectedIndex + 1;
                                        int dia = cmb_dia.SelectedIndex;
                                        dt_lista.ItemsSource = r.BusquedaRD(deptos.ID, mes, dia);
                                    }
                                }
                            }
                            else
                            {
                                if (cmb_tipo.SelectedIndex == 1)
                                {
                                    if (ckb_mes.IsChecked == false)
                                    {
                                        int anio = int.Parse(DateTime.Now.ToString("yyyy"));
                                        dt_lista.ItemsSource = r.BusquedaTuA(deptos.ID, anio, reser.FECHA_INICIO, reser.FECHA_TERMINO);
                                    }
                                    else
                                    {
                                        if (ckb_dia.IsChecked == false)
                                        {
                                            int mes = cmb_mes.SelectedIndex + 1;
                                            dt_lista.ItemsSource = r.BusquedaTuM(deptos.ID, mes, reser.FECHA_INICIO, reser.FECHA_TERMINO);
                                        }
                                        else
                                        {
                                            int mes = cmb_mes.SelectedIndex + 1;
                                            int dia = cmb_dia.SelectedIndex;
                                            dt_lista.ItemsSource = r.BusquedaTuD(deptos.ID, mes, dia, reser.FECHA_INICIO, reser.FECHA_TERMINO);
                                        }
                                    }
                                }
                                else
                                {
                                    if (cmb_tipo.SelectedIndex == 2)
                                    {
                                        if (ckb_mes.IsChecked == false)
                                        {
                                            int anio = int.Parse(DateTime.Now.ToString("yyyy"));
                                            dt_lista.ItemsSource = r.BusquedaTrA(deptos.ID, anio, reser.FECHA_INICIO, reser.FECHA_TERMINO);
                                        }
                                        else
                                        {
                                            if (ckb_dia.IsChecked == false)
                                            {
                                                int mes = cmb_mes.SelectedIndex + 1;
                                                dt_lista.ItemsSource = r.BusquedaTrM(deptos.ID, mes, reser.FECHA_INICIO, reser.FECHA_TERMINO);
                                            }
                                            else
                                            {
                                                int mes = cmb_mes.SelectedIndex + 1;
                                                int dia = cmb_dia.SelectedIndex;
                                                dt_lista.ItemsSource = r.BusquedaTrD(deptos.ID, mes, dia, reser.FECHA_INICIO, reser.FECHA_TERMINO);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (cmb_tipo.SelectedIndex == 3)
                                        {
                                            if (ckb_mes.IsChecked == false)
                                            {
                                                int anio = int.Parse(DateTime.Now.ToString("yyyy"));
                                                dt_lista.ItemsSource = r.BusquedaSEA(deptos.ID, anio, reser.FECHA_INICIO, reser.FECHA_TERMINO);
                                            }
                                            else
                                            {
                                                if (ckb_dia.IsChecked == false)
                                                {
                                                    int mes = cmb_mes.SelectedIndex + 1;
                                                    dt_lista.ItemsSource = r.BusquedaSEM(deptos.ID, mes, reser.FECHA_INICIO, reser.FECHA_TERMINO);
                                                }
                                                else
                                                {
                                                    int mes = cmb_mes.SelectedIndex + 1;
                                                    int dia = cmb_dia.SelectedIndex;
                                                    dt_lista.ItemsSource = r.BusquedaSED(deptos.ID, mes, dia, reser.FECHA_INICIO, reser.FECHA_TERMINO);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (ckb_mes.IsChecked == false)
                                            {
                                                int anio = int.Parse(DateTime.Now.ToString("yyyy"));
                                                dt_lista.ItemsSource = clr.ListaTodoA(deptos.ID, anio, reser.FECHA_INICIO, reser.FECHA_TERMINO);
                                            }
                                            else
                                            {
                                                if (ckb_dia.IsChecked == false)
                                                {
                                                    int mes = cmb_mes.SelectedIndex + 1;
                                                    dt_lista.ItemsSource = clr.ListaTodoM(deptos.ID, mes, reser.FECHA_INICIO, reser.FECHA_TERMINO);
                                                }
                                                else
                                                {
                                                    int mes = cmb_mes.SelectedIndex + 1;
                                                    int dia = cmb_dia.SelectedIndex;
                                                    dt_lista.ItemsSource = clr.ListaTodoD(deptos.ID, mes, dia, reser.FECHA_INICIO, reser.FECHA_TERMINO);
                                                }
                                            }
                                        }
                                    }

                                }
                            }
                        }
                    }
                }
                else
                {
                    Departamento deptos = (Departamento)cmb_depto.SelectedItem;

                    List<Reserva> lista = new List<Reserva>(r.BusquedaR(deptos.ID));

                    foreach (var reser in lista)
                    {

                        if (cmb_tipo.SelectedIndex == 0)
                        {
                            if (ckb_mes.IsChecked == false)
                            {
                                int anio = int.Parse(DateTime.Now.ToString("yyyy"));
                                dt_lista.ItemsSource = r.BusquedaRA(deptos.ID, anio);
                            }
                            else
                            {
                                if (ckb_dia.IsChecked == false)
                                {
                                    int mes = cmb_mes.SelectedIndex + 1;
                                    dt_lista.ItemsSource = r.BusquedaRM(deptos.ID, mes);
                                }
                                else
                                {
                                    int mes = cmb_mes.SelectedIndex + 1;
                                    int dia = cmb_dia.SelectedIndex;
                                    dt_lista.ItemsSource = r.BusquedaRD(deptos.ID, mes, dia);
                                }
                            }
                        }
                        else
                        {
                            if (cmb_tipo.SelectedIndex == 1)
                            {
                                if (ckb_mes.IsChecked == false)
                                {
                                    int anio = int.Parse(DateTime.Now.ToString("yyyy"));
                                    dt_lista.ItemsSource = r.BusquedaTuA(deptos.ID, anio, reser.FECHA_INICIO, reser.FECHA_TERMINO);
                                }
                                else
                                {
                                    if (ckb_dia.IsChecked == false)
                                    {
                                        int mes = cmb_mes.SelectedIndex + 1;
                                        dt_lista.ItemsSource = r.BusquedaTuM(deptos.ID, mes, reser.FECHA_INICIO, reser.FECHA_TERMINO);
                                    }
                                    else
                                    {
                                        int mes = cmb_mes.SelectedIndex + 1;
                                        int dia = cmb_dia.SelectedIndex;
                                        dt_lista.ItemsSource = r.BusquedaTuD(deptos.ID, mes, dia, reser.FECHA_INICIO, reser.FECHA_TERMINO);
                                    }
                                }
                            }
                            else
                            {
                                if (cmb_tipo.SelectedIndex == 2)
                                {
                                    if (ckb_mes.IsChecked == false)
                                    {
                                        int anio = int.Parse(DateTime.Now.ToString("yyyy"));
                                        dt_lista.ItemsSource = r.BusquedaTrA(deptos.ID, anio, reser.FECHA_INICIO, reser.FECHA_TERMINO);
                                    }
                                    else
                                    {
                                        if (ckb_dia.IsChecked == false)
                                        {
                                            int mes = cmb_mes.SelectedIndex + 1;
                                            dt_lista.ItemsSource = r.BusquedaTrM(deptos.ID, mes, reser.FECHA_INICIO, reser.FECHA_TERMINO);
                                        }
                                        else
                                        {
                                            int mes = cmb_mes.SelectedIndex + 1;
                                            int dia = cmb_dia.SelectedIndex;
                                            dt_lista.ItemsSource = r.BusquedaTrD(deptos.ID, mes, dia, reser.FECHA_INICIO, reser.FECHA_TERMINO);
                                        }
                                    }
                                }
                                else
                                {
                                    if (cmb_tipo.SelectedIndex == 3)
                                    {
                                        if (ckb_mes.IsChecked == false)
                                        {
                                            int anio = int.Parse(DateTime.Now.ToString("yyyy"));
                                            dt_lista.ItemsSource = r.BusquedaSEA(deptos.ID, anio, reser.FECHA_INICIO, reser.FECHA_TERMINO);
                                        }
                                        else
                                        {
                                            if (ckb_dia.IsChecked == false)
                                            {
                                                int mes = cmb_mes.SelectedIndex + 1;
                                                dt_lista.ItemsSource = r.BusquedaSEM(deptos.ID, mes, reser.FECHA_INICIO, reser.FECHA_TERMINO);
                                            }
                                            else
                                            {
                                                int mes = cmb_mes.SelectedIndex + 1;
                                                int dia = cmb_dia.SelectedIndex;
                                                dt_lista.ItemsSource = r.BusquedaSED(deptos.ID, mes, dia, reser.FECHA_INICIO, reser.FECHA_TERMINO);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (ckb_mes.IsChecked == false)
                                        {
                                            int anio = int.Parse(DateTime.Now.ToString("yyyy"));
                                            dt_lista.ItemsSource = clr.ListaTodoA(deptos.ID, anio, reser.FECHA_INICIO, reser.FECHA_TERMINO);
                                        }
                                        else
                                        {
                                            if (ckb_dia.IsChecked == false)
                                            {
                                                int mes = cmb_mes.SelectedIndex + 1;
                                                dt_lista.ItemsSource = clr.ListaTodoM(deptos.ID, mes, reser.FECHA_INICIO, reser.FECHA_TERMINO);
                                            }
                                            else
                                            {
                                                int mes = cmb_mes.SelectedIndex + 1;
                                                int dia = cmb_dia.SelectedIndex;
                                                dt_lista.ItemsSource = clr.ListaTodoD(deptos.ID, mes, dia, reser.FECHA_INICIO, reser.FECHA_TERMINO);
                                            }
                                        }
                                    }
                                }

                            }
                        }
                    }
                }

            }
            catch (ArgumentException ex)
            {
                ClLoggerErrores.Mensaje(ex.ToString());
                throw;
            }
        }
    

        private void btn_crear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                clr.CrearPDF(cmb_tipo, cmb_mes, cmb_dia, cmb_recinto, cmb_depto, ckb_mes, ckb_dia, ckb_depto);
                MessageBox.Show("Reporte generado Satisfactoriamente", "REPORTE GENERADO", MessageBoxButtons.OK);
            }
            catch (ArgumentException ex)
            {
                ClLoggerErrores.Mensaje(ex.ToString());
                MessageBox.Show("Error: " + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private void ButtonRecibirP_Click(object sender, RoutedEventArgs e)
        {
            RecibirPagos rp = new RecibirPagos();
            Hide();
            rp.ShowDialog();
            Close();
        }

        private void ButtonInformesE_Click(object sender, RoutedEventArgs e)
        {
            ReporteEstadistica re = new ReporteEstadistica();
            Hide();
            re.ShowDialog();
            Close();
        }

        private void reporteReserva_Loaded(object sender, RoutedEventArgs e)
        {
            clr.CRecinto(cmb_recinto);
            cmb_recinto.SelectedIndex = 0;
            cmb_mes.SelectedIndex = 0;
            cmb_mes.Items.Add("Enero");
            cmb_mes.Items.Add("Febrero");
            cmb_mes.Items.Add("Marzo");
            cmb_mes.Items.Add("Abril");
            cmb_mes.Items.Add("Mayo");
            cmb_mes.Items.Add("Junio");
            cmb_mes.Items.Add("Julio");
            cmb_mes.Items.Add("Agosto");
            cmb_mes.Items.Add("Septiembre");
            cmb_mes.Items.Add("Octubre");
            cmb_mes.Items.Add("Nobiembre");
            cmb_mes.Items.Add("Diciembre");

            cmb_tipo.Items.Add("Reserva");
            cmb_tipo.Items.Add("Tour");
            cmb_tipo.Items.Add("Transporte");
            cmb_tipo.Items.Add("Servicios Extra");
            cmb_tipo.Items.Add("Todo");
            cmb_tipo.SelectedIndex = 0;
        }

        private void cmb_mes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmb_mes.SelectedIndex == 1)
            {
                cmb_dia.Items.Clear();
                cmb_dia.Items.Add(1);
                cmb_dia.Items.Add(2);
                cmb_dia.Items.Add(3);
                cmb_dia.Items.Add(4);
                cmb_dia.Items.Add(5);
                cmb_dia.Items.Add(6);
                cmb_dia.Items.Add(7);
                cmb_dia.Items.Add(8);
                cmb_dia.Items.Add(9);
                cmb_dia.Items.Add(9);
                cmb_dia.Items.Add(10);
                cmb_dia.Items.Add(11);
                cmb_dia.Items.Add(12);
                cmb_dia.Items.Add(13);
                cmb_dia.Items.Add(14);
                cmb_dia.Items.Add(15);
                cmb_dia.Items.Add(16);
                cmb_dia.Items.Add(17);
                cmb_dia.Items.Add(18);
                cmb_dia.Items.Add(19);
                cmb_dia.Items.Add(20);
                cmb_dia.Items.Add(21);
                cmb_dia.Items.Add(22);
                cmb_dia.Items.Add(23);
                cmb_dia.Items.Add(24);
                cmb_dia.Items.Add(25);
                cmb_dia.Items.Add(26);
                cmb_dia.Items.Add(27);
                cmb_dia.Items.Add(28);
                cmb_dia.SelectedIndex = 0;
            }
            else
            {
                if (cmb_mes.SelectedIndex == 3 | cmb_mes.SelectedIndex == 5 | cmb_mes.SelectedIndex == 8 | cmb_mes.SelectedIndex == 10)
                {
                    cmb_dia.Items.Clear();
                    cmb_dia.Items.Add(1);
                    cmb_dia.Items.Add(2);
                    cmb_dia.Items.Add(3);
                    cmb_dia.Items.Add(4);
                    cmb_dia.Items.Add(5);
                    cmb_dia.Items.Add(6);
                    cmb_dia.Items.Add(7);
                    cmb_dia.Items.Add(8);
                    cmb_dia.Items.Add(9);
                    cmb_dia.Items.Add(9);
                    cmb_dia.Items.Add(10);
                    cmb_dia.Items.Add(11);
                    cmb_dia.Items.Add(12);
                    cmb_dia.Items.Add(13);
                    cmb_dia.Items.Add(14);
                    cmb_dia.Items.Add(15);
                    cmb_dia.Items.Add(16);
                    cmb_dia.Items.Add(17);
                    cmb_dia.Items.Add(18);
                    cmb_dia.Items.Add(19);
                    cmb_dia.Items.Add(20);
                    cmb_dia.Items.Add(21);
                    cmb_dia.Items.Add(22);
                    cmb_dia.Items.Add(23);
                    cmb_dia.Items.Add(24);
                    cmb_dia.Items.Add(25);
                    cmb_dia.Items.Add(26);
                    cmb_dia.Items.Add(27);
                    cmb_dia.Items.Add(28);
                    cmb_dia.Items.Add(29);
                    cmb_dia.Items.Add(30);
                    cmb_dia.SelectedIndex = 0;
                }
                else
                {
                    cmb_dia.Items.Clear();
                    cmb_dia.Items.Add(1);
                    cmb_dia.Items.Add(2);
                    cmb_dia.Items.Add(3);
                    cmb_dia.Items.Add(4);
                    cmb_dia.Items.Add(5);
                    cmb_dia.Items.Add(6);
                    cmb_dia.Items.Add(7);
                    cmb_dia.Items.Add(8);
                    cmb_dia.Items.Add(9);
                    cmb_dia.Items.Add(9);
                    cmb_dia.Items.Add(10);
                    cmb_dia.Items.Add(11);
                    cmb_dia.Items.Add(12);
                    cmb_dia.Items.Add(13);
                    cmb_dia.Items.Add(14);
                    cmb_dia.Items.Add(15);
                    cmb_dia.Items.Add(16);
                    cmb_dia.Items.Add(17);
                    cmb_dia.Items.Add(18);
                    cmb_dia.Items.Add(19);
                    cmb_dia.Items.Add(20);
                    cmb_dia.Items.Add(21);
                    cmb_dia.Items.Add(22);
                    cmb_dia.Items.Add(23);
                    cmb_dia.Items.Add(24);
                    cmb_dia.Items.Add(25);
                    cmb_dia.Items.Add(26);
                    cmb_dia.Items.Add(27);
                    cmb_dia.Items.Add(28);
                    cmb_dia.Items.Add(29);
                    cmb_dia.Items.Add(30);
                    cmb_dia.Items.Add(31);
                    cmb_dia.SelectedIndex = 0;
                }
            }
        }

        private void cmb_recinto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Recinto r = (Recinto)cmb_recinto.SelectedValue;
                int s = -1;
                if (cmb_recinto.SelectedIndex.ToString() != s.ToString())
                {

                    int p = r.ID;
                    clr.CDeptoB(cmb_depto, p);
                    cmb_depto.SelectedIndex = 0;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void ButtonAtras_Click(object sender, RoutedEventArgs e)
        {
            MenuInformes mi = new MenuInformes();
            Hide();
            mi.ShowDialog();
            Close();
        }
    }
}
