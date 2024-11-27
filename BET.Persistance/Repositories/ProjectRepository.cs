
using BET.Domain.BO;
using Microsoft.EntityFrameworkCore;

namespace BET.Persistance.Repositories
{
    public class ProjectRepository : BaseRepository<Project>,IProjectRepository
    {
        public ProjectRepository(DataContext context):base(context) { }
        public async Task<Guid> AddProjectAsync(Project entity)
        {
            await AddAsync(entity);
            return entity.Id;
        }

        public async Task DeleteProjectAsync(Guid id)
        {
            await DeleteByIdAsync(id);
        }

        public async Task<IEnumerable<Project>> GetAllProjectAsync()
        {
            return await GetAllAsync();
        }

        public async Task<Project> GetByIdProjectAsync(Guid id)
        {
            return await GetByIdAsync(id);
        }

        public async Task UpdateProjectAsync(Project entity)
        {
            await UpdateAsync(entity);
        }

        public async Task<IEnumerable<ProjectBO>> GetAllDetails()
        {
            var res = await (from p in _context.projects
                             join bu in _context.businessUnit on p.Bu_Id equals bu.Id
                             select new ProjectBO
                             {
                                 Id = p.Id,
                                 BUName = bu.Name,
                                 Project_Name = p.Project_Name,
                                 Client_Name = p.Client_Name,
                                 Start_Date = p.Start_Date,
                                 End_Date = p.End_Date,
                                 isActive = p.IsActive
                             }).ToListAsync();
            return res;
        }
    }
}
