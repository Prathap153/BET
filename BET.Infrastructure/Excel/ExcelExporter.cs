using BET.Application.Contracts.ExcelInfrastructure;
using BET.Domain.Entities;
using BET.Domain.ReportModels;
using ClosedXML.Excel;

namespace BET.Infrastructure.Excel
{
    public class ExcelExporter : IExcelExporter
    {
        public async Task<MemoryStream> GetBuFinancialYearExpenses(IEnumerable<FinancialYearReport> financialYearExpensesReport)
        {
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("financialYearExpensesReport");
            worksheet.Cell(1, 1).Value = "Business Unit";
            worksheet.Cell(1, 2).Value = "Amount";
            worksheet.Cell(1, 3).Value = "Payment Month";

            var row = 2;
            foreach (var expenses in financialYearExpensesReport)
            {
                worksheet.Cell(row, 1).Value = expenses.BuName;
                worksheet.Cell(row, 2).Value = expenses.Amount;
                worksheet.Cell(row, 3).Value = expenses.PaymentMonth;
                row++;
            }
            worksheet.Columns().AdjustToContents();
            worksheet.Rows().AdjustToContents();

            var stream = new MemoryStream();
            workbook.SaveAs(stream);
            stream.Position = 0;

            return stream;
        }

        public async Task<MemoryStream> GetMonthlyExpenses(IEnumerable<ExpensesReport> expensesReport)
        {
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("MonthlyExpenses");

            worksheet.Cell(1, 1).Value = "Business Unit";
            worksheet.Cell(1, 2).Value = "Project Name";
            worksheet.Cell(1, 3).Value = "Category Name";
            worksheet.Cell(1, 4).Value = "Amount";
            worksheet.Cell(1, 5).Value = "Payment Date";

            var row = 2;
            foreach (var expense in expensesReport)
            {
                worksheet.Cell(row, 1).Value = expense.BusinessUnitName;
                worksheet.Cell(row, 2).Value = expense.ProjectName;
                worksheet.Cell(row, 3).Value = expense.CategoryName;
                worksheet.Cell(row, 4).Value = expense.Amount;
                worksheet.Cell(row, 5).Value = expense.PaymentDate.ToString("yyyy-MM-dd"); ;
                row++;
            }
            worksheet.Columns().AdjustToContents();
            worksheet.Rows().AdjustToContents();
            var stream = new MemoryStream();
            workbook.SaveAs(stream);
            stream.Position = 0;
            return stream;
        }

        public async Task<MemoryStream> GetLedgerReport(IEnumerable<LedgerReport> ledgerReport)
        {
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("LedgerReport");

            worksheet.Cell(1, 1).Value = "Date";
            worksheet.Cell(1, 2).Value = "Business Unit";
            worksheet.Cell(1, 3).Value = "Income";
            worksheet.Cell(1, 4).Value = "Expenses";
            worksheet.Cell(1, 5).Value = "Balance";

            var row = 2;
            foreach (var ledger in ledgerReport)
            {
                worksheet.Cell(row, 1).Value = ledger.Date.ToString("yyyy-MM-dd");
                worksheet.Cell(row, 2).Value = ledger.BuName;
                worksheet.Cell(row, 3).Value = ledger.Income;
                worksheet.Cell(row, 4).Value = ledger.Expenses;
                worksheet.Cell(row, 5).Value = ledger.Balance;
                row++;
            }
            worksheet.Columns().AdjustToContents();
            worksheet.Rows().AdjustToContents();
            var stream = new MemoryStream();
            workbook.SaveAs(stream);
            stream.Position = 0;
            return stream;
        }
    }
}
