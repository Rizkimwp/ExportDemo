using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using Rotativa.AspNetCore;


namespace ExportDemo.Controllers
{
    public class ExportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DownloadPdf()
        {
            
            return new ViewAsPdf("PdfTemplate")
            {
                FileName = "Laporan.pdf",
                PageSize = Rotativa.AspNetCore.Options.Size.A4
            };
        }

        public IActionResult DownloadExcel()
        {
            using var package = new ExcelPackage();
            var worksheet = package.Workbook.Worksheets.Add("Laporan");
            worksheet.Cells["A1"].Value = "Nama";
            worksheet.Cells["B1"].Value = "Tanggal";
            worksheet.Cells["A2"].Value = "Contoh Excel";
            worksheet.Cells["B2"].Value = DateTime.Now.ToString("yyyy-MM-dd");

            var excelBytes = package.GetAsByteArray();

            return File(excelBytes, 
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", 
                "Laporan.xlsx");
        }
    }
}
