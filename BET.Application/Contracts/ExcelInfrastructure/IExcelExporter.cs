using BET.Domain.ReportModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BET.Application.Contracts.ExcelInfrastructure
{
    public interface IExcelExporter
    {
        Task<MemoryStream> GetMonthlyExpenses(IEnumerable<ExpensesReport> expensesReport);
        Task<MemoryStream> GetBuFinancialYearExpenses(IEnumerable<FinancialYearReport> financialYearReport);
        Task<MemoryStream> GetLedgerReport(IEnumerable<LedgerReport> ledgerReport);
    }
}
