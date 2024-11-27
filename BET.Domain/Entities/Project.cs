using BET.Domain.Common.Base;


namespace BET.Domain.Entities
{
    public class Project:BaseEntity
    {
        public Guid Bu_Id { get; set; }
        public string Project_Name { get; set; } = null!;
        public string Client_Name { get; set; } = null!;
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
    }
}
