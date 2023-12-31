namespace WebApi.DTOs.OrderItem;

public class AddOrderItemDto
{
    public int Quantity { get; set; }
    public int ProductId { get; set; }
    public int OrderId { get; set; }
}