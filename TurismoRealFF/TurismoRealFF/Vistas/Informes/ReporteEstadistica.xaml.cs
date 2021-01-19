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
using System.Windows.Interop;
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
    /// Lógica de interacción para ReporteEstadistica.xaml
    /// </summary>
    public partial class ReporteEstadistica : Window
    {
        readonly ClFinanza clf = new ClFinanza();
        public ReporteEstadistica()
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
                ClFinanza clf = new ClFinanza();
                Finanza fi = new Finanza();

                if (cmb_tipo.SelectedIndex == 0)
                {
                    if (ckb_mes.IsChecked == false)
                    {
                        int anio = int.Parse(DateTime.Now.ToString("yyyy"));
                        dt_lista.ItemsSource = fi.BusquedaIA(anio);
                    }
                    else
                    {
                        if (ckb_dia.IsChecked == false)
                        {
                            int mes = cmb_mes.SelectedIndex + 1;
                            dt_lista.ItemsSource = fi.BusquedaIM(mes);
                        }
                        else
                        {
                            int mes = cmb_mes.SelectedIndex + 1;
                            int dia = cmb_dia.SelectedIndex + 1;
                            dt_lista.ItemsSource = fi.BusquedaID(mes,dia);
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
                            dt_lista.ItemsSource = fi.BusquedaEA(anio);
                        }
                        else
                        {
                            if (ckb_dia.IsChecked == false)
                            {
                                int mes = cmb_mes.SelectedIndex + 1;
                                dt_lista.ItemsSource = fi.BusquedaEM(mes);
                            }
                            else
                            {
                                int mes = cmb_mes.SelectedIndex + 1;
                                int dia = cmb_dia.SelectedIndex + 1;
                                dt_lista.ItemsSource = fi.BusquedaED(mes, dia);
                            }
                        }
                    }
                    else
                    {
                        if (ckb_mes.IsChecked == false)
                        {
                            int anio = int.Parse(DateTime.Now.ToString("yyyy"));
                            dt_lista.ItemsSource = fi.BusquedaTA(anio);
                        }
                        else
                        {
                            if (ckb_dia.IsChecked == false)
                            {
                                int mes = cmb_mes.SelectedIndex + 1;
                                dt_lista.ItemsSource = fi.BusquedaTM(mes);
                            }
                            else
                            {
                                int mes = cmb_mes.SelectedIndex + 1;
                                int dia = cmb_dia.SelectedIndex + 1;
                                dt_lista.ItemsSource = fi.BusquedaTD(mes, dia);
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
                clf.CrearPDF(cmb_tipo, cmb_mes, cmb_dia, ckb_mes, ckb_dia);
                MessageBox.Show("Reporte generado Satisfactoriamente", "REPORTE GENERADO", MessageBoxButtons.OK);
            }
            catch (ArgumentException ex)
            {
                ClLoggerErrores.Mensaje(ex.ToString());
                MessageBox.Show("Error: " + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
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
        private void ReporteEstadisctica_Loaded(object sender, RoutedEventArgs e)
        {
            cmb_tipo.Items.Add("Ingreso");
            cmb_tipo.Items.Add("Egreso");
            cmb_tipo.Items.Add("Todo");
            cmb_tipo.SelectedIndex = 0;
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


        }

        private void ButtonAtras_Click(object sender, RoutedEventArgs e)
        {
            MenuInformes mi = new MenuInformes();
            Hide();
            mi.ShowDialog();
            Close();
        }

        private void ButtonRecibirP_Click(object sender, RoutedEventArgs e)
        {
            RecibirPagos rp = new RecibirPagos();
            Hide();
            rp.ShowDialog();
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