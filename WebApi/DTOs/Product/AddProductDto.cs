using System.ComponentModel.DataAnnotations;

namespace WebApi.DTOs.Product
{
    public class AddProductDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Inventory { get; set; }
        [Required]
        public string Description { get; set; }
        public int CategoryId { get; set; }
    }
}
