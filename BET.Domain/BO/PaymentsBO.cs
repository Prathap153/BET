
using BET.Domain.Enum;

namespace BET.Domain.BO
{
    public class PaymentsBO
    {
        public Guid Id { get; set; }
        public string ProjectName { get; set; } = null!;
        public string CategoryName {  get; set; } = null!;
        public Decimal AmountGenerated {  get; set; }
        public DateTime PaymentDate { get; set; }
        public Status Status { get; set; }
        public bool isActive { get; set; }
    }
}
