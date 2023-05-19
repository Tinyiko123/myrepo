namespace WebApplication11.Models
{
    public class Employee
    {
        public Employee()
        {
            Farmers = new List<Farmer>();
        }
        public int Id { get; set; } 
        public List<Farmer> Farmers { get; set; }    
    }
}
