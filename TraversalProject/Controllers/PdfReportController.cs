using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System.IO;

namespace TraversalProject.Controllers
{
    public class PdfReportController : Controller
    {
        // pdf dosyası olarak indirmek için kullanılan kütüphane: iTextSharp.LGPLv2.Core
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult StaticPdfReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfreports/"+"dosya1.pdf");
            var stream = new FileStream(path, FileMode.Create);

            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);

            document.Open();
            Paragraph paragraph = new Paragraph("Traversal Rezervasyon Pdf Raporu");
            document.Add(paragraph);
            document.Close();

            return File("/pdfreports/dosya1.pdf","application/pdf","dosya1.pdf");
        }
        public IActionResult StaticCustomerReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfreports/" + "dosya4.pdf");
            var stream = new FileStream(path, FileMode.Create);

            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);

            document.Open();

            PdfPTable pdfPTable = new PdfPTable(3);  // 3 sütunlu

            pdfPTable.AddCell("Misafir Adı");
            pdfPTable.AddCell("Misafir Soyadı");
            pdfPTable.AddCell("Misafir TC");

            pdfPTable.AddCell("Büşra");
            pdfPTable.AddCell("Özdemir");
            pdfPTable.AddCell("77777777777");

            pdfPTable.AddCell("Samet");
            pdfPTable.AddCell("Sarıkaya");
            pdfPTable.AddCell("55555555555");

            pdfPTable.AddCell("Elif");
            pdfPTable.AddCell("Yılmaz");
            pdfPTable.AddCell("44444444444");

            document.Add(pdfPTable);

            document.Close();

            return File("/pdfreports/dosya4.pdf", "application/pdf", "dosya4.pdf");
        }
    }
}
