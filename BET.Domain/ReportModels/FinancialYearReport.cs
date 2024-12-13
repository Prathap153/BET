
namespace BET.Domain.ReportModels
{
    public class FinancialYearReport
    {
        public string BuName { get; set; } = null!;
        public decimal Amount { get; set; }
        public DateTime PaymentMonth { get; set; }
    }
}
