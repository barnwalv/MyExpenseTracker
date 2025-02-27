using MyExpenseTracker.Models;

namespace MyExpenseTracker.Repositories
{
    public interface IExpenseRepository
    {
        //Get all expenses.
        Task<IEnumerable<Expense>> GetExpensesAsync();

        //Get expense by id.
        Task<Expense> GetExpenseByIdAsync(int id);

        //Add expense.
        Task AddExpenseAsync(Expense expense);

        //Update expense.
        Task UpdateExpenseAsync(Expense expense);

        //Delete expense.
        Task DeleteExpenseAsync(int id);

        //Get expenses by category.
        Task<IEnumerable<Expense>> GetExpensesByCategoryAsync(Categories category);

        //Get expenses by label.
        Task<IEnumerable<Expense>> GetExpensesByLabelAsync(Labels label);

        //Get expenses by date.
        Task<IEnumerable<Expense>> GetExpensesByMonthYearAsync(int month, int year);

    }
}
