using DocumentFormat.OpenXml.Bibliography;
using Microsoft.AspNetCore.Authorization;

namespace BET.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;
        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }
        [HttpGet("getMonthlyExpenses/{buName}")]
        public async Task<IActionResult> GetMonthlyExpensesReport(string buName, int? month, int year)
        {
            var stream = await _reportService.GetMonthlyExpenses(buName, month, year);
            string fileName = month.HasValue
                      ? $"MonthlyReport-{DateTime.UtcNow:dd-MM-yy-HH-mm}.xlsx"
                      : $"YearlyReport-{DateTime.UtcNow:dd-MM-yy-HH-mm}.xlsx";
            return File(stream.GetBuffer(), "application/octet-stream", fileName);
        }

        [HttpGet("getBuFinancialYearExpenses/{buName}")]
        public async Task<IActionResult> GetBuFinancialYearExpenses(string buName, int year)
        {
            var stream = await _reportService.GetBuFinancialYearExpenses(buName, year);
            string fileName = $"Financial_{buName}_{year}.xlsx";
            return File(stream.GetBuffer(), "application/octet-stream", fileName);
        }

        [HttpGet("ledger-report")]
        public async Task<IActionResult> GetLedgerReport(DateTime startDate,DateTime endDate)
        {
            var stream = await _reportService.GetLedgerReport(startDate, endDate);
            string fileName = $"Ledger_{startDate}_{endDate}.xlsx";
            return File(stream.GetBuffer(), "application/octet-stream", fileName);
        }
    }
}
