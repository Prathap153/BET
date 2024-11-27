
using BET.Domain.BO;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BET.Persistance.Repositories
{
    public class PaymentsRepository : BaseRepository<Payments>, IPaymentsRepository
    {
        public PaymentsRepository(DataContext context):base(context) { }
        
        public async Task<Guid> AddPaymentsAsync(Payments entity)
        {
            await AddAsync(entity);
            return entity.Id;
        }

        public async Task DeletePaymentsAsync(Guid id)
        {
            await DeleteByIdAsync(id);
        }

        public async Task<IEnumerable<Payments>> GetAllPaymentsAsync()
        {
            var result = await GetAllAsync();
            return result;
        }

        public async Task<Payments> GetByIdPaymentsAsync(Guid id)
        {
            return await GetByIdAsync(id);
        }

        public async Task UpdatePaymentsAsync(Payments entity)
        {
           await UpdateAsync(entity);
        }

        public async Task<IEnumerable<PaymentsBO>> GetAllDetails()
        {
            var result = await _context.payments
                                       .Join(_context.billGenerated, p => p.Bill_Id, b => b.Id, (p, b) => new { Payment = p, BillGenerate = b })
                                       .Join(_context.projects, pb => pb.BillGenerate.Project_Id, proj => proj.Id, (pb, proj) => new { pb.Payment, pb.BillGenerate, Project = proj })
                                       .Join(_context.category, pbp => pbp.BillGenerate.Category_Id, c => c.Id,
                                       (pbp, c) => new PaymentsBO
                                       {
                                           Id = pbp.Payment.Id,
                                           ProjectName = pbp.Project.Project_Name,
                                           CategoryName = c.Name,
                                           AmountGenerated = pbp.BillGenerate.Amount_Generated,
                                           PaymentDate = pbp.Payment.Payment_Date,
                                           Status = pbp.Payment.Status,
                                           isActive = pbp.Payment.IsActive,
                                       }).ToListAsync();
            return result;
        }
    }
}
