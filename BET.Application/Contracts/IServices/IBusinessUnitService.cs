
namespace BET.Application.Contracts.IServices
{
    public interface IBusinessUnitService
    {
        Task<IEnumerable<BusinessUnit>> GetAllBusinessUnitAsync();
        Task<BusinessUnit> GetByIdBusinessUnitAsync(Guid id);
        Task<Guid> AddBusinessUnitAsync(BusinessUnit entity);
        Task UpdateBusinessUnitAsync(Guid id,BusinessUnit entity);
        Task DeleteBusinessUnitAsync(Guid id);
    }
}
