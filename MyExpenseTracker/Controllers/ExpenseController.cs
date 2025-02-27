using Microsoft.AspNetCore.Mvc;
using MyExpenseTracker.DAL;
using MyExpenseTracker.Models;
using MyExpenseTracker.Repositories;

namespace MyExpenseTracker.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ExpenseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //Get all expenses from database.
        public async Task<IActionResult> Index()
        {
            var expenses = await _unitOfWork.ExpenseRepository.GetExpensesAsync();
            return View(expenses);
        }

        public async Task<IActionResult> FilterExpensesByMonthYear()
        {
            
            return View();
        }

        //Get expenses by month and year.
        [HttpPost]
        public async Task<IActionResult> FilterExpensesByMonthYear(int month, int year)
        {
            var expenses = await _unitOfWork.ExpenseRepository.GetExpensesByMonthYearAsync(month, year);
            return View(expenses);
        }

        public IActionResult AddExpense()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddExpense(Expense expense)
        {
            await _unitOfWork.ExpenseRepository.AddExpenseAsync(expense);
            return View();
        }

        
    }
}
