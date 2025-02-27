
using MyExpenseTracker.DAL;

namespace MyExpenseTracker.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ExpenseDbContext _dbContext;
        public IExpenseRepository ExpenseRepository { get; private set; }

        public UnitOfWork(ExpenseDbContext dbContext)
        {
            _dbContext = dbContext;
            ExpenseRepository = new ExpenseRepository(_dbContext);
        }

        public async Task<int> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
