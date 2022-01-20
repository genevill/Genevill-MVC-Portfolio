using System.ComponentModel.DataAnnotations;

namespace Genevill_MVC_Portfolio.Models
{
    public class FinancialPortal
    {
        public int Id { get; set; }
        [StringLength(1000, MinimumLength = 3), Required]
        public string Account { get; set; }
        [RegularExpression(@"Checking|Savings", ErrorMessage = "Must be Checking or Savings")]
        public string AccountType { get; set; }
        [DataType(DataType.Date)]
        public DateTime TransactionDate { get; set; }
        public double TransactionAmount { get; set; }
        public double Balance { get; set; }
    }
}
