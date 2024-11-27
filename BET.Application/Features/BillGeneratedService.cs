
using BET.Domain.BO;

namespace BET.Application.Features
{
    public class BillGeneratedService : IBillGeneratedService
    {
        private readonly IBillGeneratedRepository _billGeneratedRepository;
        private readonly IBillGeneratedValidator _billGeneratedValidator;
        public BillGeneratedService(IBillGeneratedRepository billGeneratedRepository, IBillGeneratedValidator billGeneratedValidator)
        {
            _billGeneratedRepository = billGeneratedRepository;
            _billGeneratedValidator = billGeneratedValidator;
        }
        public async Task<Guid> AddBillGeneratedAsync(BillGenerated entity)
        {
            _billGeneratedValidator.ValidateEntity(entity);
            return await _billGeneratedRepository.AddBillGeneratedAsync(entity);
        }

        public async Task DeleteBillGeneratedAsync(Guid id)
        {
            await _billGeneratedRepository.DeleteBillGeneratedAsync(id);
        }

        public async Task<IEnumerable<BillGenerated>> GetAllBillGeneratedAsync()
        {
            return await _billGeneratedRepository.GetAllBillGeneratedAsync();  
        }

        public async Task<BillGenerated> GetByIdBillGeneratedAsync(Guid id)
        {
            return await _billGeneratedRepository.GetByIdBillGeneratedAsync(id);
        }

        public async Task UpdateBillGeneratedAsync(BillGenerated entity)
        {
            await _billGeneratedRepository.UpdateBillGeneratedAsync(entity);
        }

        public async Task<IEnumerable<BillGeneratedBO>> GetAllByNames()
        {
           return await _billGeneratedRepository.GetAllByNames();
        }
    }
}
