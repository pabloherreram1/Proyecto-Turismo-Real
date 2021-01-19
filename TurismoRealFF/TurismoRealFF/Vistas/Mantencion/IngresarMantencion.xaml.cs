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
using MessageBox = System.Windows.Forms.MessageBox;

namespace TurismoRealFF.Vistas.Mantencion
{
    /// <summary>
    /// Lógica de interacción para IngresarMantencion.xaml
    /// </summary>
    public partial class IngresarMantencion : Window
    {

        public static IngresarMantencion ventana;
        public static IngresarMantencion getIntance(string fi, string ft)
        {
            if (ventana == null)
            {
                ventana = new IngresarMantencion(fi,ft);
            }
            return ventana;
        }
        public IngresarMantencion()
        {
            InitializeComponent();
            CargarDatos();
        }

        public IngresarMantencion(string fi, string ft)
        {

            InitializeComponent();
            txt_fechaIni.Text = fi;
            txt_fechaTer.Text = ft;

            NotificationCenter.Subscribe("Hecho", CargarDatos);
        }

        public void CargarDatos()
        {
            Dispatcher.Invoke( () => {
                ClMantencion clm = new ClMantencion();
                clm.CRecinto(cmb_recinto);
                cmb_recinto.SelectedIndex = 0;

            });
            
        }

        private void RegistrarMantencion_Loaded(object sender, RoutedEventArgs e)
        {
            ClMantencion clm = new ClMantencion();
            clm.CRecinto(cmb_recinto);
            cmb_recinto.SelectedIndex = 0;
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
            catch (Exception)
            {

                throw;
            }
        }

        private void cmb_depto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cmb_depto.SelectedValue != null)
                {
                    Departamento d = (Departamento)cmb_depto.SelectedValue;


                    if (cmb_depto.SelectedIndex.ToString() != null)
                    {
                        int c = d.ID;
                        ClMantencion clm = new ClMantencion();
                        clm.CProductoB(cmb_producto, c);
                        cmb_producto.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btn_disponibilidad_Click(object sender, RoutedEventArgs e)
        {
            NotificationCenter.Notify("diponibilidad");
            var depto = (Departamento)cmb_depto.SelectedValue;
            Disponibilidad.getIntance(depto.ID).Show();
            Disponibilidad.getIntance(depto.ID).Activate();
            Hide();
            Close();
        }

        private void btn_registrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txt_descripcion.Text == "" | txt_fechaIni.Text == "" | txt_fechaTer.Text == "" | txt_total.Text == "")
                {
                    DialogResult resultado = MessageBox.Show("Debe completar todos los campos",
                    "Mensaje Importante",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                }
                else
                {

                    Departamento d = new Departamento();
                    ClMantencion man = new ClMantencion();
                    man.Descripcion = txt_descripcion.Text;
                    d = (Departamento)cmb_depto.SelectedValue;
                    man.DepartamentoId = d.ID;
                    if ((bool)ckb_producto.IsChecked)
                    {
                        Producto p = new Producto();
                        p = (Producto)cmb_producto.SelectedValue;
                        man.ProductoId = p.ID;
                    }
                    man.FechaInicio = DateTime.Parse(txt_fechaIni.Text);
                    man.FechaTermino = DateTime.Parse(txt_fechaTer.Text);
                    man.Total = int.Parse(txt_total.Text);

                    DialogResult resultado = MessageBox.Show("¿Está seguro que desea registrar esta mantención?",
                    "Mensaje Importante",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Exclamation);
                    if (resultado == System.Windows.Forms.DialogResult.Yes)
                    {
                        if ((bool)ckb_producto.IsChecked)
                        {
                            var r = man.RegistrarRDP();

                            if (r)
                            {
                                MessageBox.Show("Mantención agregado correctamente",
                                "Mensaje Importante",
                                MessageBoxButtons.OK);

                                MenuMantencion mm = new MenuMantencion();
                                Hide();
                                mm.ShowDialog();
                                Close();
                            }
                            else
                            {
                                MessageBox.Show("No se pudo Ingresar la mantención",
                                "Mensaje Importante",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Stop);
                            }
                        }
                        else
                        {
                            //if ((bool)ckb_recinto.IsChecked)
                            //{
                            //    var r2 = man.RegistrarR();

                            //    if (r2)
                            //    {
                            //        MessageBox.Show("Mantención agregado correctamente",
                            //        "Mensaje Importante",
                            //        MessageBoxButtons.OK);

                            //        MenuMantencion mm = new MenuMantencion();
                            //        Hide();
                            //        mm.ShowDialog();
                            //        Close();
                            //    }
                            //    else
                            //    {
                            //        MessageBox.Show("No se pudo Ingresar la mantención",
                            //        "Mensaje Importante",
                            //        MessageBoxButtons.OK,
                            //        MessageBoxIcon.Stop);
                            //    }
                            //}
                            //Else
                            //{
                            var r3 = man.RegistrarRD();

                            if (r3)
                            {
                                MessageBox.Show("Mantención agregado correctamente",
                                "Mensaje Importante",
                                MessageBoxButtons.OK);

                                MenuMantencion mm = new MenuMantencion();
                                Hide();
                                mm.ShowDialog();
                                Close();
                            }
                            else
                            {
                                MessageBox.Show("No se pudo Ingresar la mantención",
                                "Mensaje Importante",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Stop);
                            }
                            //}
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

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
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
            MenuMantencion man = new MenuMantencion();
            Hide();
            man.ShowDialog();
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
