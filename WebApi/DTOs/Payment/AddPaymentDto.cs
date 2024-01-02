namespace WebApi.DTOs.Payment;

public class AddPaymentDto
{
    public decimal Amount { get; set; }
    public bool IsSuccess { get; set; }
    public DateTime PaymentTime { get; set; }
    public int OrderId { get; set; }
}