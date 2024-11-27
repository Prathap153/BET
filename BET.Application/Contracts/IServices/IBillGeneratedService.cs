
using BET.Domain.BO;

namespace BET.Application.Contracts.IServices
{
    public interface IBillGeneratedService
    {
        Task<IEnumerable<BillGenerated>> GetAllBillGeneratedAsync();
        Task<BillGenerated> GetByIdBillGeneratedAsync(Guid id);
        Task<Guid> AddBillGeneratedAsync(BillGenerated entity);
        Task UpdateBillGeneratedAsync(BillGenerated entity);
        Task DeleteBillGeneratedAsync(Guid id);
        Task<IEnumerable<BillGeneratedBO>> GetAllByNames();
    }
}
