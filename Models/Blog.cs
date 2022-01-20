using System.ComponentModel.DataAnnotations;

namespace Genevill_MVC_Portfolio.Models
{
    public class Blog
    {
        public int Id { get; set; }
        [StringLength(1000, MinimumLength = 3), Required]
        public string Title { get; set; }
        public string Author { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string Body { get; set; }
    }
}
