
namespace BET.Domain.BO
{
    public class ProjectBO
    {
        public Guid Id { get; set; }
        public string BUName { get; set; } = null!;
        public string Project_Name { get; set; } = null!;
        public string Client_Name { get; set; } = null!;
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public bool isActive { get; set; }
    }
}
