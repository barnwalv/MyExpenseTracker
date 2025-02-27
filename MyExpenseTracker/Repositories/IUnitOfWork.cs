namespace MyExpenseTracker.Repositories
{
    public interface IUnitOfWork 
    {
        IExpenseRepository ExpenseRepository { get; }

        Task<int> SaveAsync();
    }
}
