using System.ComponentModel.DataAnnotations;

namespace WebApi.DTOs.Payment;

public class AddPaymentDto
{
    [Required]
    public int OrderId { get; set; }
}