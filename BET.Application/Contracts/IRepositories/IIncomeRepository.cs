
using BET.Domain.BO;

namespace BET.Application.Contracts.IRepositories
{
    public interface IIncomeRepository
    {
        Task<IEnumerable<Income>> GetAllIncomeAsync();
        Task<Income> GetByIdIncomeAsync(Guid id);
        Task<Guid> AddIncomeAsync(Income entity);
        Task UpdateIncomeAsync(Income entity);
        Task DeleteIncomeAsync(Guid id);
        Task<IEnumerable<IncomeBO>> GetAllByNames();
    }
}
