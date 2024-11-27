using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BET.Domain.BO
{
    public class IncomeBO
    {
        public Guid Id { get; set; }
        public string ProjectName { get; set; } = null!;
        public string CategoryName { get; set; } = null!;
        public decimal Amount { get; set; }
        public DateTime Receive_Date { get; set; }
        public bool isActive { get; set; }
    }
}
