using Microsoft.EntityFrameworkCore;
using MyExpenseTracker.DAL;
using MyExpenseTracker.Models;

namespace MyExpenseTracker.Repositories.Implementations
{
    public class ExpenseRepository : IExpenseRepository
    {
        // Database context.
        private readonly ExpenseDbContext _dbContext;

        // Constructor.
        public ExpenseRepository(ExpenseDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddExpenseAsync(Expense expense)
        {
            _dbContext.Expenses.Add(expense);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateExpenseAsync(Expense expense)
        {
            var exp = await _dbContext.Expenses.FindAsync(expense.Id);
            if (exp != null)
            {
                exp.Amount = expense.Amount;
                exp.Description = expense.Description;
                exp.Category = expense.Category;
                exp.Label = expense.Label;
                exp.Date = expense.Date;

                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteExpenseAsync(int id)
        {
            var expense = await _dbContext.Expenses.FindAsync(id);
            if (expense != null)
            {
                _dbContext.Expenses.Remove(expense);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<Expense> GetExpenseByIdAsync(int id)
        {
            var expense = await _dbContext.Expenses.FindAsync(id);
            return expense;
        }

        public async Task<IEnumerable<Expense>> GetExpensesAsync()
        {
            return await _dbContext.Expenses.ToListAsync();
        }

        public async Task<IEnumerable<Expense>> GetExpensesByCategoryAsync(Categories category)
        {
            throw new NotImplementedException();
        }

        
        public async Task<IEnumerable<Expense>> GetExpensesByLabelAsync(Labels label)
        {
            var expenses = await _dbContext.Expenses.Where(e => e.Label == label).ToListAsync();
            return expenses;
        }

        public async Task<IEnumerable<Expense>> GetExpensesByMonthYearAsync(int month, int year)
        {
            var expenses = await _dbContext.Expenses.Where(e => e.Date.Month == month && e.Date.Year == year).ToListAsync();
            return expenses;
        }
    }
}
