
using BET.Domain.BO;

namespace BET.Application.Features
{
    public class ExpensesService : IExpensesService
    {
        private readonly IExpensesRepository _expensesRepository;
        private readonly IExpensesValidator _expensesValidator;
        public ExpensesService(IExpensesRepository expensesRepository, IExpensesValidator expensesValidator)
        {
            _expensesRepository = expensesRepository;
            _expensesValidator = expensesValidator;
        }
        public async Task<Guid> AddExpensesAsync(Expenses entity)
        {
           _expensesValidator.ValidateEntity(entity);
           return await _expensesRepository.AddExpensesAsync(entity);           
        }

        public async Task DeleteExpensesAsync(Guid id)
        {
            await _expensesRepository.DeleteExpensesAsync(id);
        }

        public async Task<IEnumerable<Expenses>> GetAllExpensesAsync()
        {
            return await _expensesRepository.GetAllExpensesAsync();
        }

        public async Task<Expenses> GetByIdExpensesAsync(Guid id)
        {
            return await _expensesRepository.GetByIdExpensesAsync(id);
        }

        public async Task UpdateExpensesAsync(Expenses entity)
        {
            await _expensesRepository.UpdateExpensesAsync(entity);
        }

        public async Task<IEnumerable<ExpensesBO>> GetAllByNames()
        {
           return await _expensesRepository.GetAllByNames();
        }
    }
}
