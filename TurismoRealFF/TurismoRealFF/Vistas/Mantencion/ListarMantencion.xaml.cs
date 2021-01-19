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
using TurismoRealFF.Modelo;
using Application = System.Windows.Application;
using DataGrid = System.Windows.Controls.DataGrid;
using DataGridCell = System.Windows.Controls.DataGridCell;
using MessageBox = System.Windows.Forms.MessageBox;

namespace TurismoRealFF.Vistas.Mantencion
{
    /// <summary>
    /// Lógica de interacción para ListarMantencion.xaml
    /// </summary>
    public partial class ListarMantencion : Window
    {
        public ListarMantencion()
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
            MenuMantencion men = new MenuMantencion();
            Hide();
            men.ShowDialog();
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

        private void registrarMantencion_Loaded(object sender, RoutedEventArgs e)
        {
            ClMantencion clm = new ClMantencion();
            clm.CRecinto(cmb_recinto);
            cmb_recinto.SelectedIndex = 0;

            cmb_horaIni.Items.Add("00:00");
            cmb_horaIni.Items.Add("00:30");
            cmb_horaIni.Items.Add("01:00");
            cmb_horaIni.Items.Add("01:30");
            cmb_horaIni.Items.Add("02:00");
            cmb_horaIni.Items.Add("02:30");
            cmb_horaIni.Items.Add("03:00");
            cmb_horaIni.Items.Add("03:30");
            cmb_horaIni.Items.Add("04:00");
            cmb_horaIni.Items.Add("04:30");
            cmb_horaIni.Items.Add("05:00");
            cmb_horaIni.Items.Add("05:30");
            cmb_horaIni.Items.Add("06:00");
            cmb_horaIni.Items.Add("06:30");
            cmb_horaIni.Items.Add("07:00");
            cmb_horaIni.Items.Add("07:30");
            cmb_horaIni.Items.Add("08:00");
            cmb_horaIni.Items.Add("08:30");
            cmb_horaIni.Items.Add("09:00");
            cmb_horaIni.Items.Add("09:30");
            cmb_horaIni.Items.Add("10:00");
            cmb_horaIni.Items.Add("10:30");
            cmb_horaIni.Items.Add("11:00");
            cmb_horaIni.Items.Add("11:30");
            cmb_horaIni.Items.Add("12:00");
            cmb_horaIni.Items.Add("12:30");
            cmb_horaIni.Items.Add("13:00");
            cmb_horaIni.Items.Add("13:30");
            cmb_horaIni.Items.Add("14:00");
            cmb_horaIni.Items.Add("14:30");
            cmb_horaIni.Items.Add("15:00");
            cmb_horaIni.Items.Add("15:30");
            cmb_horaIni.Items.Add("16:00");
            cmb_horaIni.Items.Add("16:30");
            cmb_horaIni.Items.Add("17:00");
            cmb_horaIni.Items.Add("17:30");
            cmb_horaIni.Items.Add("18:00");
            cmb_horaIni.Items.Add("18:30");
            cmb_horaIni.Items.Add("19:00");
            cmb_horaIni.Items.Add("19:30");
            cmb_horaIni.Items.Add("20:00");
            cmb_horaIni.Items.Add("20:30");
            cmb_horaIni.Items.Add("21:00");
            cmb_horaIni.Items.Add("21:30");
            cmb_horaIni.Items.Add("22:00");
            cmb_horaIni.Items.Add("22:30");
            cmb_horaIni.Items.Add("23:00");
            cmb_horaIni.Items.Add("23:30");
            cmb_horaTer.Items.Add("00:00");
            cmb_horaTer.Items.Add("00:30");
            cmb_horaTer.Items.Add("01:00");
            cmb_horaTer.Items.Add("01:30");
            cmb_horaTer.Items.Add("02:00");
            cmb_horaTer.Items.Add("02:30");
            cmb_horaTer.Items.Add("03:00");
            cmb_horaTer.Items.Add("03:30");
            cmb_horaTer.Items.Add("04:00");
            cmb_horaTer.Items.Add("04:30");
            cmb_horaTer.Items.Add("05:00");
            cmb_horaTer.Items.Add("05:30");
            cmb_horaTer.Items.Add("06:00");
            cmb_horaTer.Items.Add("06:30");
            cmb_horaTer.Items.Add("07:00");
            cmb_horaTer.Items.Add("07:30");
            cmb_horaTer.Items.Add("08:00");
            cmb_horaTer.Items.Add("08:30");
            cmb_horaTer.Items.Add("09:00");
            cmb_horaTer.Items.Add("09:30");
            cmb_horaTer.Items.Add("10:00");
            cmb_horaTer.Items.Add("10:30");
            cmb_horaTer.Items.Add("11:00");
            cmb_horaTer.Items.Add("11:30");
            cmb_horaTer.Items.Add("12:00");
            cmb_horaTer.Items.Add("12:30");
            cmb_horaTer.Items.Add("13:00");
            cmb_horaTer.Items.Add("13:30");
            cmb_horaTer.Items.Add("14:00");
            cmb_horaTer.Items.Add("14:30");
            cmb_horaTer.Items.Add("15:00");
            cmb_horaTer.Items.Add("15:30");
            cmb_horaTer.Items.Add("16:00");
            cmb_horaTer.Items.Add("16:30");
            cmb_horaTer.Items.Add("17:00");
            cmb_horaTer.Items.Add("17:30");
            cmb_horaTer.Items.Add("18:00");
            cmb_horaTer.Items.Add("18:30");
            cmb_horaTer.Items.Add("19:00");
            cmb_horaTer.Items.Add("19:30");
            cmb_horaTer.Items.Add("20:00");
            cmb_horaTer.Items.Add("20:30");
            cmb_horaTer.Items.Add("21:00");
            cmb_horaTer.Items.Add("21:30");
            cmb_horaTer.Items.Add("22:00");
            cmb_horaTer.Items.Add("22:30");
            cmb_horaTer.Items.Add("23:00");
            cmb_horaTer.Items.Add("23:30");

            cmb_horaIni.SelectedIndex = 0;
            cmb_horaTer.SelectedIndex = 0;

            DateTime year = new DateTime();
            year = DateTime.Now;
            int y = year.Year;
            dtp_fechaIni.DisplayDateStart = new DateTime(y, 1, 1);
            dtp_fechaIni.DisplayDateEnd = new DateTime(y, 12, 31);
            dtp_fechaIni.FirstDayOfWeek = DayOfWeek.Monday;
            dtp_fechaIni.BlackoutDates.AddDatesInPast();
            dtp_fechaTer.DisplayDateStart = new DateTime(y, 1, 1);
            dtp_fechaTer.DisplayDateEnd = new DateTime(y, 12, 31);
            dtp_fechaTer.FirstDayOfWeek = DayOfWeek.Monday;
            dtp_fechaTer.BlackoutDates.AddDatesInPast();
        }

        private void btn_buscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClMantencion clm = new ClMantencion();
                Departamento de = (Departamento)cmb_depto.SelectedValue;
                clm.DepartamentoId = de.ID;
                dt_lista.ItemsSource = clm.Busqueda();
            }
            catch (ArgumentException ex)
            {
                ClLoggerErrores.Mensaje(ex.ToString());
                throw;
            }
        }

        private void dt_lista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (dt_lista.SelectedIndex != -1)
                {
                    txt_idMantencion.Clear();
                    txt_recinto.Clear();
                    txt_depto.Clear();
                    txt_producto.Clear();
                    txt_descripcion.Clear();
                    txt_total.Clear();
                    txt_fechaIni.Clear();
                    txt_fechaIniOld.Clear();
                    txt_fechaTer.Clear();
                    txt_fechaTer.Clear();

                    DataGrid d = sender as DataGrid;
                    DataGridRow r = (DataGridRow)d.ItemContainerGenerator.ContainerFromIndex(d.SelectedIndex);
                    DataGridCell rc0 = d.Columns[0].GetCellContent(r).Parent as DataGridCell;
                    txt_idMantencion.Text = ((TextBlock)rc0.Content).Text;

                    DataGridCell rc1 = d.Columns[1].GetCellContent(r).Parent as DataGridCell;
                    txt_recinto.Text = ((TextBlock)rc1.Content).Text;

                    DataGridCell rc2 = d.Columns[2].GetCellContent(r).Parent as DataGridCell;
                    txt_depto.Text = ((TextBlock)rc2.Content).Text;
                    
                    DataGridCell rc3 = d.Columns[3].GetCellContent(r).Parent as DataGridCell;
                    txt_producto.Text = ((TextBlock)rc3.Content).Text;

                    DataGridCell rc4 = d.Columns[4].GetCellContent(r).Parent as DataGridCell;
                    txt_descripcion.Text = ((TextBlock)rc4.Content).Text;

                    DataGridCell rc5 = d.Columns[5].GetCellContent(r).Parent as DataGridCell;
                    txt_total.Text = ((TextBlock)rc5.Content).Text;

                    DataGridCell rc6 = d.Columns[6].GetCellContent(r).Parent as DataGridCell;
                    txt_fechaIni.Text = ((TextBlock)rc6.Content).Text;
                    txt_fechaIniOld.Text = ((TextBlock)rc6.Content).Text;
                    dtp_fechaIni.Text = ((TextBlock)rc6.Content).Text;

                    DataGridCell rc7 = d.Columns[7].GetCellContent(r).Parent as DataGridCell;
                    txt_fechaTer.Text = ((TextBlock)rc7.Content).Text;
                    txt_fechaTer.Text = ((TextBlock)rc7.Content).Text;
                    dtp_fechaTer.Text = ((TextBlock)rc7.Content).Text;
                }
            }
            catch (ArgumentException ex)
            {
                ClLoggerErrores.Mensaje(ex.ToString());
                throw;
            }
        }

        private void dtp_fechaIni_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            string dIni = dtp_fechaIni.SelectedDate.Value.ToString("dd/MM/yyyy");
            string tIni = cmb_horaIni.SelectedItem.ToString();
            DateTime fIni = DateTime.Parse(dIni + " " + tIni);
            txt_fechaIni.Text = fIni.ToString("dd/MM/yyyy HH:mm");

        }

        private void dtp_fechaTer_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            string dTer = dtp_fechaTer.SelectedDate.Value.ToString("dd/MM/yyyy");
            string tTer = cmb_horaTer.SelectedItem.ToString();
            DateTime fTer = DateTime.Parse(dTer + " " + tTer);
            txt_fechaTer.Text = fTer.ToString("dd/MM/yyyy HH:mm");

        }

        private void cmb_horaIni_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dtp_fechaIni.Text != "")
            {
                string dIni = dtp_fechaIni.SelectedDate.Value.ToString("dd/MM/yyyy");
                string tIni = cmb_horaIni.SelectedItem.ToString();
                DateTime fIni = DateTime.Parse(dIni + " " + tIni);
                txt_fechaIni.Text = fIni.ToString("dd/MM/yyyy HH:mm");
            }
        }

        private void cmb_horaTer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dtp_fechaTer.Text != "")
            {
                string dTer = dtp_fechaTer.SelectedDate.Value.ToString("dd/MM/yyyy");
                string tTer = cmb_horaTer.SelectedItem.ToString();
                DateTime fTer = DateTime.Parse(dTer + " " + tTer);
                txt_fechaTer.Text = fTer.ToString("dd/MM/yyyy HH:mm");
            }
        }

        private void btn_modificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txt_idMantencion.Text == "")
                {
                    DialogResult resultado = MessageBox.Show("Debe seleccionar una mantención de la lista",
                    "Mensaje Importante",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                }
                else
                {
                    if (txt_descripcion.Text == "" || txt_total.Text == "" || txt_fechaIni.Text == "" || txt_fechaTer.Text == "")
                    {
                        DialogResult resultado = MessageBox.Show("Debe completar todos los campos como la Descripción, Precio, Fecha de Inicio y la Fecha de Término",
                        "Mensaje Importante",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    }
                    else
                    {
                        ClMantencion clm = new ClMantencion();
                        clm.Id = int.Parse(txt_idMantencion.Text);
                        clm.Descripcion = txt_descripcion.Text;
                        clm.Total = int.Parse(txt_total.Text);
                        clm.FechaInicio = DateTime.Parse(txt_fechaIni.Text);
                        clm.FechaTermino = DateTime.Parse(txt_fechaTer.Text);
                        if (txt_producto.Text != "")
                        {
                            DialogResult resultado = MessageBox.Show("¿Está seguro que desea modificar la mantención del producto " + txt_producto.Text + " ubicado en el departamento " + txt_depto.Text + " del recinto " + txt_recinto.Text + "?",
                            "Mensaje Importante",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Exclamation);
                            if (resultado == System.Windows.Forms.DialogResult.Yes)
                            {
                                var r = clm.Modificar();
                                if (r)
                                {
                                    MessageBox.Show("Mantención Modificada correctamente", "Mensaje Importante",
                                    MessageBoxButtons.OK);
                                    txt_descripcion.Clear();
                                    txt_total.Clear();
                                    txt_fechaIni.Clear();
                                    txt_fechaIniOld.Clear();
                                    txt_fechaTer.Clear();
                                    txt_fechaTerOld.Clear();
                                    txt_idMantencion.Clear();
                                    txt_recinto.Clear();
                                    txt_depto.Clear();
                                    txt_producto.Clear();
                                    dt_lista.Items.Refresh();
                                    Departamento de = (Departamento)cmb_depto.SelectedValue;
                                    clm.DepartamentoId = de.ID;
                                    dt_lista.ItemsSource = clm.Busqueda();
                                }
                                else
                                {
                                    MessageBox.Show("No se pudo Modificar esta mantención", "Mensaje Importante",
                                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                }
                            }
                        }
                        else
                        {
                            DialogResult resultado = MessageBox.Show("¿Está seguro que desea modificar la mantención del departamento " + txt_depto.Text + " ubicado en el recinto " + txt_recinto.Text + "?",
                            "Mensaje Importante",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Exclamation);
                            if (resultado == System.Windows.Forms.DialogResult.Yes)
                            {
                                var r = clm.Modificar();
                                if (r)
                                {
                                    MessageBox.Show("Mantención Modificada correctamente", "Mensaje Importante",
                                    MessageBoxButtons.OK);
                                    txt_descripcion.Clear();
                                    txt_total.Clear();
                                    txt_fechaIni.Clear();
                                    txt_fechaIniOld.Clear();
                                    txt_fechaTer.Clear();
                                    txt_fechaTerOld.Clear();
                                    txt_idMantencion.Clear();
                                    txt_recinto.Clear();
                                    txt_depto.Clear();
                                    txt_producto.Clear();
                                    dt_lista.Items.Refresh();
                                    Departamento de = (Departamento)cmb_depto.SelectedValue;
                                    clm.DepartamentoId = de.ID;
                                    dt_lista.ItemsSource = clm.Busqueda();
                                    dt_lista.Items.Refresh();

                                }
                                else
                                {
                                    MessageBox.Show("No se pudo Modificar esta mantención", "Mensaje Importante",
                                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                }
                            }
                        }
                    }
                }
            }
            catch (ArgumentException ex)
            {
                ClLoggerErrores.Mensaje(ex.ToString());
                MessageBox.Show("Error: " + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_eliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txt_idMantencion.Text == "")
                {
                    DialogResult resultado = MessageBox.Show("Debe seleccionar una mantención de la lista",
                    "Mensaje Importante",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                }
                else
                {
                    ClMantencion clm = new ClMantencion();
                    clm.Id = int.Parse(txt_idMantencion.Text);
                    if (txt_producto.Text != "")
                    {
                        DialogResult resultado = MessageBox.Show("¿Está seguro que desea eliminar la mantención del producto " + txt_producto.Text + " ubicado en el departamento " + txt_depto.Text + " del recinto " + txt_recinto.Text + "?",
                        "Mensaje Importante", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                        if (resultado == System.Windows.Forms.DialogResult.Yes)
                        {
                            var r = clm.Eliminar();
                            if (r)
                            {
                                MessageBox.Show("Mantención Eliminada correctamente", "Mensaje Importante",
                                MessageBoxButtons.OK);
                                txt_descripcion.Clear();
                                txt_total.Clear();
                                txt_fechaIni.Clear();
                                txt_fechaIniOld.Clear();
                                txt_fechaTer.Clear();
                                txt_fechaTerOld.Clear();
                                txt_idMantencion.Clear();
                                txt_recinto.Clear();
                                txt_depto.Clear();
                                txt_producto.Clear();
                                dt_lista.Items.Refresh();
                                Departamento de = (Departamento)cmb_depto.SelectedValue;
                                clm.DepartamentoId = de.ID;
                                dt_lista.ItemsSource = clm.Busqueda();
                                dt_lista.Items.Refresh();

                            }
                            else
                            {
                                MessageBox.Show("No se pudo Eliminar esta Mantención",
                                "Mensaje Importante", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            }
                        }
                    }
                    else
                    {
                        DialogResult resultado = MessageBox.Show("¿Está seguro que desea eliminar la mantención del departamento " + txt_depto.Text + " ubicado en el recinto " + txt_recinto.Text + "?",
                        "Mensaje Importante", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                        if (resultado == System.Windows.Forms.DialogResult.Yes)
                        {
                            var r = clm.Eliminar();
                            if (r)
                            {
                                MessageBox.Show("Mantención Eliminada correctamente", "Mensaje Importante",
                                MessageBoxButtons.OK);
                                txt_descripcion.Clear();
                                txt_total.Clear();
                                txt_fechaIni.Clear();
                                txt_fechaIniOld.Clear();
                                txt_fechaTer.Clear();
                                txt_fechaTerOld.Clear();
                                txt_idMantencion.Clear();
                                txt_recinto.Clear();
                                txt_depto.Clear();
                                txt_producto.Clear();
                                dt_lista.Items.Refresh();
                                Departamento de = (Departamento)cmb_depto.SelectedValue;
                                clm.DepartamentoId = de.ID;
                                dt_lista.ItemsSource = clm.Busqueda();
                                dt_lista.Items.Refresh();

                            }
                            else
                            {
                                MessageBox.Show("No se pudo Eliminar esta Mantención",
                                "Mensaje Importante", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            }
                        }
                    }
                }
                
            }
            catch (ArgumentException ex)
            {
                ClLoggerErrores.Mensaje(ex.ToString());
                MessageBox.Show("Error: " + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    ClMantencion clm = new ClMantencion();
                    clm.CDeptoB(cmb_depto, p);
                    cmb_depto.SelectedIndex = 0;
                }
            }
            catch (ArgumentException ex)
            {
                ClLoggerErrores.Mensaje(ex.ToString());
                throw;
            }
        }

        
    }
}
