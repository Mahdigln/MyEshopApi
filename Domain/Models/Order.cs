using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Order
{
    [Key]
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public bool IsFinally { get; set; }
    [Required]
    public decimal Sum { get; set; }
    // Navigation Properties
    public List<OrderItem> OrderItems { get; set; }
    public Customer Customer { get; set; }
    public int CustomerId { get; set; }
    public List<Payment> Payment { get; set; }
}