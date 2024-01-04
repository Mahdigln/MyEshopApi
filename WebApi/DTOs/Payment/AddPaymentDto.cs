using System.ComponentModel.DataAnnotations;

namespace WebApi.DTOs.Payment;

public class AddPaymentDto
{
    [Required]
    public decimal Amount { get; set; }
    [Required]
    public bool IsSuccess { get; set; }
    [Required]
    public DateTime PaymentTime { get; set; }
    [Required]
    public int OrderId { get; set; }
}