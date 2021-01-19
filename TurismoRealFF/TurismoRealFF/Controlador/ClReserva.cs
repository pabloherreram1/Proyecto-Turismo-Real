using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TurismoRealFF.Modelo;
using Application = System.Windows.Forms.Application;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Kernel.Geom;
using iText.Layout.Element;
using Paragraph = iText.Layout.Element.Paragraph;
using Table = iText.Layout.Element.Table;
using iText.Layout.Borders;
using Border = iText.Layout.Borders.Border;
using iText.Kernel.Colors;
using TextAlignment = iText.Layout.Properties.TextAlignment;
using Style = iText.Layout.Style;
using TurismoRealFF.Controlador;
using TurismoRealFF.Modelo;
using System.Collections;
using iText.Kernel.Events;
using Image = iText.Layout.Element.Image;
using iText.IO.Image;
using Rectangle = iText.Kernel.Geom.Rectangle;
using Canvas = iText.Layout.Canvas;
using iText.Layout.Properties;
using iText.Kernel.Font;
using iText.IO.Font.Constants;
using iText.Kernel.Pdf.Canvas;
using MessageBox = System.Windows.Forms.MessageBox;

using ComboBox = System.Windows.Controls.ComboBox;
using CheckBox = System.Windows.Controls.CheckBox;

namespace TurismoRealFF.Controlador
{
    public class ClReserva
    {
        readonly Reserva r = new Reserva();
        public int Mes { get; set; }
        public int Dia { get; set; }
        public int Depto { get; set; }
        public DateTime fini { get; set; }
        public DateTime fter{ get; set; }
        public ArrayList ListaTuD()
        {
            ArrayList lista = new ArrayList(r.BusquedaTuD(Depto,Mes, Dia,fini,fter));
            return lista;
        }
        public ArrayList ListaTuM()
        {
            ArrayList lista = new ArrayList(r.BusquedaTuM(Depto, Mes, fini, fter));
            return lista;
        }
        public ArrayList ListaTrD()
        {
            ArrayList lista = new ArrayList(r.BusquedaTrD(Depto, Mes, Dia, fini, fter));
            return lista;
        }
        public ArrayList ListaTrM()
        {
            ArrayList lista = new ArrayList(r.BusquedaTrM(Depto, Mes, fini, fter));
            return lista;
        }
        public ArrayList ListaSED()
        {
            ArrayList lista = new ArrayList(r.BusquedaSED(Depto, Mes, Dia, fini, fter));
            return lista;
        }
        public ArrayList ListaSEM()
        {
            ArrayList lista = new ArrayList(r.BusquedaSEM(Depto, Mes, fini, fter));
            return lista;
        }
        public ArrayList ListaRD()
        {
            ArrayList lista = new ArrayList(r.BusquedaRD(Depto, Mes, Dia));
            return lista;
        }
        public ArrayList ListaRM()
        {
            ArrayList lista = new ArrayList(r.BusquedaRM(Depto, Mes));
            return lista;
        }
        public ArrayList ListaTD()
        {
            ArrayList lista = new ArrayList(r.BusquedaTD(Depto, Mes, Dia, fini, fter));
            return lista;
        }
        public ArrayList ListaTM()
        {
            ArrayList lista = new ArrayList(r.BusquedaTM(Depto, Mes, fini, fter));
            return lista;
        }

        public ArrayList ListaTodoA(int depto,int anio, DateTime finic, DateTime fterm )
        {
            List<Reserva> re = r.BusquedaTA(depto, anio, finic, fterm);
            int res = 0;
            ArrayList reserv = new ArrayList();
            foreach (var ite in re)
            {
                if (ite.ID != res)
                {
                    res = ite.ID;
                    int idre = r.BusquedaReservaPrecioAcomp(res);
                    Reserva lala = new Reserva();
                    lala.ID = res;
                    lala.PRECIO = idre;
                    lala.FECHA_INICIO = ite.FECHA_INICIO;
                    lala.FECHA_TERMINO = ite.FECHA_TERMINO;
                    lala.TIPO = "RESERVA";
                    reserv.Add(lala);
                    reserv.Add(ite);
                }
                else
                {
                    reserv.Add(ite);
                }
            }
            return reserv;
        }
        public ArrayList ListaTodoM(int depto, int mes, DateTime finic, DateTime fterm)
        {
            List<Reserva> re = r.BusquedaTM(depto, mes, finic, fterm);
            int res = 0;
            ArrayList reserv = new ArrayList();
            foreach (var ite in re)
            {
                if (ite.ID != res)
                {
                    res = ite.ID;
                    int idre = r.BusquedaReservaPrecioAcomp(res);
                    Reserva lala = new Reserva();
                    lala.ID = res;
                    lala.PRECIO = idre;
                    lala.FECHA_INICIO = ite.FECHA_INICIO;
                    lala.FECHA_TERMINO = ite.FECHA_TERMINO;
                    lala.TIPO = "RESERVA";
                    reserv.Add(lala);
                    reserv.Add(ite);
                }
                else
                {
                    reserv.Add(ite);
                }
            }
            return reserv;
        }
        public ArrayList ListaTodoD(int depto, int mes, int dia, DateTime finic, DateTime fterm)
        {
            List<Reserva> re = r.BusquedaTD(depto, mes, dia, finic, fterm);
            int res = 0;
            ArrayList reserv = new ArrayList();
            foreach (var ite in re)
            {
                if (ite.ID != res)
                {
                    res = ite.ID;
                    int idre = r.BusquedaReservaPrecioAcomp(res);
                    Reserva lala = new Reserva();
                    lala.ID = res;
                    lala.PRECIO = idre;
                    lala.FECHA_INICIO = ite.FECHA_INICIO;
                    lala.FECHA_TERMINO = ite.FECHA_TERMINO;
                    lala.TIPO = "RESERVA";
                    reserv.Add(lala);
                    reserv.Add(ite);
                }
                else
                {
                    reserv.Add(ite);
                }
            }
            return reserv;
        }

        public void CRecinto(ComboBox cb)
        {
            try
            {
                Recinto r = new Recinto();
                ArrayList Recinto = new ArrayList(r.ListarRecinto());
                cb.Items.Clear();

                for (int i = 0; i < Recinto.Count; i++)
                {
                    cb.Items.Add(Recinto.ToArray()[i]);
                }

                cb.SelectedItem = "ID";
                cb.DisplayMemberPath = "NOMBRE";


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }

        public void CDeptoB(ComboBox cb, int idrecinto)
        {
            try
            {
                Departamento d = new Departamento();
                ArrayList Depto = new ArrayList(d.ListarDeptoBuscada(idrecinto));
                cb.Items.Clear();

                for (int i = 0; i < Depto.Count; i++)
                {
                    cb.Items.Add(Depto.ToArray()[i]);
                }

                cb.SelectedItem = "ID";
                cb.DisplayMemberPath = "NOMBRE";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }

        }

        public bool CrearPDF(ComboBox cmb_tipo, ComboBox cmb_mes, ComboBox cmb_dia, ComboBox cmb_recinto, ComboBox cmb_depto,CheckBox ckb_mes, CheckBox ckb_dia, CheckBox ckb_depto)
        {
            try
            {
                string paths = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                string fecha = DateTime.Now.ToString("dd-MM-yyyy");
                string hora = DateTime.Now.ToString("HH");
                string minuto = DateTime.Now.ToString("mm");
                string segundo = DateTime.Now.ToString("ss");
                PdfWriter pw = new PdfWriter(paths + "\\Reportes/Reporte Reserva/Reporte_Reserva_" + fecha + "_" + hora + "." + minuto + "." + segundo + ".pdf");
                PdfDocument pdfDocument = new PdfDocument(pw);
                Document doc = new Document(pdfDocument, PageSize.A4);
                doc.SetMargins(75, 35, 70, 35);

                string pathLogo = paths + "\\Imagenes/turismo.png";
                Image img = new Image(ImageDataFactory.Create(pathLogo));
                pdfDocument.AddEventHandler(PdfDocumentEvent.START_PAGE, new HeaderEventHandler(img));
                pdfDocument.AddEventHandler(PdfDocumentEvent.END_PAGE, new FooterEventHandler());


                Table table = new Table(1).UseAllAvailableWidth();
                Cell cell = new Cell().Add(new Paragraph("Reporte de Reservas"))
                                        .SetFontSize(24)
                                        .SetTextAlignment(TextAlignment.CENTER)
                                        .SetBorder(Border.NO_BORDER);
                table.AddCell(cell);


                Recinto rec = (Recinto)cmb_recinto.SelectedItem;

                cell = new Cell().Add(new Paragraph("Reservas de Turismo Real"))
                                 .SetTextAlignment(TextAlignment.CENTER)
                                 .SetBorder(Border.NO_BORDER);
                table.AddCell(cell);

                cell = new Cell().Add(new Paragraph("Recinto " + rec.NOMBRE))
                                 .SetTextAlignment(TextAlignment.CENTER)
                                 .SetBorder(Border.NO_BORDER);
                table.AddCell(cell);
                doc.Add(table);
                table.SetMarginBottom(10f);

                Style stileCell = new Style()
                    .SetBackgroundColor(ColorConstants.LIGHT_GRAY)
                    .SetTextAlignment(TextAlignment.CENTER);
                Style stileCell2 = new Style()
                    .SetBackgroundColor(ColorConstants.BLUE)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetFontColor(ColorConstants.WHITE);
                Style style_cellReserva = new Style()
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetBackgroundColor(ColorConstants.YELLOW)
                    .SetFontSize(12);
                Style style_cellTour = new Style()
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetBackgroundColor(ColorConstants.GREEN)
                    .SetFontSize(12);
                Style style_cellTransporte = new Style()
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetBackgroundColor(ColorConstants.ORANGE)
                    .SetFontSize(12);
                Style style_cellServicioExtra = new Style()
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetBackgroundColor(ColorConstants.CYAN)
                    .SetFontSize(12);
                Style style_cellTodo = new Style()
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetBackgroundColor(ColorConstants.CYAN)
                    .SetFontSize(12);

                Table _table = new Table(7).UseAllAvailableWidth();
                Cell _cell = new Cell(2, 1).Add(new Paragraph("#"));
                _table.AddCell(_cell.AddStyle(stileCell2));
                _cell = new Cell(1, 6).Add(new Paragraph("Reserva"));
                _table.AddCell(_cell.AddStyle(stileCell2));
                _cell = new Cell().Add(new Paragraph("Nombre Departamento"));
                _table.AddCell(_cell.AddStyle(stileCell));
                _cell = new Cell().Add(new Paragraph("Id Reserva"));
                _table.AddCell(_cell.AddStyle(stileCell));
                _cell = new Cell().Add(new Paragraph("Fecha Inicio"));
                _table.AddCell(_cell.AddStyle(stileCell));
                _cell = new Cell().Add(new Paragraph("Fecha Termino"));
                _table.AddCell(_cell.AddStyle(stileCell));
                _cell = new Cell().Add(new Paragraph("Tipo"));
                _table.AddCell(_cell.AddStyle(stileCell));
                _cell = new Cell().Add(new Paragraph("Precio"));
                _table.AddCell(_cell.AddStyle(stileCell));

                int NR = 0;
                int TR = 0;
                int NTu = 0;
                int TTu = 0;
                int NTr = 0;
                int TTr = 0;
                int NSE = 0;
                int TSE = 0;
                int ST = 0;


                if (ckb_depto.IsChecked == false)
                {
                    int x = 0;
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
                                    List<Reserva> re = r.BusquedaRA(deptos.ID, anio);
                                    foreach (var item in re)
                                    {
                                        x++;
                                        _cell = new Cell().Add(new Paragraph(x.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                        _table.AddCell(_cell);
                                        _cell = new Cell().Add(new Paragraph(deptos.NOMBRE)).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                        _table.AddCell(_cell);
                                        _cell = new Cell().Add(new Paragraph(item.ID.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                        _table.AddCell(_cell);
                                        _cell = new Cell().Add(new Paragraph(item.FECHA_INICIO.ToString("dd-MM-yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                        _table.AddCell(_cell);
                                        _cell = new Cell().Add(new Paragraph(item.FECHA_TERMINO.ToString("dd-MM-yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                        _table.AddCell(_cell);
                                        _cell = new Cell().Add(new Paragraph(item.TIPO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                        _table.AddCell(_cell.AddStyle(style_cellReserva));
                                        _cell = new Cell().Add(new Paragraph("$ " + item.PRECIO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                        _table.AddCell(_cell);

                                        NR += 1;
                                        TR += item.PRECIO;
                                        ST += item.PRECIO;

                                    }
                                    doc.Add(_table);
                                }
                                else
                                {
                                    if (ckb_dia.IsChecked == false)
                                    {
                                        int mes = cmb_mes.SelectedIndex + 1;
                                        List<Reserva> re = r.BusquedaRM(deptos.ID, mes);

                                        foreach (var item in re)
                                        {
                                            x++;
                                            _cell = new Cell().Add(new Paragraph(x.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                            _table.AddCell(_cell);
                                            _cell = new Cell().Add(new Paragraph(deptos.NOMBRE)).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                            _table.AddCell(_cell);
                                            _cell = new Cell().Add(new Paragraph(item.ID.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                            _table.AddCell(_cell);
                                            _cell = new Cell().Add(new Paragraph(item.FECHA_INICIO.ToString("dd-MM-yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                            _table.AddCell(_cell);
                                            _cell = new Cell().Add(new Paragraph(item.FECHA_TERMINO.ToString("dd-MM-yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                            _table.AddCell(_cell);
                                            _cell = new Cell().Add(new Paragraph(item.TIPO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                            _table.AddCell(_cell.AddStyle(style_cellReserva));
                                            _cell = new Cell().Add(new Paragraph("$ " + item.PRECIO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                            _table.AddCell(_cell);


                                            NR += 1;
                                            TR += item.PRECIO;
                                            ST += item.PRECIO;
                                        }
                                        doc.Add(_table);
                                    }
                                    else
                                    {
                                        int mes = cmb_mes.SelectedIndex + 1;
                                        int dia = cmb_dia.SelectedIndex + 1;
                                        List<Reserva> re = r.BusquedaRD(deptos.ID, mes, dia);

                                        foreach (var item in re)
                                        {
                                            x++;
                                            _cell = new Cell().Add(new Paragraph(x.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                            _table.AddCell(_cell);
                                            _cell = new Cell().Add(new Paragraph(deptos.NOMBRE)).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                            _table.AddCell(_cell);
                                            _cell = new Cell().Add(new Paragraph(item.ID.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                            _table.AddCell(_cell);
                                            _cell = new Cell().Add(new Paragraph(item.FECHA_INICIO.ToString("dd-MM-yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                            _table.AddCell(_cell);
                                            _cell = new Cell().Add(new Paragraph(item.FECHA_TERMINO.ToString("dd-MM-yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                            _table.AddCell(_cell);
                                            _cell = new Cell().Add(new Paragraph(item.TIPO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                            _table.AddCell(_cell.AddStyle(style_cellReserva));
                                            _cell = new Cell().Add(new Paragraph("$ " + item.PRECIO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                            _table.AddCell(_cell);


                                            NR += 1;
                                            TR += item.PRECIO;
                                            ST += item.PRECIO;
                                        }
                                        doc.Add(_table);
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
                                        List<Reserva> re = r.BusquedaTuA(deptos.ID, anio, reser.FECHA_INICIO,reser.FECHA_TERMINO);
                                        foreach (var item in re)
                                        {
                                            x++;
                                            _cell = new Cell().Add(new Paragraph(x.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                            _table.AddCell(_cell);
                                            _cell = new Cell().Add(new Paragraph(deptos.NOMBRE)).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                            _table.AddCell(_cell);
                                            _cell = new Cell().Add(new Paragraph(item.ID.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                            _table.AddCell(_cell);
                                            _cell = new Cell().Add(new Paragraph(item.FECHA_INICIO.ToString("dd-MM-yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                            _table.AddCell(_cell);
                                            _cell = new Cell().Add(new Paragraph(item.FECHA_TERMINO.ToString("dd-MM-yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                            _table.AddCell(_cell);
                                            _cell = new Cell().Add(new Paragraph(item.TIPO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                            _table.AddCell(_cell.AddStyle(style_cellTour));
                                            _cell = new Cell().Add(new Paragraph("$ " + item.PRECIO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                            _table.AddCell(_cell);


                                            NTu += 1;
                                            TTu += item.PRECIO;
                                            ST += item.PRECIO;
                                        }
                                        doc.Add(_table);
                                    }
                                    else
                                    {
                                        if (ckb_dia.IsChecked == false)
                                        {
                                            int mes = cmb_mes.SelectedIndex + 1;
                                            List<Reserva> re = r.BusquedaTuM(deptos.ID, mes, reser.FECHA_INICIO, reser.FECHA_TERMINO);

                                            foreach (var item in re)
                                            {
                                                x++;
                                                _cell = new Cell().Add(new Paragraph(x.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                _table.AddCell(_cell);
                                                _cell = new Cell().Add(new Paragraph(deptos.NOMBRE)).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                _table.AddCell(_cell);
                                                _cell = new Cell().Add(new Paragraph(item.ID.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                _table.AddCell(_cell);
                                                _cell = new Cell().Add(new Paragraph(item.FECHA_INICIO.ToString("dd-MM-yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                _table.AddCell(_cell);
                                                _cell = new Cell().Add(new Paragraph(item.FECHA_TERMINO.ToString("dd-MM-yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                _table.AddCell(_cell);
                                                _cell = new Cell().Add(new Paragraph(item.TIPO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                _table.AddCell(_cell.AddStyle(style_cellTour));
                                                _cell = new Cell().Add(new Paragraph("$ " + item.PRECIO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                _table.AddCell(_cell);

                                                NTu += 1;
                                                TTu += item.PRECIO;
                                                ST += item.PRECIO;
                                            }
                                            doc.Add(_table);
                                        }
                                        else
                                        {
                                            int mes = cmb_mes.SelectedIndex + 1;
                                            int dia = cmb_dia.SelectedIndex + 1;
                                            List<Reserva> re = r.BusquedaTuD(deptos.ID, mes, dia, reser.FECHA_INICIO, reser.FECHA_TERMINO);

                                            foreach (var item in re)
                                            {
                                                x++;
                                                _cell = new Cell().Add(new Paragraph(x.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                _table.AddCell(_cell);
                                                _cell = new Cell().Add(new Paragraph(deptos.NOMBRE)).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                _table.AddCell(_cell);
                                                _cell = new Cell().Add(new Paragraph(item.ID.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                _table.AddCell(_cell);
                                                _cell = new Cell().Add(new Paragraph(item.FECHA_INICIO.ToString("dd-MM-yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                _table.AddCell(_cell);
                                                _cell = new Cell().Add(new Paragraph(item.FECHA_TERMINO.ToString("dd-MM-yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                _table.AddCell(_cell);
                                                _cell = new Cell().Add(new Paragraph(item.TIPO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                _table.AddCell(_cell.AddStyle(style_cellTour));
                                                _cell = new Cell().Add(new Paragraph("$ " + item.PRECIO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                _table.AddCell(_cell);

                                                NTu += 1;
                                                TTu += item.PRECIO;
                                                ST += item.PRECIO;
                                            }
                                            doc.Add(_table);
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
                                            List<Reserva> re = r.BusquedaTrA(deptos.ID, anio, reser.FECHA_INICIO, reser.FECHA_TERMINO);
                                            foreach (var item in re)
                                            {
                                                x++;
                                                _cell = new Cell().Add(new Paragraph(x.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                _table.AddCell(_cell);
                                                _cell = new Cell().Add(new Paragraph(deptos.NOMBRE)).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                _table.AddCell(_cell);
                                                _cell = new Cell().Add(new Paragraph(item.ID.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                _table.AddCell(_cell);
                                                _cell = new Cell().Add(new Paragraph(item.FECHA_INICIO.ToString("dd-MM-yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                _table.AddCell(_cell);
                                                _cell = new Cell().Add(new Paragraph(item.FECHA_TERMINO.ToString("dd-MM-yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                _table.AddCell(_cell);
                                                _cell = new Cell().Add(new Paragraph(item.TIPO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                _table.AddCell(_cell.AddStyle(style_cellTransporte));
                                                _cell = new Cell().Add(new Paragraph("$ " + item.PRECIO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                _table.AddCell(_cell);

                                                NTr += 1;
                                                TTr += item.PRECIO;
                                                ST += item.PRECIO;
                                            }
                                            doc.Add(_table);
                                        }
                                        else
                                        {
                                            if (ckb_dia.IsChecked == false)
                                            {
                                                int mes = cmb_mes.SelectedIndex + 1;
                                                List<Reserva> re = r.BusquedaTrM(deptos.ID, mes, reser.FECHA_INICIO, reser.FECHA_TERMINO);

                                                foreach (var item in re)
                                                {
                                                    x++;
                                                    _cell = new Cell().Add(new Paragraph(x.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                    _table.AddCell(_cell);
                                                    _cell = new Cell().Add(new Paragraph(deptos.NOMBRE)).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                    _table.AddCell(_cell);
                                                    _cell = new Cell().Add(new Paragraph(item.ID.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                    _table.AddCell(_cell);
                                                    _cell = new Cell().Add(new Paragraph(item.FECHA_INICIO.ToString("dd-MM-yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                    _table.AddCell(_cell);
                                                    _cell = new Cell().Add(new Paragraph(item.FECHA_TERMINO.ToString("dd-MM-yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                    _table.AddCell(_cell);
                                                    _cell = new Cell().Add(new Paragraph(item.TIPO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                    _table.AddCell(_cell.AddStyle(style_cellTransporte));
                                                    _cell = new Cell().Add(new Paragraph("$ " + item.PRECIO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                    _table.AddCell(_cell);

                                                    NTr += 1;
                                                    TTr += item.PRECIO;
                                                    ST += item.PRECIO;
                                                }
                                                doc.Add(_table);
                                            }
                                            else
                                            {
                                                int mes = cmb_mes.SelectedIndex + 1;
                                                int dia = cmb_dia.SelectedIndex + 1;
                                                List<Reserva> re = r.BusquedaTrD(deptos.ID, mes, dia, reser.FECHA_INICIO, reser.FECHA_TERMINO);

                                                foreach (var item in re)
                                                {
                                                    x++;
                                                    _cell = new Cell().Add(new Paragraph(x.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                    _table.AddCell(_cell);
                                                    _cell = new Cell().Add(new Paragraph(deptos.NOMBRE)).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                    _table.AddCell(_cell);
                                                    _cell = new Cell().Add(new Paragraph(item.ID.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                    _table.AddCell(_cell);
                                                    _cell = new Cell().Add(new Paragraph(item.FECHA_INICIO.ToString("dd-MM-yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                    _table.AddCell(_cell);
                                                    _cell = new Cell().Add(new Paragraph(item.FECHA_TERMINO.ToString("dd-MM-yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                    _table.AddCell(_cell);
                                                    _cell = new Cell().Add(new Paragraph(item.TIPO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                    _table.AddCell(_cell.AddStyle(style_cellTransporte));
                                                    _cell = new Cell().Add(new Paragraph("$ " + item.PRECIO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                    _table.AddCell(_cell);

                                                    NTr += 1;
                                                    TTr += item.PRECIO;
                                                    ST += item.PRECIO;
                                                }
                                                doc.Add(_table);
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
                                                List<Reserva> re = r.BusquedaSEA(deptos.ID, anio, reser.FECHA_INICIO, reser.FECHA_TERMINO);
                                                foreach (var item in re)
                                                {
                                                    x++;
                                                    _cell = new Cell().Add(new Paragraph(x.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                    _table.AddCell(_cell);
                                                    _cell = new Cell().Add(new Paragraph(deptos.NOMBRE)).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                    _table.AddCell(_cell);
                                                    _cell = new Cell().Add(new Paragraph(item.ID.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                    _table.AddCell(_cell);
                                                    _cell = new Cell().Add(new Paragraph(item.FECHA_INICIO.ToString("dd-MM-yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                    _table.AddCell(_cell);
                                                    _cell = new Cell().Add(new Paragraph(item.FECHA_TERMINO.ToString("dd-MM-yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                    _table.AddCell(_cell);
                                                    _cell = new Cell().Add(new Paragraph(item.TIPO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                    _table.AddCell(_cell.AddStyle(style_cellServicioExtra));
                                                    _cell = new Cell().Add(new Paragraph("$ " + item.PRECIO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                    _table.AddCell(_cell);

                                                    NSE += 1;
                                                    TSE += item.PRECIO;
                                                    ST += item.PRECIO;
                                                }
                                                doc.Add(_table);
                                            }
                                            else
                                            {
                                                if (ckb_dia.IsChecked == false)
                                                {
                                                    int mes = cmb_mes.SelectedIndex + 1;
                                                    List<Reserva> re = r.BusquedaSEM(deptos.ID, mes, reser.FECHA_INICIO, reser.FECHA_TERMINO);

                                                    foreach (var item in re)
                                                    {
                                                        x++;
                                                        _cell = new Cell().Add(new Paragraph(x.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                        _table.AddCell(_cell);
                                                        _cell = new Cell().Add(new Paragraph(deptos.NOMBRE)).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                        _table.AddCell(_cell);
                                                        _cell = new Cell().Add(new Paragraph(item.ID.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                        _table.AddCell(_cell);
                                                        _cell = new Cell().Add(new Paragraph(item.FECHA_INICIO.ToString("dd-MM-yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                        _table.AddCell(_cell);
                                                        _cell = new Cell().Add(new Paragraph(item.FECHA_TERMINO.ToString("dd-MM-yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                        _table.AddCell(_cell);
                                                        _cell = new Cell().Add(new Paragraph(item.TIPO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                        _table.AddCell(_cell.AddStyle(style_cellServicioExtra));
                                                        _cell = new Cell().Add(new Paragraph("$ " + item.PRECIO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                        _table.AddCell(_cell);

                                                        NSE += 1;
                                                        TSE += item.PRECIO;
                                                        ST += item.PRECIO;
                                                    }
                                                    doc.Add(_table);
                                                }
                                                else
                                                {
                                                    int mes = cmb_mes.SelectedIndex + 1;
                                                    int dia = cmb_dia.SelectedIndex + 1;
                                                    List<Reserva> re = r.BusquedaSED(deptos.ID, mes, dia, reser.FECHA_INICIO, reser.FECHA_TERMINO);

                                                    foreach (var item in re)
                                                    {
                                                        x++;
                                                        _cell = new Cell().Add(new Paragraph(x.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                        _table.AddCell(_cell);
                                                        _cell = new Cell().Add(new Paragraph(deptos.NOMBRE)).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                        _table.AddCell(_cell);
                                                        _cell = new Cell().Add(new Paragraph(item.ID.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                        _table.AddCell(_cell);
                                                        _cell = new Cell().Add(new Paragraph(item.FECHA_INICIO.ToString("dd-MM-yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                        _table.AddCell(_cell);
                                                        _cell = new Cell().Add(new Paragraph(item.FECHA_TERMINO.ToString("dd-MM-yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                        _table.AddCell(_cell);
                                                        _cell = new Cell().Add(new Paragraph(item.TIPO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                        _table.AddCell(_cell.AddStyle(style_cellServicioExtra));
                                                        _cell = new Cell().Add(new Paragraph("$ " + item.PRECIO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                        _table.AddCell(_cell);

                                                        NSE += 1;
                                                        TSE += item.PRECIO;
                                                        ST += item.PRECIO;
                                                    }
                                                    doc.Add(_table);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (ckb_mes.IsChecked == false)
                                            {
                                                int anio = int.Parse(DateTime.Now.ToString("yyyy"));
                                                List<Reserva> re = r.ListaTodA(deptos.ID, anio, reser.FECHA_INICIO, reser.FECHA_TERMINO);
                                                foreach (var item in re)
                                                {
                                                    x++;
                                                    _cell = new Cell().Add(new Paragraph(x.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                    _table.AddCell(_cell);
                                                    _cell = new Cell().Add(new Paragraph(deptos.NOMBRE)).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                    _table.AddCell(_cell);
                                                    _cell = new Cell().Add(new Paragraph(item.ID.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                    _table.AddCell(_cell);
                                                    _cell = new Cell().Add(new Paragraph(item.FECHA_INICIO.ToString("dd-MM-yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                    _table.AddCell(_cell);
                                                    _cell = new Cell().Add(new Paragraph(item.FECHA_TERMINO.ToString("dd-MM-yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                    _table.AddCell(_cell);

                                                    if (item.TIPO.ToString() == "RESERVA")
                                                    {
                                                        _cell = new Cell().Add(new Paragraph(item.TIPO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                        _table.AddCell(_cell.AddStyle(style_cellReserva));

                                                        _cell = new Cell().Add(new Paragraph("$ " + item.PRECIO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                        _table.AddCell(_cell);

                                                        NR += 1;
                                                        TR += item.PRECIO;
                                                        ST += item.PRECIO;
                                                    }
                                                    else
                                                    {
                                                        if (item.TIPO.ToString() == "TURISMO")
                                                        {
                                                            _cell = new Cell().Add(new Paragraph(item.TIPO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                            _table.AddCell(_cell.AddStyle(style_cellTour));

                                                            _cell = new Cell().Add(new Paragraph("$ " + item.PRECIO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                            _table.AddCell(_cell);

                                                            NTu += 1;
                                                            TTu += item.PRECIO;
                                                            ST += item.PRECIO;
                                                        }
                                                        else
                                                        {
                                                            if (item.TIPO.ToString() == "TRANSPORTE")
                                                            {
                                                                _cell = new Cell().Add(new Paragraph(item.TIPO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                                _table.AddCell(_cell.AddStyle(style_cellTransporte));

                                                                _cell = new Cell().Add(new Paragraph("$ " + item.PRECIO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                                _table.AddCell(_cell);

                                                                NTr += 1;
                                                                TTr += item.PRECIO;
                                                                ST += item.PRECIO;
                                                            }
                                                            else
                                                            {
                                                                _cell = new Cell().Add(new Paragraph(item.TIPO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                                _table.AddCell(_cell.AddStyle(style_cellServicioExtra));

                                                                _cell = new Cell().Add(new Paragraph("$ " + item.PRECIO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                                _table.AddCell(_cell);

                                                                NSE += 1;
                                                                TSE += item.PRECIO;
                                                                ST += item.PRECIO;
                                                            }
                                                        }
                                                    }
                                                    
                                                }
                                                doc.Add(_table);
                                            }
                                            else
                                            {
                                                if (ckb_dia.IsChecked == false)
                                                {
                                                    int mes = cmb_mes.SelectedIndex + 1;
                                                    List<Reserva> re = r.ListaTodM(deptos.ID, mes, reser.FECHA_INICIO, reser.FECHA_TERMINO);

                                                    foreach (var item in re)
                                                    {
                                                        x++;
                                                        _cell = new Cell().Add(new Paragraph(x.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                        _table.AddCell(_cell);
                                                        _cell = new Cell().Add(new Paragraph(deptos.NOMBRE)).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                        _table.AddCell(_cell);
                                                        _cell = new Cell().Add(new Paragraph(item.ID.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                        _table.AddCell(_cell);
                                                        _cell = new Cell().Add(new Paragraph(item.FECHA_INICIO.ToString("dd-MM-yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                        _table.AddCell(_cell);
                                                        _cell = new Cell().Add(new Paragraph(item.FECHA_TERMINO.ToString("dd-MM-yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                        _table.AddCell(_cell);

                                                        if (item.TIPO.ToString() == "RESERVA")
                                                        {
                                                            _cell = new Cell().Add(new Paragraph(item.TIPO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                            _table.AddCell(_cell.AddStyle(style_cellReserva));

                                                            _cell = new Cell().Add(new Paragraph("$ " + item.PRECIO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                            _table.AddCell(_cell);

                                                            NR += 1;
                                                            TR += item.PRECIO;
                                                            ST += item.PRECIO;
                                                        }
                                                        else
                                                        {
                                                            if (item.TIPO.ToString() == "TURISMO")
                                                            {
                                                                _cell = new Cell().Add(new Paragraph(item.TIPO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                                _table.AddCell(_cell.AddStyle(style_cellTour));

                                                                _cell = new Cell().Add(new Paragraph("$ " + item.PRECIO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                                _table.AddCell(_cell);

                                                                NTu += 1;
                                                                TTu += item.PRECIO;
                                                                ST += item.PRECIO;
                                                            }
                                                            else
                                                            {
                                                                if (item.TIPO.ToString() == "TRANSPORTE")
                                                                {
                                                                    _cell = new Cell().Add(new Paragraph(item.TIPO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                                    _table.AddCell(_cell.AddStyle(style_cellTransporte));

                                                                    _cell = new Cell().Add(new Paragraph("$ " + item.PRECIO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                                    _table.AddCell(_cell);

                                                                    NTr += 1;
                                                                    TTr += item.PRECIO;
                                                                    ST += item.PRECIO;
                                                                }
                                                                else
                                                                {
                                                                    _cell = new Cell().Add(new Paragraph(item.TIPO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                                    _table.AddCell(_cell.AddStyle(style_cellServicioExtra));

                                                                    _cell = new Cell().Add(new Paragraph("$ " + item.PRECIO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                                    _table.AddCell(_cell);

                                                                    NSE += 1;
                                                                    TSE += item.PRECIO;
                                                                    ST += item.PRECIO;
                                                                }
                                                            }
                                                        }
                                                    }
                                                    doc.Add(_table);
                                                }
                                                else
                                                {
                                                    int mes = cmb_mes.SelectedIndex + 1;
                                                    int dia = cmb_dia.SelectedIndex + 1;
                                                    List<Reserva> re = r.ListaTodD(deptos.ID, mes, dia, reser.FECHA_INICIO, reser.FECHA_TERMINO);

                                                    foreach (var item in re)
                                                    {
                                                        x++;
                                                        _cell = new Cell().Add(new Paragraph(x.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                        _table.AddCell(_cell);
                                                        _cell = new Cell().Add(new Paragraph(deptos.NOMBRE)).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                        _table.AddCell(_cell);
                                                        _cell = new Cell().Add(new Paragraph(item.ID.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                        _table.AddCell(_cell);
                                                        _cell = new Cell().Add(new Paragraph(item.FECHA_INICIO.ToString("dd-MM-yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                        _table.AddCell(_cell);
                                                        _cell = new Cell().Add(new Paragraph(item.FECHA_TERMINO.ToString("dd-MM-yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                        _table.AddCell(_cell);

                                                        if (item.TIPO.ToString() == "RESERVA")
                                                        {
                                                            _cell = new Cell().Add(new Paragraph(item.TIPO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                            _table.AddCell(_cell.AddStyle(style_cellReserva));

                                                            _cell = new Cell().Add(new Paragraph("$ " + item.PRECIO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                            _table.AddCell(_cell);

                                                            NR += 1;
                                                            TR += item.PRECIO;
                                                            ST += item.PRECIO;
                                                        }
                                                        else
                                                        {
                                                            if (item.TIPO.ToString() == "TURISMO")
                                                            {
                                                                _cell = new Cell().Add(new Paragraph(item.TIPO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                                _table.AddCell(_cell.AddStyle(style_cellTour));

                                                                _cell = new Cell().Add(new Paragraph("$ " + item.PRECIO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                                _table.AddCell(_cell);

                                                                NTu += 1;
                                                                TTu += item.PRECIO;
                                                                ST += item.PRECIO;
                                                            }
                                                            else
                                                            {
                                                                if (item.TIPO.ToString() == "TRANSPORTE")
                                                                {
                                                                    _cell = new Cell().Add(new Paragraph(item.TIPO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                                    _table.AddCell(_cell.AddStyle(style_cellTransporte));

                                                                    _cell = new Cell().Add(new Paragraph("$ " + item.PRECIO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                                    _table.AddCell(_cell);

                                                                    NTr += 1;
                                                                    TTr += item.PRECIO;
                                                                    ST += item.PRECIO;
                                                                }
                                                                else
                                                                {
                                                                    _cell = new Cell().Add(new Paragraph(item.TIPO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                                    _table.AddCell(_cell.AddStyle(style_cellServicioExtra));

                                                                    _cell = new Cell().Add(new Paragraph("$ " + item.PRECIO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                                    _table.AddCell(_cell);

                                                                    NSE += 1;
                                                                    TSE += item.PRECIO;
                                                                    ST += item.PRECIO;
                                                                }
                                                            }
                                                        }
                                                    }
                                                    doc.Add(_table);
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
                    int x = 0;

                    Departamento deptos = (Departamento)cmb_depto.SelectedItem;

                    List <Reserva> lista = new List<Reserva>(r.BusquedaR(deptos.ID));

                    foreach (var reser in lista)
                    {
                        if (cmb_tipo.SelectedIndex == 0)
                        {
                            if (ckb_mes.IsChecked == false)
                            {
                                int anio = int.Parse(DateTime.Now.ToString("yyyy"));
                                List<Reserva> re = r.BusquedaRA(deptos.ID, anio);
                                foreach (var item in re)
                                {
                                    x++;
                                    _cell = new Cell().Add(new Paragraph(x.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                    _table.AddCell(_cell);
                                    _cell = new Cell().Add(new Paragraph(deptos.NOMBRE)).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                    _table.AddCell(_cell);
                                    _cell = new Cell().Add(new Paragraph(item.ID.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                    _table.AddCell(_cell);
                                    _cell = new Cell().Add(new Paragraph(item.FECHA_INICIO.ToString("dd-MM-yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                    _table.AddCell(_cell);
                                    _cell = new Cell().Add(new Paragraph(item.FECHA_TERMINO.ToString("dd-MM-yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                    _table.AddCell(_cell);
                                    _cell = new Cell().Add(new Paragraph(item.TIPO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                    _table.AddCell(_cell.AddStyle(style_cellReserva));
                                    _cell = new Cell().Add(new Paragraph("$ " + item.PRECIO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                    _table.AddCell(_cell);

                                    NR += 1;
                                    TR += item.PRECIO;
                                    ST += item.PRECIO;
                                }
                                doc.Add(_table);
                            }
                            else
                            {
                                if (ckb_dia.IsChecked == false)
                                {
                                    int mes = cmb_mes.SelectedIndex + 1;
                                    List<Reserva> re = r.BusquedaRM(deptos.ID, mes);

                                    foreach (var item in re)
                                    {
                                        x++;
                                        _cell = new Cell().Add(new Paragraph(x.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                        _table.AddCell(_cell);
                                        _cell = new Cell().Add(new Paragraph(deptos.NOMBRE)).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                        _table.AddCell(_cell);
                                        _cell = new Cell().Add(new Paragraph(item.ID.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                        _table.AddCell(_cell);
                                        _cell = new Cell().Add(new Paragraph(item.FECHA_INICIO.ToString("dd-MM-yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                        _table.AddCell(_cell);
                                        _cell = new Cell().Add(new Paragraph(item.FECHA_TERMINO.ToString("dd-MM-yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                        _table.AddCell(_cell);
                                        _cell = new Cell().Add(new Paragraph(item.TIPO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                        _table.AddCell(_cell.AddStyle(style_cellReserva));
                                        _cell = new Cell().Add(new Paragraph("$ " + item.PRECIO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                        _table.AddCell(_cell);

                                        NR += 1;
                                        TR += item.PRECIO;
                                        ST += item.PRECIO;
                                    }
                                    doc.Add(_table);
                                }
                                else
                                {
                                    int mes = cmb_mes.SelectedIndex + 1;
                                    int dia = cmb_dia.SelectedIndex + 1;
                                    List<Reserva> re = r.BusquedaRD(deptos.ID, mes, dia);

                                    foreach (var item in re)
                                    {
                                        x++;
                                        _cell = new Cell().Add(new Paragraph(x.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                        _table.AddCell(_cell);
                                        _cell = new Cell().Add(new Paragraph(deptos.NOMBRE)).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                        _table.AddCell(_cell);
                                        _cell = new Cell().Add(new Paragraph(item.ID.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                        _table.AddCell(_cell);
                                        _cell = new Cell().Add(new Paragraph(item.FECHA_INICIO.ToString("dd-MM-yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                        _table.AddCell(_cell);
                                        _cell = new Cell().Add(new Paragraph(item.FECHA_TERMINO.ToString("dd-MM-yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                        _table.AddCell(_cell);
                                        _cell = new Cell().Add(new Paragraph(item.TIPO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                        _table.AddCell(_cell.AddStyle(style_cellReserva));
                                        _cell = new Cell().Add(new Paragraph("$ " + item.PRECIO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                        _table.AddCell(_cell);

                                        NR += 1;
                                        TR += item.PRECIO;
                                        ST += item.PRECIO;
                                    }
                                    doc.Add(_table);
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
                                    List<Reserva> re = r.BusquedaTuA(deptos.ID, anio, reser.FECHA_INICIO, reser.FECHA_TERMINO);
                                    foreach (var item in re)
                                    {
                                        x++;
                                        _cell = new Cell().Add(new Paragraph(x.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                        _table.AddCell(_cell);
                                        _cell = new Cell().Add(new Paragraph(deptos.NOMBRE)).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                        _table.AddCell(_cell);
                                        _cell = new Cell().Add(new Paragraph(item.ID.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                        _table.AddCell(_cell);
                                        _cell = new Cell().Add(new Paragraph(item.FECHA_INICIO.ToString("dd-MM-yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                        _table.AddCell(_cell);
                                        _cell = new Cell().Add(new Paragraph(item.FECHA_TERMINO.ToString("dd-MM-yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                        _table.AddCell(_cell);
                                        _cell = new Cell().Add(new Paragraph(item.TIPO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                        _table.AddCell(_cell.AddStyle(style_cellTour));
                                        _cell = new Cell().Add(new Paragraph("$ " + item.PRECIO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                        _table.AddCell(_cell);

                                        NTu += 1;
                                        TTu += item.PRECIO;
                                        ST += item.PRECIO;
                                    }
                                    doc.Add(_table);
                                }
                                else
                                {
                                    if (ckb_dia.IsChecked == false)
                                    {
                                        int mes = cmb_mes.SelectedIndex + 1;
                                        List<Reserva> re = r.BusquedaTuM(deptos.ID, mes, reser.FECHA_INICIO, reser.FECHA_TERMINO);

                                        foreach (var item in re)
                                        {
                                            x++;
                                            _cell = new Cell().Add(new Paragraph(x.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                            _table.AddCell(_cell);
                                            _cell = new Cell().Add(new Paragraph(deptos.NOMBRE)).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                            _table.AddCell(_cell);
                                            _cell = new Cell().Add(new Paragraph(item.ID.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                            _table.AddCell(_cell);
                                            _cell = new Cell().Add(new Paragraph(item.FECHA_INICIO.ToString("dd-MM-yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                            _table.AddCell(_cell);
                                            _cell = new Cell().Add(new Paragraph(item.FECHA_TERMINO.ToString("dd-MM-yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                            _table.AddCell(_cell);
                                            _cell = new Cell().Add(new Paragraph(item.TIPO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                            _table.AddCell(_cell.AddStyle(style_cellTour));
                                            _cell = new Cell().Add(new Paragraph("$ " + item.PRECIO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                            _table.AddCell(_cell);

                                            NTu += 1;
                                            TTu += item.PRECIO;
                                            ST += item.PRECIO;
                                        }
                                        doc.Add(_table);
                                    }
                                    else
                                    {
                                        int mes = cmb_mes.SelectedIndex + 1;
                                        int dia = cmb_dia.SelectedIndex + 1;
                                        List<Reserva> re = r.BusquedaTuD(deptos.ID, mes, dia, reser.FECHA_INICIO, reser.FECHA_TERMINO);

                                        foreach (var item in re)
                                        {
                                            x++;
                                            _cell = new Cell().Add(new Paragraph(x.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                            _table.AddCell(_cell);
                                            _cell = new Cell().Add(new Paragraph(deptos.NOMBRE)).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                            _table.AddCell(_cell);
                                            _cell = new Cell().Add(new Paragraph(item.ID.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                            _table.AddCell(_cell);
                                            _cell = new Cell().Add(new Paragraph(item.FECHA_INICIO.ToString("dd-MM-yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                            _table.AddCell(_cell);
                                            _cell = new Cell().Add(new Paragraph(item.FECHA_TERMINO.ToString("dd-MM-yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                            _table.AddCell(_cell);
                                            _cell = new Cell().Add(new Paragraph(item.TIPO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                            _table.AddCell(_cell.AddStyle(style_cellTour));
                                            _cell = new Cell().Add(new Paragraph("$ " + item.PRECIO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                            _table.AddCell(_cell);

                                            NTu += 1;
                                            TTu += item.PRECIO;
                                            ST += item.PRECIO;
                                        }
                                        doc.Add(_table);
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
                                        List<Reserva> re = r.BusquedaTrA(deptos.ID, anio, reser.FECHA_INICIO, reser.FECHA_TERMINO);
                                        foreach (var item in re)
                                        {
                                            x++;
                                            _cell = new Cell().Add(new Paragraph(x.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                            _table.AddCell(_cell);
                                            _cell = new Cell().Add(new Paragraph(deptos.NOMBRE)).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                            _table.AddCell(_cell);
                                            _cell = new Cell().Add(new Paragraph(item.ID.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                            _table.AddCell(_cell);
                                            _cell = new Cell().Add(new Paragraph(item.FECHA_INICIO.ToString("dd-MM-yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                            _table.AddCell(_cell);
                                            _cell = new Cell().Add(new Paragraph(item.FECHA_TERMINO.ToString("dd-MM-yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                            _table.AddCell(_cell);
                                            _cell = new Cell().Add(new Paragraph(item.TIPO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                            _table.AddCell(_cell.AddStyle(style_cellTransporte));
                                            _cell = new Cell().Add(new Paragraph("$ " + item.PRECIO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                            _table.AddCell(_cell);

                                            NTr += 1;
                                            TTr += item.PRECIO;
                                            ST += item.PRECIO;
                                        }
                                        doc.Add(_table);
                                    }
                                    else
                                    {
                                        if (ckb_dia.IsChecked == false)
                                        {
                                            int mes = cmb_mes.SelectedIndex + 1;
                                            List<Reserva> re = r.BusquedaTrM(deptos.ID, mes, reser.FECHA_INICIO, reser.FECHA_TERMINO);

                                            foreach (var item in re)
                                            {
                                                x++;
                                                _cell = new Cell().Add(new Paragraph(x.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                _table.AddCell(_cell);
                                                _cell = new Cell().Add(new Paragraph(deptos.NOMBRE)).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                _table.AddCell(_cell);
                                                _cell = new Cell().Add(new Paragraph(item.ID.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                _table.AddCell(_cell);
                                                _cell = new Cell().Add(new Paragraph(item.FECHA_INICIO.ToString("dd-MM-yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                _table.AddCell(_cell);
                                                _cell = new Cell().Add(new Paragraph(item.FECHA_TERMINO.ToString("dd-MM-yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                _table.AddCell(_cell);
                                                _cell = new Cell().Add(new Paragraph(item.TIPO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                _table.AddCell(_cell.AddStyle(style_cellTransporte));
                                                _cell = new Cell().Add(new Paragraph("$ " + item.PRECIO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                _table.AddCell(_cell);

                                                NTr += 1;
                                                TTr += item.PRECIO;
                                                ST += item.PRECIO;
                                            }
                                            doc.Add(_table);
                                        }
                                        else
                                        {
                                            int mes = cmb_mes.SelectedIndex + 1;
                                            int dia = cmb_dia.SelectedIndex + 1;
                                            List<Reserva> re = r.BusquedaTrD(deptos.ID, mes, dia, reser.FECHA_INICIO, reser.FECHA_TERMINO);

                                            foreach (var item in re)
                                            {
                                                x++;
                                                _cell = new Cell().Add(new Paragraph(x.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                _table.AddCell(_cell);
                                                _cell = new Cell().Add(new Paragraph(deptos.NOMBRE)).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                _table.AddCell(_cell);
                                                _cell = new Cell().Add(new Paragraph(item.ID.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                _table.AddCell(_cell);
                                                _cell = new Cell().Add(new Paragraph(item.FECHA_INICIO.ToString("dd-MM-yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                _table.AddCell(_cell);
                                                _cell = new Cell().Add(new Paragraph(item.FECHA_TERMINO.ToString("dd-MM-yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                _table.AddCell(_cell);
                                                _cell = new Cell().Add(new Paragraph(item.TIPO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                _table.AddCell(_cell.AddStyle(style_cellTransporte));
                                                _cell = new Cell().Add(new Paragraph("$ " + item.PRECIO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                _table.AddCell(_cell);

                                                NTr += 1;
                                                TTr += item.PRECIO;
                                                ST += item.PRECIO;
                                            }
                                            doc.Add(_table);
                                        }
                                    }
                                }
                                else
                                {
                                    if (ckb_mes.IsChecked == false)
                                    {
                                        int anio = int.Parse(DateTime.Now.ToString("yyyy"));
                                        List<Reserva> re = r.BusquedaSEA(deptos.ID, anio, reser.FECHA_INICIO, reser.FECHA_TERMINO);
                                        foreach (var item in re)
                                        {
                                            x++;
                                            _cell = new Cell().Add(new Paragraph(x.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                            _table.AddCell(_cell);
                                            _cell = new Cell().Add(new Paragraph(deptos.NOMBRE)).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                            _table.AddCell(_cell);
                                            _cell = new Cell().Add(new Paragraph(item.ID.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                            _table.AddCell(_cell);
                                            _cell = new Cell().Add(new Paragraph(item.FECHA_INICIO.ToString("dd-MM-yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                            _table.AddCell(_cell);
                                            _cell = new Cell().Add(new Paragraph(item.FECHA_TERMINO.ToString("dd-MM-yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                            _table.AddCell(_cell);
                                            _cell = new Cell().Add(new Paragraph(item.TIPO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                            _table.AddCell(_cell.AddStyle(style_cellServicioExtra));
                                            _cell = new Cell().Add(new Paragraph("$ " + item.PRECIO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                            _table.AddCell(_cell);

                                            NSE += 1;
                                            TSE += item.PRECIO;
                                            ST += item.PRECIO;
                                        }
                                        doc.Add(_table);
                                    }
                                    else
                                    {
                                        if (cmb_tipo.SelectedIndex == 3)
                                        {
                                            if (ckb_mes.IsChecked == false)
                                            {
                                                int anio = int.Parse(DateTime.Now.ToString("yyyy"));
                                                List<Reserva> re = r.BusquedaSEA(deptos.ID, anio, reser.FECHA_INICIO, reser.FECHA_TERMINO);
                                                foreach (var item in re)
                                                {
                                                    x++;
                                                    _cell = new Cell().Add(new Paragraph(x.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                    _table.AddCell(_cell);
                                                    _cell = new Cell().Add(new Paragraph(deptos.NOMBRE)).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                    _table.AddCell(_cell);
                                                    _cell = new Cell().Add(new Paragraph(item.ID.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                    _table.AddCell(_cell);
                                                    _cell = new Cell().Add(new Paragraph(item.FECHA_INICIO.ToString("dd-MM-yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                    _table.AddCell(_cell);
                                                    _cell = new Cell().Add(new Paragraph(item.FECHA_TERMINO.ToString("dd-MM-yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                    _table.AddCell(_cell);
                                                    _cell = new Cell().Add(new Paragraph(item.TIPO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                    _table.AddCell(_cell.AddStyle(style_cellServicioExtra));
                                                    _cell = new Cell().Add(new Paragraph("$ " + item.PRECIO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                    _table.AddCell(_cell);

                                                    NSE += 1;
                                                    TSE += item.PRECIO;
                                                    ST += item.PRECIO;
                                                }
                                                doc.Add(_table);
                                            }
                                            else
                                            {
                                                if (ckb_dia.IsChecked == false)
                                                {
                                                    int mes = cmb_mes.SelectedIndex + 1;
                                                    List<Reserva> re = r.BusquedaSEM(deptos.ID, mes, reser.FECHA_INICIO, reser.FECHA_TERMINO);

                                                    foreach (var item in re)
                                                    {
                                                        x++;
                                                        _cell = new Cell().Add(new Paragraph(x.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                        _table.AddCell(_cell);
                                                        _cell = new Cell().Add(new Paragraph(deptos.NOMBRE)).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                        _table.AddCell(_cell);
                                                        _cell = new Cell().Add(new Paragraph(item.ID.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                        _table.AddCell(_cell);
                                                        _cell = new Cell().Add(new Paragraph(item.FECHA_INICIO.ToString("dd-MM-yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                        _table.AddCell(_cell);
                                                        _cell = new Cell().Add(new Paragraph(item.FECHA_TERMINO.ToString("dd-MM-yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                        _table.AddCell(_cell);
                                                        _cell = new Cell().Add(new Paragraph(item.TIPO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                        _table.AddCell(_cell.AddStyle(style_cellServicioExtra));
                                                        _cell = new Cell().Add(new Paragraph("$ " + item.PRECIO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                        _table.AddCell(_cell);

                                                        NSE += 1;
                                                        TSE += item.PRECIO;
                                                        ST += item.PRECIO;
                                                    }
                                                    doc.Add(_table);
                                                }
                                                else
                                                {
                                                    int mes = cmb_mes.SelectedIndex + 1;
                                                    int dia = cmb_dia.SelectedIndex + 1;
                                                    List<Reserva> re = r.BusquedaSED(deptos.ID, mes, dia, reser.FECHA_INICIO, reser.FECHA_TERMINO);

                                                    foreach (var item in re)
                                                    {
                                                        x++;
                                                        _cell = new Cell().Add(new Paragraph(x.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                        _table.AddCell(_cell);
                                                        _cell = new Cell().Add(new Paragraph(deptos.NOMBRE)).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                        _table.AddCell(_cell);
                                                        _cell = new Cell().Add(new Paragraph(item.ID.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                        _table.AddCell(_cell);
                                                        _cell = new Cell().Add(new Paragraph(item.FECHA_INICIO.ToString("dd-MM-yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                        _table.AddCell(_cell);
                                                        _cell = new Cell().Add(new Paragraph(item.FECHA_TERMINO.ToString("dd-MM-yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                        _table.AddCell(_cell);
                                                        _cell = new Cell().Add(new Paragraph(item.TIPO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                        _table.AddCell(_cell.AddStyle(style_cellServicioExtra));
                                                        _cell = new Cell().Add(new Paragraph("$ " + item.PRECIO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                        _table.AddCell(_cell);

                                                        NSE += 1;
                                                        TSE += item.PRECIO;
                                                        ST += item.PRECIO;
                                                    }
                                                    doc.Add(_table);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (ckb_mes.IsChecked == false)
                                            {
                                                int anio = int.Parse(DateTime.Now.ToString("yyyy"));
                                                List<Reserva> re = r.ListaTodA(deptos.ID, anio, reser.FECHA_INICIO, reser.FECHA_TERMINO);
                                                foreach (var item in re)
                                                {
                                                    x++;
                                                    _cell = new Cell().Add(new Paragraph(x.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                    _table.AddCell(_cell);
                                                    _cell = new Cell().Add(new Paragraph(deptos.NOMBRE)).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                    _table.AddCell(_cell);
                                                    _cell = new Cell().Add(new Paragraph(item.ID.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                    _table.AddCell(_cell);
                                                    _cell = new Cell().Add(new Paragraph(item.FECHA_INICIO.ToString("dd-MM-yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                    _table.AddCell(_cell);
                                                    _cell = new Cell().Add(new Paragraph(item.FECHA_TERMINO.ToString("dd-MM-yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                    _table.AddCell(_cell);

                                                    if (item.TIPO.ToString() == "RESERVA")
                                                    {
                                                        _cell = new Cell().Add(new Paragraph(item.TIPO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                        _table.AddCell(_cell.AddStyle(style_cellReserva));

                                                        _cell = new Cell().Add(new Paragraph("$ " + item.PRECIO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                        _table.AddCell(_cell);

                                                        NR += 1;
                                                        TR += item.PRECIO;
                                                        ST += item.PRECIO;
                                                    }
                                                    else
                                                    {
                                                        if (item.TIPO.ToString() == "TURISMO")
                                                        {
                                                            _cell = new Cell().Add(new Paragraph(item.TIPO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                            _table.AddCell(_cell.AddStyle(style_cellTour));

                                                            _cell = new Cell().Add(new Paragraph("$ " + item.PRECIO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                            _table.AddCell(_cell);

                                                            NTu += 1;
                                                            TTu += item.PRECIO;
                                                            ST += item.PRECIO;
                                                        }
                                                        else
                                                        {
                                                            if (item.TIPO.ToString() == "TRANSPORTE")
                                                            {
                                                                _cell = new Cell().Add(new Paragraph(item.TIPO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                                _table.AddCell(_cell.AddStyle(style_cellTransporte));

                                                                _cell = new Cell().Add(new Paragraph("$ " + item.PRECIO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                                _table.AddCell(_cell);

                                                                NTr += 1;
                                                                TTr += item.PRECIO;
                                                                ST += item.PRECIO;
                                                            }
                                                            else
                                                            {
                                                                _cell = new Cell().Add(new Paragraph(item.TIPO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                                _table.AddCell(_cell.AddStyle(style_cellServicioExtra));

                                                                _cell = new Cell().Add(new Paragraph("$ " + item.PRECIO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                                _table.AddCell(_cell);

                                                                NSE += 1;
                                                                TSE += item.PRECIO;
                                                                ST += item.PRECIO;
                                                            }
                                                        }
                                                    }

                                                }
                                                doc.Add(_table);
                                            }
                                            else
                                            {
                                                if (ckb_dia.IsChecked == false)
                                                {
                                                    int mes = cmb_mes.SelectedIndex + 1;
                                                    List<Reserva> re = r.ListaTodM(deptos.ID, mes, reser.FECHA_INICIO, reser.FECHA_TERMINO);

                                                    foreach (var item in re)
                                                    {
                                                        x++;
                                                        _cell = new Cell().Add(new Paragraph(x.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                        _table.AddCell(_cell);
                                                        _cell = new Cell().Add(new Paragraph(deptos.NOMBRE)).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                        _table.AddCell(_cell);
                                                        _cell = new Cell().Add(new Paragraph(item.ID.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                        _table.AddCell(_cell);
                                                        _cell = new Cell().Add(new Paragraph(item.FECHA_INICIO.ToString("dd-MM-yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                        _table.AddCell(_cell);
                                                        _cell = new Cell().Add(new Paragraph(item.FECHA_TERMINO.ToString("dd-MM-yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                        _table.AddCell(_cell);

                                                        if (item.TIPO.ToString() == "RESERVA")
                                                        {
                                                            _cell = new Cell().Add(new Paragraph(item.TIPO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                            _table.AddCell(_cell.AddStyle(style_cellReserva));

                                                            _cell = new Cell().Add(new Paragraph("$ " + item.PRECIO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                            _table.AddCell(_cell);

                                                            NR += 1;
                                                            TR += item.PRECIO;
                                                            ST += item.PRECIO;
                                                        }
                                                        else
                                                        {
                                                            if (item.TIPO.ToString() == "TURISMO")
                                                            {
                                                                _cell = new Cell().Add(new Paragraph(item.TIPO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                                _table.AddCell(_cell.AddStyle(style_cellTour));

                                                                _cell = new Cell().Add(new Paragraph("$ " + item.PRECIO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                                _table.AddCell(_cell);

                                                                NTu += 1;
                                                                TTu += item.PRECIO;
                                                                ST += item.PRECIO;
                                                            }
                                                            else
                                                            {
                                                                if (item.TIPO.ToString() == "TRANSPORTE")
                                                                {
                                                                    _cell = new Cell().Add(new Paragraph(item.TIPO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                                    _table.AddCell(_cell.AddStyle(style_cellTransporte));

                                                                    _cell = new Cell().Add(new Paragraph("$ " + item.PRECIO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                                    _table.AddCell(_cell);

                                                                    NTr += 1;
                                                                    TTr += item.PRECIO;
                                                                    ST += item.PRECIO;
                                                                }
                                                                else
                                                                {
                                                                    _cell = new Cell().Add(new Paragraph(item.TIPO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                                    _table.AddCell(_cell.AddStyle(style_cellServicioExtra));

                                                                    _cell = new Cell().Add(new Paragraph("$ " + item.PRECIO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                                    _table.AddCell(_cell);

                                                                    NSE += 1;
                                                                    TSE += item.PRECIO;
                                                                    ST += item.PRECIO;
                                                                }
                                                            }
                                                        }
                                                    }
                                                    doc.Add(_table);
                                                }
                                                else
                                                {
                                                    int mes = cmb_mes.SelectedIndex + 1;
                                                    int dia = cmb_dia.SelectedIndex + 1;
                                                    List<Reserva> re = r.ListaTodD(deptos.ID, mes, dia, reser.FECHA_INICIO, reser.FECHA_TERMINO);

                                                    foreach (var item in re)
                                                    {
                                                        x++;
                                                        _cell = new Cell().Add(new Paragraph(x.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                        _table.AddCell(_cell);
                                                        _cell = new Cell().Add(new Paragraph(deptos.NOMBRE)).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                        _table.AddCell(_cell);
                                                        _cell = new Cell().Add(new Paragraph(item.ID.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                        _table.AddCell(_cell);
                                                        _cell = new Cell().Add(new Paragraph(item.FECHA_INICIO.ToString("dd-MM-yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                        _table.AddCell(_cell);
                                                        _cell = new Cell().Add(new Paragraph(item.FECHA_TERMINO.ToString("dd-MM-yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                        _table.AddCell(_cell);

                                                        if (item.TIPO.ToString() == "RESERVA")
                                                        {
                                                            _cell = new Cell().Add(new Paragraph(item.TIPO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                            _table.AddCell(_cell.AddStyle(style_cellReserva));

                                                            _cell = new Cell().Add(new Paragraph("$ " + item.PRECIO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                            _table.AddCell(_cell);

                                                            NR += 1;
                                                            TR += item.PRECIO;
                                                            ST += item.PRECIO;
                                                        }
                                                        else
                                                        {
                                                            if (item.TIPO.ToString() == "TURISMO")
                                                            {
                                                                _cell = new Cell().Add(new Paragraph(item.TIPO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                                _table.AddCell(_cell.AddStyle(style_cellTour));

                                                                _cell = new Cell().Add(new Paragraph("$ " + item.PRECIO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                                _table.AddCell(_cell);

                                                                NTu += 1;
                                                                TTu += item.PRECIO;
                                                                ST += item.PRECIO;
                                                            }
                                                            else
                                                            {
                                                                if (item.TIPO.ToString() == "TRANSPORTE")
                                                                {
                                                                    _cell = new Cell().Add(new Paragraph(item.TIPO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                                    _table.AddCell(_cell.AddStyle(style_cellTransporte));

                                                                    _cell = new Cell().Add(new Paragraph("$ " + item.PRECIO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                                    _table.AddCell(_cell);

                                                                    NTr += 1;
                                                                    TTr += item.PRECIO;
                                                                    ST += item.PRECIO;
                                                                }
                                                                else
                                                                {
                                                                    _cell = new Cell().Add(new Paragraph(item.TIPO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                                    _table.AddCell(_cell.AddStyle(style_cellServicioExtra));

                                                                    _cell = new Cell().Add(new Paragraph("$ " + item.PRECIO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                                                    _table.AddCell(_cell);

                                                                    NSE += 1;
                                                                    TSE += item.PRECIO;
                                                                    ST += item.PRECIO;
                                                                }
                                                            }
                                                        }
                                                    }
                                                    doc.Add(_table);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                }

                Table table2 = new Table(2);
                Cell cell2 = new Cell(1, 2).Add(new Paragraph(""))
                                        .SetFontSize(24)
                                        .SetTextAlignment(TextAlignment.LEFT)
                                        .SetBorder(Border.NO_BORDER);
                table2.AddCell(cell2);
                cell2 = new Cell(1, 2).Add(new Paragraph("Resultado informe"))
                                        .SetFontSize(24)
                                        .SetTextAlignment(TextAlignment.LEFT)
                                        .SetBorder(Border.NO_BORDER);
                table2.AddCell(cell2);
                cell2 = new Cell(1, 2).Add(new Paragraph(""))
                                        .SetFontSize(24)
                                        .SetTextAlignment(TextAlignment.LEFT)
                                        .SetBorder(Border.NO_BORDER);
                table2.AddCell(cell2);

                Style stileCell3 = new Style()
                    .SetFontSize(12)
                    .SetTextAlignment(TextAlignment.LEFT)
                    .SetBorder(Border.NO_BORDER);


                cell2 = new Cell().Add(new Paragraph("Número de Reservas:         "));
                table2.AddCell(cell2.AddStyle(stileCell3));
                cell2 = new Cell().Add(new Paragraph(NR.ToString()));
                table2.AddCell(cell2.AddStyle(stileCell3));
                cell2 = new Cell().Add(new Paragraph("Total de Reservas:          "));
                table2.AddCell(cell2.AddStyle(stileCell3));
                cell2 = new Cell().Add(new Paragraph("$ " + TR.ToString()));
                table2.AddCell(cell2.AddStyle(stileCell3));

                cell2 = new Cell().Add(new Paragraph("Número de Turismos:         "));
                table2.AddCell(cell2.AddStyle(stileCell3));
                cell2 = new Cell().Add(new Paragraph(NTu.ToString()));
                table2.AddCell(cell2.AddStyle(stileCell3));
                cell2 = new Cell().Add(new Paragraph("Total de Turismos:          "));
                table2.AddCell(cell2.AddStyle(stileCell3));
                cell2 = new Cell().Add(new Paragraph("$ " + TTu.ToString()));
                table2.AddCell(cell2.AddStyle(stileCell3));

                cell2 = new Cell().Add(new Paragraph("Número de Transportes:      "));
                table2.AddCell(cell2.AddStyle(stileCell3));
                cell2 = new Cell().Add(new Paragraph(NTr.ToString()));
                table2.AddCell(cell2.AddStyle(stileCell3));
                cell2 = new Cell().Add(new Paragraph("Total de Transportes:       "));
                table2.AddCell(cell2.AddStyle(stileCell3));
                cell2 = new Cell().Add(new Paragraph("$ " + TTr.ToString()));
                table2.AddCell(cell2.AddStyle(stileCell3));

                cell2 = new Cell().Add(new Paragraph("Número de Servicios Extras: "));
                table2.AddCell(cell2.AddStyle(stileCell3));
                cell2 = new Cell().Add(new Paragraph(NSE.ToString()));
                table2.AddCell(cell2.AddStyle(stileCell3));
                cell2 = new Cell().Add(new Paragraph("Total de Servicios Extras:  "));
                table2.AddCell(cell2.AddStyle(stileCell3));
                cell2 = new Cell().Add(new Paragraph("$ " + TSE.ToString()));
                table2.AddCell(cell2.AddStyle(stileCell3));

                cell2 = new Cell().Add(new Paragraph("Suma Total:                 "));
                table2.AddCell(cell2.AddStyle(stileCell3));
                cell2 = new Cell().Add(new Paragraph("$ " + ST.ToString()));

                table2.AddCell(cell2.AddStyle(stileCell3));
                doc.Add(table2);
                table2.SetMarginBottom(10f);

                doc.Close();
                return true;
            }
            catch (ArgumentException ex)
            {
                ClLoggerErrores.Mensaje(ex.ToString());
                return false;
            }
        }
        public class HeaderEventHandler : IEventHandler
        {
            Image Img;
            public HeaderEventHandler(Image img)
            {
                Img = img;
            }
            public void HandleEvent(Event @event)
            {
                PdfDocumentEvent docEvent = (PdfDocumentEvent)@event;
                PdfDocument pdfDoc = docEvent.GetDocument();
                PdfPage page = docEvent.GetPage();

                PdfCanvas canvas1 = new PdfCanvas(page.NewContentStreamBefore(), page.GetResources(), pdfDoc);
                Rectangle rootArea = new Rectangle(35, page.GetPageSize().GetTop() - 75, page.GetPageSize().GetRight() - 72, 60);
                new Canvas(canvas1, pdfDoc, rootArea)
                    .Add(getTable(docEvent));

                //Rectangle rootArea = new Rectangle(35, page.GetPageSize().GetTop() - 70, page.GetPageSize().GetRight() - 70, 50);
                //Canvas canvas = new Canvas(docEvent.GetPage(), rootArea);

                //canvas
                //    .Add(getTable(docEvent));

            }
            public Table getTable(PdfDocumentEvent docEvent)
            {
                float[] cellWhith = { 20f, 80f };
                Table tableEvent = new Table(UnitValue.CreatePercentArray(cellWhith)).UseAllAvailableWidth();

                Style styleCell = new Style()
                    .SetBorder(Border.NO_BORDER);

                Style styleText = new Style()
                    .SetTextAlignment(TextAlignment.RIGHT).SetFontSize(10f);

                Cell cell = new Cell().Add(Img.SetAutoScale(true)).SetBorder(Border.NO_BORDER);

                tableEvent.AddCell(cell
                    .AddStyle(styleCell)
                    .SetTextAlignment(TextAlignment.LEFT));
                PdfFont bold = PdfFontFactory.CreateFont(StandardFonts.TIMES_BOLD);

                cell = new Cell()
                    .Add(new Paragraph("Reporte de Reserva Turismo Real\n").SetFont(bold))
                    .Add(new Paragraph("Administración\n").SetFont(bold))
                    .Add(new Paragraph("Fecha de Emisión: " + DateTime.Now.ToShortDateString()))
                    .AddStyle(styleText).AddStyle(styleCell);

                tableEvent.AddCell(cell);

                return tableEvent;
            }
        }



        public class FooterEventHandler : IEventHandler
        {
            public void HandleEvent(Event @event)
            {
                PdfDocumentEvent docEvent = (PdfDocumentEvent)@event;
                PdfDocument pdfDoc = docEvent.GetDocument();
                PdfPage page = docEvent.GetPage();

                PdfCanvas canvas1 = new PdfCanvas(page.NewContentStreamBefore(), page.GetResources(), pdfDoc);
                Rectangle rootArea = new Rectangle(35, 20, page.GetPageSize().GetRight() - 72, 60);
                new Canvas(canvas1, pdfDoc, rootArea)
                    .Add(getTable(docEvent));
            }
            public Table getTable(PdfDocumentEvent docEvent)
            {
                float[] cellWhith = { 92f, 8f };
                Table tableEvent = new Table(UnitValue.CreatePercentArray(cellWhith)).UseAllAvailableWidth();

                PdfPage page = docEvent.GetPage();
                int pageNum = docEvent.GetDocument().GetPageNumber(page);

                Style styleCell = new Style()
                    .SetPadding(5)
                    .SetBorder(Border.NO_BORDER)
                    .SetBorderTop(new SolidBorder(ColorConstants.BLACK, 2));

                Cell cell = new Cell().Add(new Paragraph(DateTime.Now.ToLongDateString()));
                tableEvent.AddCell(cell
                    .AddStyle(styleCell)
                    .SetTextAlignment(TextAlignment.RIGHT)
                    .SetFontColor(ColorConstants.LIGHT_GRAY));
                cell = new Cell().Add(new Paragraph(pageNum.ToString()));
                cell.AddStyle(styleCell)
                    .SetBackgroundColor(ColorConstants.BLACK)
                    .SetFontColor(ColorConstants.WHITE)
                    .SetTextAlignment(TextAlignment.CENTER);
                tableEvent.AddCell(cell);


                return tableEvent;
            }
        }
    }
}
