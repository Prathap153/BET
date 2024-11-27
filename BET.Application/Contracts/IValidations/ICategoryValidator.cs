using BET.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BET.Application.Contracts.IValidations
{
    public interface ICategoryValidator
    {
        void ValidateEntity(Category category);
    }
}
