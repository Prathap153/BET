using BET.Domain.ReportModels;
using Microsoft.EntityFrameworkCore;

namespace BET.Persistance.Repositories
{
    public class ReportRepository : BaseRepository<ExpensesReport>, IReportRepository
    {
        public ReportRepository(DataContext context) : base(context) { }
        public async Task<IEnumerable<ExpensesReport>> GetMonthlyExpenses(string buName, int? month, int year)
        {
            var res = await (from e in _context.expenses
                             join p in _context.projects on e.Project_Id equals p.Id
                             join bu in _context.businessUnit on p.Bu_Id equals bu.Id
                             join c in _context.category on e.Category_Id equals c.Id
                             where bu.Name == buName
                                  && e.Payment_Date.Year == year
                                  && (!month.HasValue || e.Payment_Date.Month == month)
                             orderby e.Payment_Date descending
                             select new ExpensesReport
                             {
                                 BusinessUnitName = bu.Name,
                                 ProjectName = p.Project_Name,
                                 CategoryName = c.Name,
                                 Amount = e.Amount,
                                 PaymentDate = e.Payment_Date
                             }).ToListAsync();
            return res;
        }

        public async Task<IEnumerable<FinancialYearReport>> GetBuFinancialYearExpenses(string buName, int year)
        {
            DateTime startDate = new DateTime(year, 4, 1);
            DateTime endDate = new DateTime(year + 1, 3, 31);

            var res = await (from e in _context.expenses
                             join p in _context.projects on e.Project_Id equals p.Id
                             join bu in _context.businessUnit on p.Bu_Id equals bu.Id
                             join c in _context.category on e.Category_Id equals c.Id
                             where e.Payment_Date >= startDate && e.Payment_Date <= endDate
                                   && bu.Name == buName
                             group e by new
                             {
                                 Year = e.Payment_Date.Year,
                                 Month = e.Payment_Date.Month
                             } into g
                             orderby g.Key.Month
                             select new FinancialYearReport
                             {
                                 BuName = buName,
                                 Amount = g.Sum(e => e.Amount),
                                 PaymentMonth = new DateTime(g.Key.Year, g.Key.Month, 1)
                             }).ToListAsync();

            return res;
        }

        public async Task<IEnumerable<LedgerReport>> GetLedgerReport(DateTime startDate, DateTime endDate)
        {
            var expensesList = from e in _context.expenses
                               where e.Payment_Date.Date >= startDate.Date && e.Payment_Date.Date <= endDate.Date
                               join p in _context.projects on e.Project_Id equals p.Id
                               join bu in _context.businessUnit on p.Bu_Id equals bu.Id
                               select new
                               {
                                   Date = e.Payment_Date,
                                   Amount = e.Amount,
                                   BuName = bu.Name,
                                   IsExpense = true
                               };

            var incomeList = from i in _context.income
                             where i.Receive_Date.Date >= startDate.Date && i.Receive_Date.Date <= endDate.Date
                             join p in _context.projects on i.Project_Id equals p.Id
                             join bu in _context.businessUnit on p.Bu_Id equals bu.Id
                             select new
                             {
                                 Date = i.Receive_Date,
                                 Amount = i.Amount,
                                 BuName = bu.Name,
                                 IsExpense = false
                             };

            var result = await expensesList.Concat(incomeList)
                         .GroupBy(x => new { x.Date, x.BuName })
                         .Select(g => new
                         {
                             Date = g.Key.Date,
                             BuName = g.Key.BuName,
                             IncomeAmount = g.Where(x => !x.IsExpense).Sum(x => x.Amount),
                             ExpenseAmount = g.Where(x => x.IsExpense).Sum(x => x.Amount),
                         })
                         .OrderBy(x=>x.Date)
                         .ToListAsync();

            var totalIncomeBeforeDate = await (from i in _context.income
                                              where i.Receive_Date.Date < startDate
                                        select i.Amount).SumAsync();

            var totalExpenseBeforeDate = await (from i in _context.income
                                                where i.Receive_Date < startDate
                                                select i.Amount).SumAsync();

            var openingBalance = totalIncomeBeforeDate - totalExpenseBeforeDate;

            var currentBalance = openingBalance;

            var ledgerReport = result.Select(x=> new LedgerReport
            {
                Date = x.Date,
                BuName= x.BuName,
                Income = x.IncomeAmount == 0 ? null : x.IncomeAmount, 
                Expenses = x.ExpenseAmount == 0 ? null : x.ExpenseAmount,
                Balance = (currentBalance += (x.IncomeAmount-x.ExpenseAmount))
            }).ToList();

            ledgerReport.Insert(0, new LedgerReport
            {
                Date = startDate,
                BuName = "Opening Balance",
                Income = null,
                Expenses = null,
                Balance = openingBalance
            });

            ledgerReport.Add(new LedgerReport
            {
                Date = endDate,
                BuName = "Closing Balance",
                Income = null,
                Expenses = null,
                Balance = currentBalance
            });

            return ledgerReport;
        }
    }
}
