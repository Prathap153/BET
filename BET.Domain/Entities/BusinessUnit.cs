using BET.Domain.Common.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BET.Domain.Entities
{
    public class BusinessUnit : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; } 
    }
}
