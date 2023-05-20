using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication11.Models
{
    public class Product    {
        public Product()
        {
            Farmer = new Farmer();
        }
        public int productCode { get; set; }
        public string? productName { get; set; }
        public string? incomingout { get; set; }
        public string? type { get; set; }
        public string? dateAcquired { get; set; }
        public int FarmerId { get; set; }
        [ForeignKey("FarmerId")] 
        public Farmer Farmer { get; set; }
    }
}

