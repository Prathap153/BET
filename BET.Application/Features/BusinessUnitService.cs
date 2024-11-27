

namespace BET.Application.Features
{
    public class BusinessUnitService : IBusinessUnitService
    {
        private readonly IBusinessUnitRepository _businessUnitRepository;
        private readonly IBusinessUnitValidator _businessUnitValidator;
        public BusinessUnitService(IBusinessUnitRepository businessUnitRepository, IBusinessUnitValidator businessUnitValidator)
        {
            _businessUnitRepository = businessUnitRepository;
            _businessUnitValidator = businessUnitValidator;
        }

        public async Task<Guid> AddBusinessUnitAsync(BusinessUnit entity)
        {
            _businessUnitValidator.ValidateEntity(entity);
            return  await _businessUnitRepository.AddBusinessUnitAsync(entity);
        }

        public async Task DeleteBusinessUnitAsync(Guid id)
        {
            await _businessUnitRepository.DeleteBusinessUnitAsync(id);
        }

        public async Task<IEnumerable<BusinessUnit>> GetAllBusinessUnitAsync()
        {
            return await _businessUnitRepository.GetAllBusinessUnitAsync();
        }

        public async Task<BusinessUnit> GetByIdBusinessUnitAsync(Guid id)
        {
            return await _businessUnitRepository.GetByIdBusinessUnitAsync(id);
        }

        public async Task UpdateBusinessUnitAsync(Guid id, BusinessUnit entity)
        {
            var business = await _businessUnitRepository.GetByIdBusinessUnitAsync(id);
            if (business != null)
            {
               business.Name = entity.Name;
               business.Description = entity.Description;
               business.IsActive = entity.IsActive;
               business.ModifiedOn  = DateTime.Now;
               business.ModifiedBy = "User1";
               await _businessUnitRepository.UpdateBusinessUnitAsync(business);
            }
        }
    }
}
