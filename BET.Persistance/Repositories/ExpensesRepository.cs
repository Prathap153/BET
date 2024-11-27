
using BET.Domain.BO;
using Microsoft.EntityFrameworkCore;

namespace BET.Persistance.Repositories
{
    public class ExpensesRepository : BaseRepository<Expenses>,IExpensesRepository
    {
        public ExpensesRepository(DataContext context):base(context){ }

        public async Task<Guid> AddExpensesAsync(Expenses entity)
        {
            await AddAsync(entity);
            return entity.Id;
        }

        public async Task DeleteExpensesAsync(Guid id)
        {
            await DeleteByIdAsync(id);
        }

        public async Task<IEnumerable<Expenses>> GetAllExpensesAsync()
        {
            return await GetAllAsync();
        }

        public async Task<Expenses> GetByIdExpensesAsync(Guid id)
        {
            return await GetByIdAsync(id);
        }

        public async Task UpdateExpensesAsync(Expenses entity)
        {
           await UpdateAsync(entity);
        }

        public async Task<IEnumerable<ExpensesBO>> GetAllByNames()
        {
            var res = await _context.expenses
                     .Join(_context.projects, e => e.Project_Id, p => p.Id,
                     (e, p) => new { Expenses = e, Project = p })
                     .Join(_context.category, ep => ep.Expenses.Category_Id, c => c.Id,
                      (ep, c) => new ExpensesBO
                      {
                          Id = ep.Expenses.Id,
                          ProjectName = ep.Project.Project_Name,
                          CategoryName = c.Name,
                          Amount = ep.Expenses.Amount,
                          Payment_Date = ep.Expenses.Payment_Date,
                          isActive = ep.Expenses.IsActive
                      }).ToListAsync();
            return res;
        }
    }
}
