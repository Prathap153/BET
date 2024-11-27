
using BET.Domain.BO;
using Microsoft.EntityFrameworkCore;

namespace BET.Persistance.Repositories
{
    public class BillGeneratedRepository : BaseRepository<BillGenerated>,IBillGeneratedRepository
    {
        public BillGeneratedRepository(DataContext context) : base(context) { }
    
        public async Task<Guid> AddBillGeneratedAsync(BillGenerated entity)
        {
            await AddAsync(entity);
            return entity.Id;
        }

        public async Task DeleteBillGeneratedAsync(Guid id)
        {
            await DeleteByIdAsync(id);
        }

        public async Task<IEnumerable<BillGenerated>> GetAllBillGeneratedAsync()
        {
            return await GetAllAsync();
        }

        public async Task<BillGenerated> GetByIdBillGeneratedAsync(Guid id)
        {
            return await GetByIdAsync(id);
        }

        public async Task UpdateBillGeneratedAsync(BillGenerated entity)
        {
            await UpdateAsync(entity);
        }

        public async Task<IEnumerable<BillGeneratedBO>> GetAllByNames()
        {
            var result = await (from b in _context.billGenerated
                             join p in _context.projects on b.Project_Id equals p.Id
                             join c in _context.category on b.Category_Id equals c.Id
                             select new BillGeneratedBO
                             {
                                 Id = b.Id,
                                 ProjectName = p.Project_Name,
                                 CategoryName = c.Name,
                                 Amount_Generated = b.Amount_Generated,
                                 Due_Date = b.Due_Date,
                                 isActive = b.IsActive
                             }).ToListAsync();
            return result;
        }
    }
}
