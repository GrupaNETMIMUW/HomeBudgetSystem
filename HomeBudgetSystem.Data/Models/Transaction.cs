namespace HomeBudgetSystem.Data.Models
{
    public class Transaction
    {
        public string Title { get; set; }
        public decimal Amount { get; set; }
        public string Owner { get; set; }
    }
}