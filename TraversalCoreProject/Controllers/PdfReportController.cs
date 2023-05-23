using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace TraversalCoreProject.Controllers
{
    public class PdfReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StaticPdfReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfReports/" + "dosya1.pdf");
            var stream = new FileStream(path, FileMode.Create);

            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);

            document.Open();

            Paragraph paragraph = new Paragraph("Traversal Rezervasyon PDF Raporu");

            document.Add(paragraph);
            document.Close();

            return File("/pdfReports/dosya1.pdf", "application/pdf", "dosya1.pdf");
        }

        public IActionResult StaticCustomerReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfReports/" + "dosya2.pdf");
            var stream = new FileStream(path, FileMode.Create);

            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);

            document.Open();

            PdfPTable pdfPTable = new PdfPTable(3);

            pdfPTable.AddCell("Misafir Adı");
            pdfPTable.AddCell("Misafir Soyadı");
            pdfPTable.AddCell("Misafir TCKN");

            pdfPTable.AddCell("Furkan");
            pdfPTable.AddCell("Yavuz");
            pdfPTable.AddCell("11111111111");

            pdfPTable.AddCell("Umut");
            pdfPTable.AddCell("Yavuz");
            pdfPTable.AddCell("11111111110");

            pdfPTable.AddCell("Enner");
            pdfPTable.AddCell("Valencia");
            pdfPTable.AddCell("11111111112");


            document.Add(pdfPTable);
            document.Close();

            return File("/pdfReports/dosya2.pdf", "application/pdf", "dosya2.pdf");
        }
    }
}
