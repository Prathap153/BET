namespace BET.Domain.ReportModels
{
    public class LedgerReport
    {
        public DateTime Date { get; set; }
        public string BuName { get; set; } = null!;
        public decimal? Income { get; set; } 
        public decimal? Expenses { get; set; }
        public decimal Balance { get; set; }

    }
}
