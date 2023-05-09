using Blazored.LocalStorage;
using Expenses.App.Models;
using System.Text.Json;

namespace Expenses.App.Services
{
    public class ExpensesService : IExpensesService
    {
        private readonly ILocalStorageService _localStorageService;
        public ExpensesService(ILocalStorageService localStorageService) 
        { 
            _localStorageService = localStorageService;
        }

        private string expensesLocalStorageKey => "expensekey";

        public async Task<List<Expense>> GetExpenses()
        {
            var expenseJson = await _localStorageService.GetItemAsync<string>(expensesLocalStorageKey);

            if (string.IsNullOrWhiteSpace(expenseJson))
                return new();

            return JsonSerializer.Deserialize<List<Expense>>(expenseJson);
        }

        public async Task AddExpenses(List<Expense> expense)
        {
            var expensesJson = JsonSerializer.Serialize(expense);
            await _localStorageService.SetItemAsync(expensesLocalStorageKey, expensesJson);
        }
    }
}
