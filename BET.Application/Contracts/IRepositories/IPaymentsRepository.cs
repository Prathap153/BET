
using BET.Domain.BO;

namespace BET.Application.Contracts.IRepositories
{
    public interface IPaymentsRepository
    {
        Task<IEnumerable<Payments>> GetAllPaymentsAsync();
        Task<Payments> GetByIdPaymentsAsync(Guid id);
        Task<Guid> AddPaymentsAsync(Payments entity);
        Task UpdatePaymentsAsync(Payments entity);
        Task DeletePaymentsAsync(Guid id);
        Task<IEnumerable<PaymentsBO>> GetAllDetails();
     }
}
