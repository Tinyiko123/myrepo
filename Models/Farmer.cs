using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication11.Models
{
    public class Farmer
    {
        public Farmer()
        {
            Products = new List<Product>();
            Employee = new Employee();
        }
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }

        public List<Product> Products { get; set; }
    }
}
