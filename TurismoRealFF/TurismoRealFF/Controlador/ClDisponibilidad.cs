using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using TurismoRealFF.Modelo;
using TurismoRealFF.Vistas.Mantencion;

namespace TurismoRealFF.Controlador
{
    public class ClDisponibilidad
    {
        private readonly Disponibilidades d = new Disponibilidades();

        public int MantencionId { get; set; }
        public int ReservaId { get; set; }
        public DateTime FechaIniM { get; set; }
        public DateTime FechaTerM { get; set; }
        public DateTime FechaIniR { get; set; }
        public DateTime FechaTerR { get; set; }
        public int DepartamentoId { get; set; }


        public ArrayList Listar()
        {
            try
            {
                ArrayList lista = new ArrayList(d.ListarDisponibilidad(DepartamentoId));
                return lista;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public void AplicarBlackoutRangesReservaMantencion(Calendar reservas, Calendar mantencion, DatePicker fechaIni, DatePicker fechaTer)
        {
            try
            {
                var lista = Listar();
                if (lista != null)
                {
                    foreach (Disponibilidades item in lista)
                    {
                        if (item.FECHA_INI_R != null)
                        {
                            if (item.FECHA_INI_R != DateTime.Now)
                            {
                                try
                                {
                                    reservas.Dispatcher.Invoke(new Action(() => reservas.BlackoutDates.Add(new CalendarDateRange(item.FECHA_INI_R, item.FECHA_TER_R))), System.Windows.Threading.DispatcherPriority.Normal, null);
                                    fechaIni.Dispatcher.Invoke(new Action(() => fechaIni.BlackoutDates.Add(new CalendarDateRange(item.FECHA_INI_R, item.FECHA_TER_R))), System.Windows.Threading.DispatcherPriority.Normal, null);
                                    fechaTer.Dispatcher.Invoke(new Action(() => fechaTer.BlackoutDates.Add(new CalendarDateRange(item.FECHA_INI_R, item.FECHA_TER_R))), System.Windows.Threading.DispatcherPriority.Normal, null);
                                }
                                catch (ArgumentException ex)
                                {
                                    ClLoggerErrores.Mensaje(ex.ToString());
                                    MessageBox.Show("Error: " + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        if (item.FECHA_INI_M != null)
                        {
                            if (item.FECHA_INI_M != DateTime.Now)
                            {
                                try
                                {
                                    mantencion.Dispatcher.Invoke(new Action(() => mantencion.BlackoutDates.Add(new CalendarDateRange(item.FECHA_INI_M, item.FECHA_TER_M))), System.Windows.Threading.DispatcherPriority.Normal, null);
                                    fechaIni.Dispatcher.Invoke(new Action(() => fechaIni.BlackoutDates.Add(new CalendarDateRange(item.FECHA_INI_M, item.FECHA_TER_M))), System.Windows.Threading.DispatcherPriority.Normal, null);
                                    fechaTer.Dispatcher.Invoke(new Action(() => fechaTer.BlackoutDates.Add(new CalendarDateRange(item.FECHA_INI_M, item.FECHA_TER_M))), System.Windows.Threading.DispatcherPriority.Normal, null);
                                }
                                catch (ArgumentException ex)
                                {
                                    ClLoggerErrores.Mensaje(ex.ToString());
                                    MessageBox.Show("Error: " + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }

                    }
                }

            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
