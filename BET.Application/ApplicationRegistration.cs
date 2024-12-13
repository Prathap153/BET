using BET.Application.Contracts.IServices;
using BET.Application.Contracts.IValidations;
using BET.Application.Features;
using BET.Application.Validations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BET.Application
{
    public static class ApplicationRegistration
    {
        public static void AddApplicationService(this IServiceCollection services)
        {
            services.AddScoped<IBusinessUnitService, BusinessUnitService>();
            services.AddScoped<IBusinessUnitValidator, BusinessUnitValidator>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryValidator, CategoryValidator>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IProjectValidator, ProjectValidator>();
            services.AddScoped<IBillGeneratedService, BillGeneratedService>();
            services.AddScoped<IBillGeneratedValidator, BillGeneratedValidator>();
            services.AddScoped<IIncomeService, IncomeService>();
            services.AddScoped<IIncomeValidator, IncomeValidator>();
            services.AddScoped<IExpensesService, ExpensesService>();
            services.AddScoped<IExpensesValidator, ExpensesValidator>();
            services.AddScoped<IPaymentsService, PaymentsService>();
            services.AddScoped<IPaymentsValidator, PaymentsValidator>();
            services.AddScoped<IReportService, ReportService>();
        }
    }
}
