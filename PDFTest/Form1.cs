using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MigraDoc;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;

//using PdfSharp;
//using PdfSharp.Drawing;
//using PdfSharp.Pdf;
//using PdfSharp.Pdf.IO;


namespace PDFTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            #region Migradoc
            Document document = new Document();
            Section section = document.AddSection();
            section.AddParagraph("Lorem ipsum dolor sit amet, consectetur");
            Paragraph paragraph = section.AddParagraph();
            paragraph.Format.Font.Color = MigraDoc.DocumentObjectModel.Color.FromCmyk(100, 30, 20, 50);
            paragraph.AddFormattedText("Hello, World", TextFormat.Underline);
            FormattedText ft = paragraph.AddFormattedText("Small text", TextFormat.Bold);
            ft.Font.Size = 6;
            Table table = section.AddTable();
            table.Borders.Width = 0.25;
            table.Rows.LeftIndent = 0;

            Column columnA = table.AddColumn("7cm");
            Column columnB = table.AddColumn("3cm");
            Column columnC = table.AddColumn("3cm");
            columnA.Format.Alignment = ParagraphAlignment.Center;
            Row row = table.AddRow();
            row.Cells[0].AddParagraph("Alarmtype");
            row.Cells[1].AddParagraph("Verdi");
            row.Cells[2].AddParagraph("Dato");

            PdfDocumentRenderer renderer = new PdfDocumentRenderer(false);
            renderer.Document = document;
            renderer.RenderDocument();
            string filename = "migradoc.pdf";
            renderer.PdfDocument.Save(filename);
            Process.Start(filename);
            #endregion
            
            /*
            #region PDF Sharp
            PdfDocument document = new PdfDocument();
            document.Info.Title = "Created with PDFSharp";

            PdfPage page = document.AddPage();

            XGraphics gfx = XGraphics.FromPdfPage(page);

            XFont font = new XFont("Verdana", 20, XFontStyle.BoldItalic);

            gfx.DrawString("Hei på deg!", font, XBrushes.Black,new XRect(0,0,page.Width,page.Height), XStringFormats.Center);

            const string filename = "HelloWorld.pdf";
            document.Save(filename);
            #endregion
            */
            
        }
    }
}
