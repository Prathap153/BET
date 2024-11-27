
namespace BET.Application.Contracts.IRepositories
{
    public interface IBusinessUnitRepository
    {
        Task<IEnumerable<BusinessUnit>> GetAllBusinessUnitAsync();
        Task<BusinessUnit> GetByIdBusinessUnitAsync(Guid id);
        Task<Guid> AddBusinessUnitAsync(BusinessUnit entity);
        Task UpdateBusinessUnitAsync(BusinessUnit entity);
        Task DeleteBusinessUnitAsync(Guid id);

    }
}
