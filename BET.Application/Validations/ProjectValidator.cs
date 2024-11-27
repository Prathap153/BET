using BET.Application.Contracts.IValidations;
using BET.Domain.Entities;
using CommunityToolkit.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BET.Application.Validations
{
    public class ProjectValidator : IProjectValidator
    {
        public void ValidateEntity(Project project)
        {
            Guard.IsNotNullOrWhiteSpace(project.Project_Name, nameof(project.Project_Name));
            Guard.IsNotNullOrWhiteSpace(project.Client_Name, nameof(project.Client_Name));
            Guard.IsNotNull(project.Bu_Id, nameof(project.Bu_Id));
            Guard.IsNotNull(project.Start_Date, nameof(project.Start_Date));
            Guard.IsNotNull(project.End_Date, nameof(project.End_Date));

            if (project.End_Date <= project.Start_Date)
            {
                throw new ArgumentException("End date should be greater than Start Date",nameof(project.End_Date));
            }
        }
    }
}
