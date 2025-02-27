using System.ComponentModel.DataAnnotations;

namespace MyExpenseTracker.Models
{
    public class Expense
    {
        public int Id { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public Categories Category { get; set; }

        [Required]
        public Labels Label { get; set; }

        public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    }

    public enum Categories
    {
        Food,
        Rent,
        Travel,
        Medical,
        Savings,
        Investments,
        Other
    }
    public enum Labels
    {
        [Display(Name = "Required")]
        Required,
        [Display(Name = "Not Required")]
        NotRequired
    }
}
