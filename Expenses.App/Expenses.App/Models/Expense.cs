namespace Expenses.App.Models
{
    public class Expense
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public double Value { get; set; }
    }
}
