
using BET.Application.Contracts.IRepositories;
using BET.Domain.BO;
using BET.Domain.Entities;

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

        public async Task UpdateBillGeneratedAsync(Guid id,BillGenerated  entity)
        {

            var getByBill = await _billGeneratedRepository.GetByIdBillGeneratedAsync(id);
            if (getByBill != null)
            {
                getByBill.Project_Id = entity.Project_Id;
                getByBill.Category_Id = entity.Category_Id;
                getByBill.Amount_Generated = entity.Amount_Generated;
                getByBill.ModifiedOn = DateTime.Now;
                getByBill.ModifiedBy = "User2";
                getByBill.IsActive = entity.IsActive;
                await _billGeneratedRepository.UpdateBillGeneratedAsync(getByBill);
            }
        }

        public async Task<IEnumerable<BillGeneratedBO>> GetAllByNames()
        {
           return await _billGeneratedRepository.GetAllByNames();
        }
    }
}
