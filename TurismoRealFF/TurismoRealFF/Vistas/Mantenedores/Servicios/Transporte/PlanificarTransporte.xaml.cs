using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TurismoRealFF.Controlador;
using Application = System.Windows.Application;
using DataGrid = System.Windows.Controls.DataGrid;
using DataGridCell = System.Windows.Controls.DataGridCell;
using MessageBox = System.Windows.Forms.MessageBox;

namespace TurismoRealFF.Vistas.Mantenedores.Servicios.Transporte
{
    /// <summary>
    /// Lógica de interacción para PlanificarTransporte.xaml
    /// </summary>
    public partial class PlanificarTransporte : Window
    {
        public PlanificarTransporte()
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

        private void transporte_Loaded(object sender, RoutedEventArgs e)
        {
            ClTransporte clt = new ClTransporte();
            dt_listaClientes.ItemsSource = clt.Lista();

            cmb_hora.Items.Add("00:00");
            cmb_hora.Items.Add("00:30");
            cmb_hora.Items.Add("01:00");
            cmb_hora.Items.Add("01:30");
            cmb_hora.Items.Add("02:00");
            cmb_hora.Items.Add("02:30");
            cmb_hora.Items.Add("03:00");
            cmb_hora.Items.Add("03:30");
            cmb_hora.Items.Add("04:00");
            cmb_hora.Items.Add("04:30");
            cmb_hora.Items.Add("05:00");
            cmb_hora.Items.Add("05:30");
            cmb_hora.Items.Add("06:00");
            cmb_hora.Items.Add("06:30");
            cmb_hora.Items.Add("07:00");
            cmb_hora.Items.Add("07:30");
            cmb_hora.Items.Add("08:00");
            cmb_hora.Items.Add("08:30");
            cmb_hora.Items.Add("09:00");
            cmb_hora.Items.Add("09:30");
            cmb_hora.Items.Add("10:00");
            cmb_hora.Items.Add("10:30");
            cmb_hora.Items.Add("11:00");
            cmb_hora.Items.Add("11:30");
            cmb_hora.Items.Add("12:00");
            cmb_hora.Items.Add("12:30");
            cmb_hora.Items.Add("13:00");
            cmb_hora.Items.Add("13:30");
            cmb_hora.Items.Add("14:00");
            cmb_hora.Items.Add("14:30");
            cmb_hora.Items.Add("15:00");
            cmb_hora.Items.Add("15:30");
            cmb_hora.Items.Add("16:00");
            cmb_hora.Items.Add("16:30");
            cmb_hora.Items.Add("17:00");
            cmb_hora.Items.Add("17:30");
            cmb_hora.Items.Add("18:00");
            cmb_hora.Items.Add("18:30");
            cmb_hora.Items.Add("19:00");
            cmb_hora.Items.Add("19:30");
            cmb_hora.Items.Add("20:00");
            cmb_hora.Items.Add("20:30");
            cmb_hora.Items.Add("21:00");
            cmb_hora.Items.Add("21:30");
            cmb_hora.Items.Add("22:00");
            cmb_hora.Items.Add("22:30");
            cmb_hora.Items.Add("23:00");
            cmb_hora.Items.Add("23:30");
            cmb_hora.SelectedIndex = 0;
            DateTime year = new DateTime();
            year = DateTime.Now;
            int y = year.Year;
            dtp_fecha.DisplayDateStart = new DateTime(y, 1, 1);
            dtp_fecha.DisplayDateEnd = new DateTime(y, 12, 31);
            dtp_fecha.FirstDayOfWeek = DayOfWeek.Monday;
            dtp_fecha.BlackoutDates.AddDatesInPast();
        }

        private void dt_listaClientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (dt_listaClientes.SelectedIndex != -1)
                {
                    DataGrid d = sender as DataGrid;
                    DataGridRow r = (DataGridRow)d.ItemContainerGenerator.ContainerFromIndex(d.SelectedIndex);
                    DataGridCell rc0 = d.Columns[0].GetCellContent(r).Parent as DataGridCell;
                    txt_idTransporte.Text = ((TextBlock)rc0.Content).Text;

                    DataGridCell rc1 = d.Columns[1].GetCellContent(r).Parent as DataGridCell;
                    txt_destino.Text = ((TextBlock)rc1.Content).Text;

                    DataGridCell rc3 = d.Columns[3].GetCellContent(r).Parent as DataGridCell;
                    txt_idCiudad.Text = ((TextBlock)rc3.Content).Text;

                    DataGridCell rc4 = d.Columns[4].GetCellContent(r).Parent as DataGridCell;
                    txt_nomciudad.Text = ((TextBlock)rc4.Content).Text;

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex);
            }
        }

        private void dt_listaConductores_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (dt_listaClientes.SelectedIndex != -1)
                {
                    DataGrid d = sender as DataGrid;
                    DataGridRow r = (DataGridRow)d.ItemContainerGenerator.ContainerFromIndex(d.SelectedIndex);
                    DataGridCell rc0 = d.Columns[0].GetCellContent(r).Parent as DataGridCell;
                    txt_idConductor.Text = ((TextBlock)rc0.Content).Text;

                    //DataGridCell rc1 = d.Columns[1].GetCellContent(r).Parent as DataGridCell;
                    //txt_dv.Text = ((TextBlock)rc1.Content).Text;

                    DataGridCell rc2 = d.Columns[2].GetCellContent(r).Parent as DataGridCell;
                    txt_conductor.Text = ((TextBlock)rc2.Content).Text;

                    DataGridCell rc3 = d.Columns[3].GetCellContent(r).Parent as DataGridCell;
                    txt_telefono.Text = ((TextBlock)rc3.Content).Text;

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex);
            }
        }

        private void btn_buscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txt_idTransporte.Text == "")
                {
                    DialogResult resultado = MessageBox.Show("Debe seleccionar un Transporte de la Primera Lista",
                    "Mensaje Importante",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                }
                else
                {

                    ClTransporte t = new ClTransporte();
                    t.CiudadId = int.Parse(txt_idCiudad.Text);
                    dt_listaConductores.ItemsSource = t.BusquedaConductor();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btn_generar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txt_idTransporte.Text == "")
                {
                    DialogResult resultado = MessageBox.Show("Debe seleccionar un Transporte de la Primera Lista",
                    "Mensaje Importante",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                }
                else
                {
                    if (txt_idConductor.Text == "")
                    {
                        DialogResult resultado = MessageBox.Show("Debe seleccionar un Conductor de la Segunda Lista",
                        "Mensaje Importante",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (txt_precio.Text == "")
                        {
                            DialogResult resultado = MessageBox.Show("Debe completar todos los campos como el Precio, Hora y Minuto",
                            "Mensaje Importante",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        }
                        else
                        {
                            ClTransporte clt = new ClTransporte();
                            clt.Id = int.Parse(txt_idTransporte.Text);
                            clt.Precio = int.Parse(txt_precio.Text);
                            clt.ConductorId = int.Parse(txt_idConductor.Text);
                            string fec = dtp_fecha.SelectedDate.Value.ToString("dd/MM/yyyy") + ' ' + cmb_hora.SelectedItem;
                            clt.UpdatedAt = DateTime.Parse(fec);
                            DialogResult resultado = MessageBox.Show("¿Está seguro que desea generar planificación con el destino " + txt_destino.Text + "?",
                            "Mensaje Importante",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Exclamation);
                            if (resultado == System.Windows.Forms.DialogResult.Yes)
                            {
                                var r = clt.Modificar();
                                if (r)
                                {
                                    MessageBox.Show("La planificación del transporte ha sido generado correctamente", "Mensaje Importante",
                                    MessageBoxButtons.OK);
                                    txt_idCiudad.Clear();
                                    txt_destino.Clear();
                                    txt_telefono.Clear();
                                    txt_precio.Clear();
                                    cmb_hora.SelectedIndex = 0;
                                    txt_conductor.Clear();
                                    txt_idConductor.Clear();
                                    dt_listaClientes.Items.Refresh();
                                    dt_listaClientes.ItemsSource = clt.Lista();
                                    dt_listaClientes.Items.Refresh();

                                }
                                else
                                {
                                    MessageBox.Show("No se pudo generar la planificación de transporte", "Mensaje Importante",
                                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonServicioE_Click(object sender, RoutedEventArgs e)
        {
            ServicioExtra.MenuServicioExtra sm = new ServicioExtra.MenuServicioExtra();
            Hide();
            sm.ShowDialog();
            Close();
        }

        private void ButtonTransporte_Click(object sender, RoutedEventArgs e)
        {
            Transporte.PlanificarTransporte tp = new PlanificarTransporte();
            Hide();
            tp.ShowDialog();
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
