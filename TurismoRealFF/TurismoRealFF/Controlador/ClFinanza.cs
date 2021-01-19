using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurismoRealFF.Modelo;
using System.Windows.Forms;
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
    public class ClFinanza
    {
        readonly Finanza f = new Finanza();

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Precio { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; }
        public int Mes { get; set; }
        public int Dia { get; set; }

        public ArrayList ListaID()
        {
            ArrayList lista = new ArrayList(f.BusquedaID(Mes,Dia));
            return lista;
        }
        public ArrayList ListaIM()
        {
            ArrayList lista = new ArrayList(f.BusquedaIM(Mes));
            return lista;
        }
        public ArrayList ListaED()
        {
            ArrayList lista = new ArrayList(f.BusquedaED(Mes, Dia));
            return lista;
        }
        public ArrayList ListaEM()
        {
            ArrayList lista = new ArrayList(f.BusquedaEM(Mes));
            return lista;
        }
        public ArrayList ListaTD()
        {
            ArrayList lista = new ArrayList(f.BusquedaTD(Mes, Dia));
            return lista;
        }
        public ArrayList ListaTM()
        {
            ArrayList lista = new ArrayList(f.BusquedaTM(Mes));
            return lista;
        }

        public bool CrearPDF(ComboBox cmb_tipo, ComboBox cmb_mes, ComboBox cmb_dia, CheckBox ckb_mes, CheckBox ckb_dia)
        {
            try
            {
                string paths = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                string fecha = DateTime.Now.ToString("dd-MM-yyyy");
                string hora = DateTime.Now.ToString("HH");
                string minuto = DateTime.Now.ToString("mm");
                string segundo = DateTime.Now.ToString("ss");
                PdfWriter pw = new PdfWriter(paths + "\\Reportes/Reporte Estadistica/Reporte_Estadística_" + fecha + "_" + hora + "." + minuto + "." + segundo + ".pdf");
                PdfDocument pdfDocument = new PdfDocument(pw);
                Document doc = new Document(pdfDocument, PageSize.A4);
                doc.SetMargins(75, 35, 70, 35);

                string pathLogo = paths + "\\Imagenes/turismo.png";
                Image img = new Image(ImageDataFactory.Create(pathLogo));
                pdfDocument.AddEventHandler(PdfDocumentEvent.START_PAGE, new HeaderEventHandler(img));
                pdfDocument.AddEventHandler(PdfDocumentEvent.END_PAGE, new FooterEventHandler());


                Table table = new Table(1).UseAllAvailableWidth();
                Cell cell = new Cell().Add(new Paragraph("Reporte de Estadística"))
                                        .SetFontSize(24)
                                        .SetTextAlignment(TextAlignment.CENTER)
                                        .SetBorder(Border.NO_BORDER);
                table.AddCell(cell);
                cell = new Cell().Add(new Paragraph("Contabilidad de Turismo Real"))
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
                Style style_cellE = new Style()
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetFontColor(ColorConstants.WHITE)
                    .SetBackgroundColor(ColorConstants.RED)
                    .SetFontSize(12);
                Style style_cellI = new Style()
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetBackgroundColor(ColorConstants.GREEN)
                    .SetFontSize(12);

                Table _table = new Table(5).UseAllAvailableWidth();
                Cell _cell = new Cell(2, 1).Add(new Paragraph("#"));
                _table.AddCell(_cell.AddStyle(stileCell2));
                _cell = new Cell(1, 3).Add(new Paragraph("Contabilidad"));
                _table.AddCell(_cell.AddStyle(stileCell2));
                _cell = new Cell(2, 1).Add(new Paragraph("Tipo de Contabilidad"));
                _table.AddCell(_cell.AddStyle(stileCell2));
                _cell = new Cell().Add(new Paragraph("Nombre"));
                _table.AddCell(_cell.AddStyle(stileCell));
                _cell = new Cell().Add(new Paragraph("Precio"));
                _table.AddCell(_cell.AddStyle(stileCell));
                _cell = new Cell().Add(new Paragraph("Fecha"));
                _table.AddCell(_cell.AddStyle(stileCell));

                int NIng = 0;
                int TIng = 0;
                int NEg = 0;
                int TEg = 0;
                int ST = 0;

                Finanza fin = new Finanza();
                if (cmb_tipo.SelectedIndex == 0)
                {
                    if (ckb_mes.IsChecked == false)
                    {
                        int anio = int.Parse(DateTime.Now.ToString("yyyy"));
                        List<Finanza> fi = fin.BusquedaIA(anio);

                        int x = 0;
                        foreach (var item in fi)
                        {
                            x++;
                            _cell = new Cell().Add(new Paragraph(x.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                            _table.AddCell(_cell);
                            _cell = new Cell().Add(new Paragraph(item.NOMBRE)).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                            _table.AddCell(_cell);
                            _cell = new Cell().Add(new Paragraph("$ " + item.PRECIO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                            _table.AddCell(_cell);
                            _cell = new Cell().Add(new Paragraph(item.FECHA.ToString("dd/MM/yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                            _table.AddCell(_cell);
                            if (item.TIPO == "Ingreso")
                            {
                                _cell = new Cell().Add(new Paragraph("Ingreso"));
                                _table.AddCell(_cell.AddStyle(style_cellI));

                                NIng += 1;
                                TIng += item.PRECIO;
                                ST += item.PRECIO;
                            }
                            else
                            {
                                _cell = new Cell().Add(new Paragraph("Egreso"));
                                _table.AddCell(_cell.AddStyle(style_cellE));
                                NEg += 1;
                                TEg += item.PRECIO;
                                ST -= item.PRECIO;
                            }
                            

                        }
                        doc.Add(_table);
                    }
                    else
                    {
                        if (ckb_dia.IsChecked == false)
                        {
                            int mes = cmb_mes.SelectedIndex + 1;
                            List<Finanza> fi = fin.BusquedaIM(mes);

                            int x = 0;
                            foreach (var item in fi)
                            {
                                x++;
                                _cell = new Cell().Add(new Paragraph(x.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                _table.AddCell(_cell);
                                _cell = new Cell().Add(new Paragraph(item.NOMBRE)).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                _table.AddCell(_cell);
                                _cell = new Cell().Add(new Paragraph("$ " + item.PRECIO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                _table.AddCell(_cell);
                                _cell = new Cell().Add(new Paragraph(item.FECHA.ToString("dd/MM/yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                _table.AddCell(_cell);
                                if (item.TIPO == "Ingreso")
                                {
                                    _cell = new Cell().Add(new Paragraph("Ingreso"));
                                    _table.AddCell(_cell.AddStyle(style_cellI));

                                    NIng += 1;
                                    TIng += item.PRECIO;
                                    ST += item.PRECIO;
                                }
                                else
                                {
                                    _cell = new Cell().Add(new Paragraph("Egreso"));
                                    _table.AddCell(_cell.AddStyle(style_cellE));
                                    NEg += 1;
                                    TEg += item.PRECIO;
                                    ST -= item.PRECIO;
                                }
                            }
                            doc.Add(_table);
                        }
                        else
                        {
                            int mes = cmb_mes.SelectedIndex + 1;
                            int dia = cmb_dia.SelectedIndex + 1;
                            List<Finanza> fi = fin.BusquedaID(mes, dia);

                            int x = 0;
                            foreach (var item in fi)
                            {
                                x++;
                                _cell = new Cell().Add(new Paragraph(x.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                _table.AddCell(_cell);
                                _cell = new Cell().Add(new Paragraph(item.NOMBRE)).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                _table.AddCell(_cell);
                                _cell = new Cell().Add(new Paragraph("$ " + item.PRECIO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                _table.AddCell(_cell);
                                _cell = new Cell().Add(new Paragraph(item.FECHA.ToString("dd/MM/yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                _table.AddCell(_cell);
                                if (item.TIPO == "Ingreso")
                                {
                                    _cell = new Cell().Add(new Paragraph("Ingreso"));
                                    _table.AddCell(_cell.AddStyle(style_cellI));

                                    NIng += 1;
                                    TIng += item.PRECIO;
                                    ST += item.PRECIO;
                                }
                                else
                                {
                                    _cell = new Cell().Add(new Paragraph("Egreso"));
                                    _table.AddCell(_cell.AddStyle(style_cellE));
                                    NEg += 1;
                                    TEg += item.PRECIO;
                                    ST -= item.PRECIO;
                                }
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
                            List<Finanza> fi = fin.BusquedaEA(anio);

                            int x = 0;
                            foreach (var item in fi)
                            {
                                x++;
                                _cell = new Cell().Add(new Paragraph(x.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                _table.AddCell(_cell);
                                _cell = new Cell().Add(new Paragraph(item.NOMBRE)).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                _table.AddCell(_cell);
                                _cell = new Cell().Add(new Paragraph("$ " + item.PRECIO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                _table.AddCell(_cell);
                                _cell = new Cell().Add(new Paragraph(item.FECHA.ToString("dd/MM/yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                _table.AddCell(_cell);
                                if (item.TIPO == "Ingreso")
                                {
                                    _cell = new Cell().Add(new Paragraph("Ingreso"));
                                    _table.AddCell(_cell.AddStyle(style_cellI));

                                    NIng += 1;
                                    TIng += item.PRECIO;
                                    ST += item.PRECIO;
                                }
                                else
                                {
                                    _cell = new Cell().Add(new Paragraph("Egreso"));
                                    _table.AddCell(_cell.AddStyle(style_cellE));
                                    NEg += 1;
                                    TEg += item.PRECIO;
                                    ST -= item.PRECIO;
                                }
                            }
                            doc.Add(_table);
                        }
                        else
                        {
                            if (ckb_dia.IsChecked == false)
                            {
                                int mes = cmb_mes.SelectedIndex + 1;
                                List<Finanza> fi = fin.BusquedaEM(mes);

                                int x = 0;
                                foreach (var item in fi)
                                {
                                    x++;
                                    _cell = new Cell().Add(new Paragraph(x.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                    _table.AddCell(_cell);
                                    _cell = new Cell().Add(new Paragraph(item.NOMBRE)).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                    _table.AddCell(_cell);
                                    _cell = new Cell().Add(new Paragraph("$ " + item.PRECIO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                    _table.AddCell(_cell);
                                    _cell = new Cell().Add(new Paragraph(item.FECHA.ToString("dd/MM/yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                    _table.AddCell(_cell);
                                    if (item.TIPO == "Ingreso")
                                    {
                                        _cell = new Cell().Add(new Paragraph("Ingreso"));
                                        _table.AddCell(_cell.AddStyle(style_cellI));

                                        NIng += 1;
                                        TIng += item.PRECIO;
                                        ST += item.PRECIO;
                                    }
                                    else
                                    {
                                        _cell = new Cell().Add(new Paragraph("Egreso"));
                                        _table.AddCell(_cell.AddStyle(style_cellE));
                                        NEg += 1;
                                        TEg += item.PRECIO;
                                        ST -= item.PRECIO;
                                    }
                                }
                                doc.Add(_table);
                            }
                            else
                            {
                                int mes = cmb_mes.SelectedIndex + 1;
                                int dia = cmb_dia.SelectedIndex + 1;
                                List<Finanza> fi = fin.BusquedaED(mes, dia);

                                int x = 0;
                                foreach (var item in fi)
                                {
                                    x++;
                                    _cell = new Cell().Add(new Paragraph(x.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                    _table.AddCell(_cell);
                                    _cell = new Cell().Add(new Paragraph(item.NOMBRE)).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                    _table.AddCell(_cell);
                                    _cell = new Cell().Add(new Paragraph("$ " + item.PRECIO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                    _table.AddCell(_cell);
                                    _cell = new Cell().Add(new Paragraph(item.FECHA.ToString("dd/MM/yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                    _table.AddCell(_cell);
                                    if (item.TIPO == "Ingreso")
                                    {
                                        _cell = new Cell().Add(new Paragraph("Ingreso"));
                                        _table.AddCell(_cell.AddStyle(style_cellI));

                                        NIng += 1;
                                        TIng += item.PRECIO;
                                        ST += item.PRECIO;
                                    }
                                    else
                                    {
                                        _cell = new Cell().Add(new Paragraph("Egreso"));
                                        _table.AddCell(_cell.AddStyle(style_cellE));
                                        NEg += 1;
                                        TEg += item.PRECIO;
                                        ST -= item.PRECIO;
                                    }
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
                            List<Finanza> fi = fin.BusquedaTA(anio);

                            int x = 0;
                            foreach (var item in fi)
                            {
                                x++;
                                _cell = new Cell().Add(new Paragraph(x.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                _table.AddCell(_cell);
                                _cell = new Cell().Add(new Paragraph(item.NOMBRE)).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                _table.AddCell(_cell);
                                _cell = new Cell().Add(new Paragraph("$ " + item.PRECIO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                _table.AddCell(_cell);
                                _cell = new Cell().Add(new Paragraph(item.FECHA.ToString("dd/MM/yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                _table.AddCell(_cell);
                                if (item.TIPO == "Ingreso")
                                {
                                    _cell = new Cell().Add(new Paragraph("Ingreso"));
                                    _table.AddCell(_cell.AddStyle(style_cellI));

                                    NIng += 1;
                                    TIng += item.PRECIO;
                                    ST += item.PRECIO;
                                }
                                else
                                {
                                    _cell = new Cell().Add(new Paragraph("Egreso"));
                                    _table.AddCell(_cell.AddStyle(style_cellE));
                                    NEg += 1;
                                    TEg += item.PRECIO;
                                    ST -= item.PRECIO;
                                }
                            }
                            doc.Add(_table);
                        }
                        else
                        {
                            if (ckb_dia.IsChecked == false)
                            {
                                int mes = cmb_mes.SelectedIndex + 1;
                                List<Finanza> fi = fin.BusquedaTM(mes);

                                int x = 0;
                                foreach (var item in fi)
                                {
                                    x++;
                                    _cell = new Cell().Add(new Paragraph(x.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                    _table.AddCell(_cell);
                                    _cell = new Cell().Add(new Paragraph(item.NOMBRE)).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                    _table.AddCell(_cell);
                                    _cell = new Cell().Add(new Paragraph("$ " + item.PRECIO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                    _table.AddCell(_cell);
                                    _cell = new Cell().Add(new Paragraph(item.FECHA.ToString("dd/MM/yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                    _table.AddCell(_cell);
                                    if (item.TIPO == "Ingreso")
                                    {
                                        _cell = new Cell().Add(new Paragraph("Ingreso"));
                                        _table.AddCell(_cell.AddStyle(style_cellI));

                                        NIng += 1;
                                        TIng += item.PRECIO;
                                        ST += item.PRECIO;
                                    }
                                    else
                                    {
                                        _cell = new Cell().Add(new Paragraph("Egreso"));
                                        _table.AddCell(_cell.AddStyle(style_cellE));
                                        NEg += 1;
                                        TEg += item.PRECIO;
                                        ST -= item.PRECIO;
                                    }
                                }
                                doc.Add(_table);
                            }
                            else
                            {
                                int mes = cmb_mes.SelectedIndex + 1;
                                int dia = cmb_dia.SelectedIndex + 1;
                                List<Finanza> fi = fin.BusquedaTD(mes, dia);

                                int x = 0;
                                foreach (var item in fi)
                                {
                                    x++;
                                    _cell = new Cell().Add(new Paragraph(x.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                    _table.AddCell(_cell);
                                    _cell = new Cell().Add(new Paragraph(item.NOMBRE)).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                    _table.AddCell(_cell);
                                    _cell = new Cell().Add(new Paragraph("$ " + item.PRECIO.ToString())).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                    _table.AddCell(_cell);
                                    _cell = new Cell().Add(new Paragraph(item.FECHA.ToString("dd/MM/yyyy"))).SetTextAlignment(TextAlignment.CENTER).SetFontSize(12);
                                    _table.AddCell(_cell);
                                    if (item.TIPO == "Ingreso")
                                    {
                                        _cell = new Cell().Add(new Paragraph("Ingreso"));
                                        _table.AddCell(_cell.AddStyle(style_cellI));

                                        NIng += 1;
                                        TIng += item.PRECIO;
                                        ST += item.PRECIO;
                                    }
                                    else
                                    {
                                        _cell = new Cell().Add(new Paragraph("Egreso"));
                                        _table.AddCell(_cell.AddStyle(style_cellE));
                                        NEg += 1;
                                        TEg += item.PRECIO;
                                        ST -= item.PRECIO;
                                    }
                                }
                                doc.Add(_table);
                            }
                        }
                    }
                }

                Table table2 = new Table(2);
                Cell cell2 = new Cell(1,2).Add(new Paragraph(""))
                                        .SetFontSize(24)
                                        .SetTextAlignment(TextAlignment.LEFT)
                                        .SetBorder(Border.NO_BORDER);
                table2.AddCell(cell2);
                cell2 = new Cell(1,2).Add(new Paragraph("Resultado informe"))
                                        .SetFontSize(24)
                                        .SetTextAlignment(TextAlignment.LEFT)
                                        .SetBorder(Border.NO_BORDER);
                table2.AddCell(cell2);
                cell2 = new Cell(1,2).Add(new Paragraph(""))
                                        .SetFontSize(24)
                                        .SetTextAlignment(TextAlignment.LEFT)
                                        .SetBorder(Border.NO_BORDER);
                table2.AddCell(cell2);

                Style stileCell3 = new Style()
                    .SetFontSize(12)
                    .SetTextAlignment(TextAlignment.LEFT)
                    .SetBorder(Border.NO_BORDER);

                
                cell2 = new Cell().Add(new Paragraph("Número de Ingresos: "));
                table2.AddCell(cell2.AddStyle(stileCell3));
                cell2 = new Cell().Add(new Paragraph(NIng.ToString()));
                table2.AddCell(cell2.AddStyle(stileCell3));
                cell2 = new Cell().Add(new Paragraph("Total de Ingresos:  "));
                table2.AddCell(cell2.AddStyle(stileCell3));

                cell2 = new Cell().Add(new Paragraph("$ " + TIng.ToString()));
                table2.AddCell(cell2.AddStyle(stileCell3));
                cell2 = new Cell().Add(new Paragraph("Número de Egresos:  "));
                table2.AddCell(cell2.AddStyle(stileCell3));

                cell2 = new Cell().Add(new Paragraph(NEg.ToString()));
                table2.AddCell(cell2.AddStyle(stileCell3));
                cell2 = new Cell().Add(new Paragraph("Total de Egresos:   "));
                table2.AddCell(cell2.AddStyle(stileCell3));

                cell2 = new Cell().Add(new Paragraph("$ " + TEg.ToString()));
                table2.AddCell(cell2.AddStyle(stileCell3));
                cell2 = new Cell().Add(new Paragraph("Suma Total:         "));
                table2.AddCell(cell2.AddStyle(stileCell3));

                cell2 = new Cell().Add(new Paragraph("$ " + ST.ToString()));
                table2.AddCell(cell2.AddStyle(stileCell3));
                doc.Add(table2);
                table2.SetMarginBottom(10f);

                doc.Close();
                return true;
            }
            catch (Exception)
            {
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
                    .Add(new Paragraph("Reporte Estadística Turismo Real\n").SetFont(bold))
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
