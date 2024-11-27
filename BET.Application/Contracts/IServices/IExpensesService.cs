
using BET.Domain.BO;

namespace BET.Application.Contracts.IServices
{
    public interface IExpensesService
    {
        Task<IEnumerable<Expenses>> GetAllExpensesAsync();
        Task<Expenses> GetByIdExpensesAsync(Guid id);
        Task<Guid> AddExpensesAsync(Expenses entity);
        Task UpdateExpensesAsync(Expenses entity);
        Task DeleteExpensesAsync(Guid id);
        Task<IEnumerable<ExpensesBO>> GetAllByNames();
    }
}
