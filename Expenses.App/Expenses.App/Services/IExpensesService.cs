using Expenses.App.Models;

namespace Expenses.App.Services
{
    public interface IExpensesService
    {
        Task<List<Expense>> GetExpenses();
        Task AddExpenses(List<Expense> expense);
    }
}
