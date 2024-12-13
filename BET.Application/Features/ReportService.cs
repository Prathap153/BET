using BET.Application.Contracts.ExcelInfrastructure;
using BET.Domain.ReportModels;

namespace BET.Application.Features
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;
        private readonly IExcelExporter _excelExporter;
        public ReportService(IReportRepository reportRepository,IExcelExporter excelExporter)
        {
            _reportRepository = reportRepository;
            _excelExporter = excelExporter;
        }

        public async Task<MemoryStream> GetBuFinancialYearExpenses(string BuName, int year)
        {
            var BuFinYearExpenses = await _reportRepository.GetBuFinancialYearExpenses(BuName, year);
            return await _excelExporter.GetBuFinancialYearExpenses(BuFinYearExpenses);
        }

        public async Task<MemoryStream> GetMonthlyExpenses(string buName, int? month, int year)
        {
            var expenses = await _reportRepository.GetMonthlyExpenses(buName, month, year);
            return await _excelExporter.GetMonthlyExpenses(expenses);
        }

        public async Task<MemoryStream> GetLedgerReport(DateTime startDate, DateTime endDate)
        {
            var ledger = await _reportRepository.GetLedgerReport(startDate, endDate);
            return await _excelExporter.GetLedgerReport(ledger);
        }

    }
}
