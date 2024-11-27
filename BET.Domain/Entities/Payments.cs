using BET.Domain.Common.Base;
using BET.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BET.Domain.Entities
{
    public class Payments:BaseEntity
    {
        public Guid Bill_Id { get; set; }
        public DateTime Payment_Date { get; set; }
        public Status Status { get; set; }
    }
}
