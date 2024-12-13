using BET.Application.Contracts.ExcelInfrastructure;
using BET.Application.Contracts.IServices;
using BET.Application.Features;
using BET.Infrastructure.Excel;
using BET.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BET.Persistance
{
    public static class PersistanceRegistration
    {
        public static void AddPersistanceService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<Infrastructure.DBConnection.DataContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IBusinessUnitRepository,BusinessUnitRepository>();
            services.AddScoped<ICategoryRepository,CategoryRepository>();
            services.AddScoped<IProjectRepository,ProjectRepository>();
            services.AddScoped<IBillGeneratedRepository,BillGeneratedRepository>();
            services.AddScoped<IIncomeRepository,IncomeRepository>();
            services.AddScoped<IExpensesRepository,ExpensesRepository>();
            services.AddScoped<IPaymentsRepository,PaymentsRepository>();
            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddScoped<IExcelExporter,ExcelExporter>();
        }
    }
}
