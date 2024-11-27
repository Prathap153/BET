
using BET.Domain.BO;

namespace BET.Application.Contracts.IRepositories
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetAllProjectAsync();
        Task<Project> GetByIdProjectAsync(Guid id);
        Task<Guid> AddProjectAsync(Project entity);
        Task UpdateProjectAsync(Project entity);
        Task DeleteProjectAsync(Guid id);
        Task<IEnumerable<ProjectBO>> GetAllDetails();
    }
}
