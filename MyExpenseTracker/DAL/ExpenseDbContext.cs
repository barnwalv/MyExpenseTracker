using Microsoft.EntityFrameworkCore;
using MyExpenseTracker.Models;

namespace MyExpenseTracker.DAL
{
    public class ExpenseDbContext: DbContext
    {
        public ExpenseDbContext(DbContextOptions<ExpenseDbContext> options) : base(options)
        {
        }

        public DbSet<Expense> Expenses { get; set; }
    }
}
