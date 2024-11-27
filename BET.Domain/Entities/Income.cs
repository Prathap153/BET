using BET.Domain.Common.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BET.Domain.Entities
{
    public class Income:BaseEntity
    {
        public Guid Project_Id { get; set; }
        public Guid Category_Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Receive_Date { get; set; }

    }
}
