
using BET.Domain.BO;

namespace BET.Application.Features
{
    public class PaymentsService : IPaymentsService
    {
        private readonly IPaymentsRepository _paymentsRepository;
        private readonly IPaymentsValidator _paymentsValidator;
        public PaymentsService(IPaymentsRepository paymentsRepository, IPaymentsValidator paymentsValidator)
        {
            _paymentsRepository = paymentsRepository;
            _paymentsValidator = paymentsValidator;
        }

        public async Task<Guid> AddPaymentsAsync(Payments entity)
        {
            _paymentsValidator.ValidateEntity(entity);
           return await _paymentsRepository.AddPaymentsAsync(entity);
        }

        public async Task DeletePaymentsAsync(Guid id)
        {
            await _paymentsRepository.DeletePaymentsAsync(id);
        }

        public async Task<IEnumerable<Payments>> GetAllPaymentsAsync()
        {
            var result = await _paymentsRepository.GetAllPaymentsAsync();
            return result;
        }

        public async Task<Payments> GetByIdPaymentsAsync(Guid id)
        {
            return await _paymentsRepository.GetByIdPaymentsAsync(id);
        }

        public async Task UpdatePaymentsAsync(Payments entity)
        {
            await _paymentsRepository.UpdatePaymentsAsync(entity);
        }

        public async Task<IEnumerable<PaymentsBO>> GetAllDetails()
        {
            return await _paymentsRepository.GetAllDetails();
        }
    }
}
