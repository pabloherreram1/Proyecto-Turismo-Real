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


namespace TurismoRealFF.Vistas.Mantencion
{
    /// <summary>
    /// Lógica de interacción para Disponibilidad.xaml
    /// </summary>
    public partial class Disponibilidad : Window
    {
        //patron singleton
        public static Disponibilidad ventana;
        public static Disponibilidad getIntance(int iddepto)
        {
            if (ventana == null)
            {
                ventana = new Disponibilidad(iddepto);
            }
            return ventana;
        }
        //
        public Disponibilidad(int id)
        {
            InitializeComponent();
            txt_depto.Text = id.ToString();
            CargarVentana();

            NotificationCenter.Subscribe("diponibilidad",CargarVentana);


        }
        public Disponibilidad()
        {
            InitializeComponent();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            _ = Disponibilidad.ventana == null;
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
        public void CargarVentana()
        {
            
            Dispatcher.Invoke( () => {
                DateTime year = new DateTime();
                year = DateTime.Now;
                int y = year.Year;
                cld_fecha_reserva.DisplayDateStart = new DateTime(y, 1, 1);
                cld_fecha_reserva.DisplayDateEnd = new DateTime(y, 12, 31);
                cld_fecha_reserva.FirstDayOfWeek = DayOfWeek.Monday;
                cld_fecha_reserva.BlackoutDates.AddDatesInPast();
                cld_fecha_mantenciones.DisplayDateStart = new DateTime(y, 1, 1);
                cld_fecha_mantenciones.DisplayDateEnd = new DateTime(y, 12, 31);
                cld_fecha_mantenciones.FirstDayOfWeek = DayOfWeek.Monday;
                cld_fecha_mantenciones.BlackoutDates.AddDatesInPast();
                dtp_fechaIni.DisplayDateStart = new DateTime(y, 1, 1);
                dtp_fechaIni.DisplayDateEnd = new DateTime(y, 12, 31);
                dtp_fechaIni.FirstDayOfWeek = DayOfWeek.Monday;
                dtp_fechaIni.BlackoutDates.AddDatesInPast();
                dtp_fechaTer.DisplayDateStart = new DateTime(y, 1, 1);
                dtp_fechaTer.DisplayDateEnd = new DateTime(y, 12, 31);
                dtp_fechaTer.FirstDayOfWeek = DayOfWeek.Monday;
                dtp_fechaTer.BlackoutDates.AddDatesInPast();
                if (txt_depto.Text != "")
                {
                    ClDisponibilidad disp = new ClDisponibilidad();
                    disp.DepartamentoId = int.Parse(txt_depto.Text);
                    disp.AplicarBlackoutRangesReservaMantencion(cld_fecha_reserva, cld_fecha_mantenciones, dtp_fechaIni, dtp_fechaTer);

                }
                RellenarCombobox();
                cmb_horaIni.SelectedIndex = 0;
                cmb_horaTer.SelectedIndex = 0;

            }  );
        }

        //private void Disponibilidad1_Loaded(object sender, RoutedEventArgs e)
        //{

        //    DateTime year = new DateTime();
        //    year = DateTime.Now;
        //    int y = year.Year;
        //    cld_fecha_reserva.DisplayDateStart = new DateTime(y, 1, 1);
        //    cld_fecha_reserva.DisplayDateEnd = new DateTime(y, 12, 31);
        //    cld_fecha_reserva.FirstDayOfWeek = DayOfWeek.Monday;
        //    cld_fecha_reserva.BlackoutDates.AddDatesInPast();
        //    cld_fecha_mantenciones.DisplayDateStart = new DateTime(y, 1, 1);
        //    cld_fecha_mantenciones.DisplayDateEnd = new DateTime(y, 12, 31);
        //    cld_fecha_mantenciones.FirstDayOfWeek = DayOfWeek.Monday;
        //    cld_fecha_mantenciones.BlackoutDates.AddDatesInPast();
        //    dtp_fechaIni.DisplayDateStart = new DateTime(y, 1, 1);
        //    dtp_fechaIni.DisplayDateEnd = new DateTime(y, 12, 31);
        //    dtp_fechaIni.FirstDayOfWeek = DayOfWeek.Monday;
        //    dtp_fechaIni.BlackoutDates.AddDatesInPast();
        //    dtp_fechaTer.DisplayDateStart = new DateTime(y, 1, 1);
        //    dtp_fechaTer.DisplayDateEnd = new DateTime(y, 12, 31);
        //    dtp_fechaTer.FirstDayOfWeek = DayOfWeek.Monday;
        //    dtp_fechaTer.BlackoutDates.AddDatesInPast();
        //    if (txt_depto.Text != "")
        //    {
        //        ClDisponibilidad disp = new ClDisponibilidad();
        //        disp.DepartamentoId = int.Parse(txt_depto.Text);
        //        disp.AplicarBlackoutRangesReservaMantencion(cld_fecha_reserva, cld_fecha_mantenciones, dtp_fechaIni, dtp_fechaTer);

        //    }
        //    RellenarCombobox();
        //    cmb_horaIni.SelectedIndex = 0;
        //    cmb_horaTer.SelectedIndex = 0;
        //}

        public void RellenarCombobox()
        {
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
        }
        private void btn_registrar_Click(object sender, RoutedEventArgs e)
        {
            string dIni = dtp_fechaIni.SelectedDate.Value.ToString("dd/MM/yyyy");
            string tIni = cmb_horaIni.SelectedItem.ToString();
            DateTime fIni = DateTime.Parse(dIni + " " + tIni);

            string dTer = dtp_fechaTer.SelectedDate.Value.ToString("dd/MM/yyyy");
            string tTer = cmb_horaTer.SelectedItem.ToString();
            DateTime fTer = DateTime.Parse(dTer + " " + tTer);
            //ClaseCompartida.fechaInicio = fIni.ToString("dd/MM/yyyy HH:mm");
            //ClaseCompartida.fechaTermino = fTer.ToString("dd/MM/yyyy HH:mm");
            IngresarMantencion.getIntance(fIni.ToString("dd/MM/yyyy HH:mm"), fTer.ToString("dd/MM/yyyy HH:mm")).Show();
            NotificationCenter.Notify("Hecho");

            Hide();
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
