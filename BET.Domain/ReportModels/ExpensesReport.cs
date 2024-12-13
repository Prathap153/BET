using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BET.Domain.ReportModels
{
    public class ExpensesReport
    {
        public string BusinessUnitName { get; set; } = null!;
        public string ProjectName { get; set; } = null!;
        public string CategoryName { get; set; } = null!;
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
