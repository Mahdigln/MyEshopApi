using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class OrderItem
{
    [Key]
    public int OrderItemId { get; set; }
    [Required]
    public int Quantity { get; set; }
    [Required]
    public decimal Price { get; set; }
    // Navigation Properties
    public Product Product { get; set; }
    public int ProductId { get; set; }
    public Order Order { get; set; }
    public int OrderId { get; set; }
}