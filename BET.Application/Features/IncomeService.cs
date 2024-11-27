
using BET.Domain.BO;

namespace BET.Application.Features
{
    public class IncomeService : IIncomeService
    {
        private readonly IIncomeRepository _incomeRepository;
        private readonly IIncomeValidator _incomeValidator;
        public IncomeService(IIncomeRepository incomeRepository, IIncomeValidator incomeValidator)
        {
            _incomeRepository = incomeRepository;
            _incomeValidator = incomeValidator;
        }
        public async Task<Guid> AddIncomeAsync(Income entity)
        {
           _incomeValidator.ValidateEntity(entity); 
           return  await _incomeRepository.AddIncomeAsync(entity);
        }

        public async Task DeleteIncomeAsync(Guid id)
        {
            await _incomeRepository.DeleteIncomeAsync(id);
        }

        public async Task<IEnumerable<Income>> GetAllIncomeAsync()
        {
            return await _incomeRepository.GetAllIncomeAsync();
        }

        public async Task<Income> GetByIdIncomeAsync(Guid id)
        {
            return await _incomeRepository.GetByIdIncomeAsync(id);
        }

        public async Task UpdateIncomeAsync(Income entity)
        {
            await _incomeRepository.UpdateIncomeAsync(entity);
        }
        
        public async Task<IEnumerable<IncomeBO>> GetAllByNames()
        {
            return await _incomeRepository.GetAllByNames();
        }
    }
}
