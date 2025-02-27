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
            double salary = 50000; // Example: Replace with actual salary from DB
            ViewBag.Salary = salary;
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

        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var expense = await _unitOfWork.ExpenseRepository.GetExpenseByIdAsync(id);
            if (expense == null)
            {
                return NotFound();
            }
            return View(expense);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Amount, Description, Category, Label, Date")] Expense expense)
        {
            if (id != expense.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                await _unitOfWork.ExpenseRepository.UpdateExpenseAsync(expense);
                await _unitOfWork.SaveAsync();
                return RedirectToAction(nameof(FilterExpensesByMonthYear));
            }
            return View(expense);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _unitOfWork.ExpenseRepository.DeleteExpenseAsync(id);
            await _unitOfWork.SaveAsync();

            return RedirectToAction(nameof(FilterExpensesByMonthYear));
        }

    }
}
