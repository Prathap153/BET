
using BET.Domain.BO;
using Microsoft.EntityFrameworkCore;

namespace BET.Persistance.Repositories
{
    public class IncomeRepository : BaseRepository<Income>,IIncomeRepository
    {
        public IncomeRepository(DataContext context):base(context) { }
  
        public async Task<Guid> AddIncomeAsync(Income entity)
        {
           await AddAsync(entity);
           return entity.Id;
        }

        public async Task DeleteIncomeAsync(Guid id)
        {
            await DeleteByIdAsync(id);
        }

        public async Task<IEnumerable<Income>> GetAllIncomeAsync()
        {
            return await GetAllAsync();
        }

        public async Task<Income> GetByIdIncomeAsync(Guid id)
        {
            return await GetByIdAsync(id);
        }

        public async Task UpdateIncomeAsync(Income entity)
        {
            await UpdateAsync(entity);
        }

        public async Task<IEnumerable<IncomeBO>> GetAllByNames()
        {
            var res = await _context.income
                      .Join(_context.projects, i => i.Project_Id, p => p.Id, (i, p) => new { Income = i, Project = p })
                      .Join(_context.category, ip => ip.Income.Category_Id, c => c.Id,
                         (ip, c) => new IncomeBO
                         {
                             Id = ip.Income.Id,
                             ProjectName = ip.Project.Project_Name,
                             CategoryName = c.Name,
                             Amount = ip.Income.Amount,
                             Receive_Date = ip.Income.Receive_Date,
                             isActive = ip.Income.IsActive
                         }).ToListAsync();
            return res;               
        }
    }
}
