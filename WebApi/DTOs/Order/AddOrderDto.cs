using System.ComponentModel.DataAnnotations;

namespace WebApi.DTOs.Order;

public class AddOrderDto
{
    [Required]
    public int CustomerId { get; set; }
    [Required]
    public int ProductId { get; set; }

}