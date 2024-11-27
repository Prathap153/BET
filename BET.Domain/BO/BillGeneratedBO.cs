
namespace BET.Domain.BO
{
    public class BillGeneratedBO
    {
        public Guid Id { get; set; } 
        public string ProjectName { get; set; } = null!;
        public string CategoryName { get; set; } = null!;
        public decimal Amount_Generated { get; set; }
        public DateTime Due_Date { get; set; }
        public bool isActive { get; set; }

    }
}
