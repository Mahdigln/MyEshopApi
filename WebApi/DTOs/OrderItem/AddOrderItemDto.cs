using System.ComponentModel.DataAnnotations;

namespace WebApi.DTOs.OrderItem;

public class AddOrderItemDto
{
    [Required]
    public int Quantity { get; set; }
    [Required]
    public int ProductId { get; set; }
    [Required]
    public int OrderId { get; set; }
}