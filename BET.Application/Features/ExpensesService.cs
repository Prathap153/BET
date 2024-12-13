
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

        public async Task UpdateExpensesAsync(Guid id,Expenses entity)
        {
            var res = await _expensesRepository.GetByIdExpensesAsync(id);
            if (res!= null)
            {
                res.Project_Id = entity.Project_Id;
                res.Category_Id = entity.Category_Id;
                res.Amount = entity.Amount;
                res.ModifiedBy = "User2";
                res.ModifiedOn = DateTime.Now;
                res.IsActive = entity.IsActive;
                await _expensesRepository.UpdateExpensesAsync(res);
            }
        }

        public async Task<IEnumerable<ExpensesBO>> GetAllByNames()
        {
           return await _expensesRepository.GetAllByNames();
        }
    }
}
