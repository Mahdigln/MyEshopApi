using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Payment
{
    [Key]
    public int PayId { get; set; }
    public decimal Amount { get; set; }
    public bool IsSuccess { get; set; }
    public DateTime PaymentTime { get; set; }

    // Navigation Property
    public Order Order { get; set; }
    public int OrderId { get; set; }
}

