
namespace BET.Persistance.Repositories
{
    public class BusinessUnitRepository : BaseRepository<BusinessUnit>, IBusinessUnitRepository
    {
        public BusinessUnitRepository(DataContext context) : base(context) { }

        public async Task<Guid> AddBusinessUnitAsync(BusinessUnit entity) 
        {
            await AddAsync(entity);
            return entity.Id;
        }

        public async Task DeleteBusinessUnitAsync(Guid id) 
        {
            await DeleteByIdAsync(id);
        }

        public async Task<IEnumerable<BusinessUnit>> GetAllBusinessUnitAsync() 
        {
            return await GetAllAsync();
        }

        public async Task<BusinessUnit> GetByIdBusinessUnitAsync(Guid id) 
        {
            return await GetByIdAsync(id);
        }

        public async Task UpdateBusinessUnitAsync(BusinessUnit entity) 
        {
            await UpdateAsync(entity);
        }

    }

}
