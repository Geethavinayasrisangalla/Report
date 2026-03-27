using Microsoft.AspNetCore.Mvc;
using FarmManagement.Web.Services;

namespace FarmManagement.Web.Controllers
{
    public class ReportController : Controller
    {
        private readonly ReportService _reportService;

        public ReportController(ReportService reportService)
        {
            _reportService = reportService;
        }

        public IActionResult Index()
        {
            var reportData = _reportService.GetFieldWiseYieldReport();
            return View(reportData);
        }
    }
}
