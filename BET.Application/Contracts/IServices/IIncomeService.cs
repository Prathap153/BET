
using BET.Domain.BO;

namespace BET.Application.Contracts.IServices
{
    public interface IIncomeService
    {
        Task<IEnumerable<Income>> GetAllIncomeAsync();
        Task<Income> GetByIdIncomeAsync(Guid id);
        Task<Guid> AddIncomeAsync(Income entity);
        Task UpdateIncomeAsync(Income entity);
        Task DeleteIncomeAsync(Guid id);
        Task<IEnumerable<IncomeBO>> GetAllByNames();
    }
}
