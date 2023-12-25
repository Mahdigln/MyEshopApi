using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Product
{
    [Key]
    public int ProductId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Inventory { get; set; }
    public string Description { get; set; }

    // Navigation Property
    public List<OrderItem> OrderItems { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}