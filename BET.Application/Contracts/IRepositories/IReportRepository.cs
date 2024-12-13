using BET.Domain.ReportModels;

namespace BET.Application.Contracts.IRepositories
{
    public interface IReportRepository
    {
        Task<IEnumerable<ExpensesReport>> GetMonthlyExpenses(string BuName,int? month,int year);
        Task<IEnumerable<FinancialYearReport>> GetBuFinancialYearExpenses(string BuName, int year);
        Task<IEnumerable<LedgerReport>> GetLedgerReport(DateTime startDate, DateTime endDate);
    }
}
