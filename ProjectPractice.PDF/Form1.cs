using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
//using iText.Kernel.Pdf;
//using iText.Kernel.Pdf.Canvas.Parser;
//using iText.Layout.Element;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectPractice.PDF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //IText7ReadPDF();
            ReadPDF();
        }

        private void ReadPDF()
        {
            string fileContent = string.Empty;
            StringBuilder sbFileContent = new StringBuilder();
            PdfReader reader = null;

            //Table table = new Table(1, true);
            reader = new PdfReader(@"C:\Users\Administrator\Desktop\JG-05工程量表 Model (1).pdf");
            for (int i = 1; i <= reader.NumberOfPages; i++)
            {
                sbFileContent.AppendLine(PdfTextExtractor.GetTextFromPage(reader, i));
            }

            reader.Close();
            reader = null;
            //Regex objNotNumberPattern = new Regex("^P[0-9]");
            fileContent = sbFileContent.ToString();
            var x = fileContent.Split('\n');
            foreach (var item in x)
            {
                //if (objNotNumberPattern.IsMatch(item))
                //{
                    Console.WriteLine(item);
                //}
            }
        }

        public void ExtractPages(string sourcePdfPath, string outputPdfPath, int startPage, int endPage)
        {
            PdfReader reader = null;
            Document sourceDocument = null;
            PdfCopy pdfCopyProvider = null;
            PdfImportedPage importedPage = null;
            try
            {
                reader = new PdfReader(sourcePdfPath);
                sourceDocument = new Document(reader.GetPageSizeWithRotation(startPage)); 
                pdfCopyProvider = new PdfCopy(sourceDocument, new System.IO.FileStream(outputPdfPath, System.IO.FileMode.Create));
                sourceDocument.Open();
                for (int i = startPage; i <= endPage; i++)
                {
                    importedPage = pdfCopyProvider.GetImportedPage(reader, i); 
                    pdfCopyProvider.AddPage(importedPage);
                }
                sourceDocument.Close();
                reader.Close();
            }
            catch (Exception ex) { throw ex; }
        }

        private void IText7ReadPDF()
        {
            StringBuilder text = new StringBuilder();
            string fileName = @"C:\Users\Administrator\Desktop\巨力电梯x(3).pdf";
            if (File.Exists(fileName))
            {
                PdfReader pdfReader = new PdfReader(fileName);

                for (int page = 1; page <= pdfReader.NumberOfPages; page++)
                {
                    ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                    string currentText = PdfTextExtractor.GetTextFromPage(pdfReader, page, strategy);

                    currentText = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(currentText)));

                    //var res = ConvertToHebrew(currentText);
                    text.Append(currentText);
                }
                pdfReader.Close();
            }
            //var read = new iText.Kernel.Pdf.PdfReader(@"C:\Users\Administrator\Desktop\巨力电梯x(3).pdf");
            //var doc = new iText.Kernel.Pdf.PdfDocument(read);
            //StringBuilder sb = new StringBuilder();
            ////var info = doc.GetDocumentInfo();
            //for (int i = 1; i < doc.GetNumberOfPages(); i++)
            //{
            //    sb.Append(iText.Kernel.Pdf.Canvas.Parser.PdfTextExtractor.GetTextFromPage(doc.GetPage(i)));
            //}
            //div
            //doc.GetDocumentInfo().;
        }
    }
}
