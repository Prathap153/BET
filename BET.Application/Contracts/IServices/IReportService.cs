using BET.Domain.ReportModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BET.Application.Contracts.IServices
{
    public interface IReportService
    {
        Task<MemoryStream> GetMonthlyExpenses(string BuName, int? month, int year);
        Task<MemoryStream> GetBuFinancialYearExpenses(string BuName, int year);
        Task<MemoryStream> GetLedgerReport(DateTime startDate, DateTime endDate);
    }
}
