using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Genevill_MVC_Portfolio.Models
{
    public enum Status
    {
        Pending,
        [Display(Name = "In Progress")]
        InProgress,
        Resolved,
        Closed
    }
    public class BugTracker
    {
        public int Id { get; set; }

#nullable enable
        [StringLength(1000, MinimumLength = 3), Required]
        public string? Summary { get; set; }

        public string? Assignee { get; set; }

        [Display(Name = "Affected User")]
        public string? AffectedUser { get; set; }

        [RegularExpression(@"\d{3}-\d{3}-\d{4}", ErrorMessage = "Please enter a contact number in the format 123-456-7890")]
        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }

        //[RegularExpression(@"[0123]", ErrorMessage = "Please select Pending, In Progress, Resolved, or Closed")]
        public Status? Status { get; set; }

        public string? Resolution { get; set; }

        [DataType(DataType.Date)]
        public DateTime Created { get; set; }

        [DataType(DataType.Date)]
        public DateTime Updated { get; set; }

        public BugTracker()
        {
            Created = DateTime.Now;
            Updated = DateTime.Now;
        }
    }
}
