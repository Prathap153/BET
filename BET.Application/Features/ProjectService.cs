
using BET.Domain.BO;

namespace BET.Application.Features
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IProjectValidator _projectValidator;
        public ProjectService(IProjectRepository projectRepository, IProjectValidator projectValidator)
        {
            _projectRepository = projectRepository;
            _projectValidator = projectValidator;
        }
        public async Task<Guid> AddProjectAsync(Project entity)
        {
            _projectValidator.ValidateEntity(entity);
            return await _projectRepository.AddProjectAsync(entity);
        }

        public async Task DeleteProjectAsync(Guid id)
        {
            await _projectRepository.DeleteProjectAsync(id);
        }

        public async Task<IEnumerable<Project>> GetAllProjectAsync()
        {
            return await _projectRepository.GetAllProjectAsync();
        }

        public async Task<Project> GetByIdProjectAsync(Guid id)
        {
            return await _projectRepository.GetByIdProjectAsync(id);
        }

        public async Task UpdateProjectAsync(Project entity)
        {
            await _projectRepository.UpdateProjectAsync(entity);
        }

        public async Task<IEnumerable<ProjectBO>> GetAllDetails()
        {
            return await _projectRepository.GetAllDetails();
        }
    }
}
