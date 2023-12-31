namespace Application.Response.OrderItem;

public class OrderItemQueryResponse
{
    public int OrderItemId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public int ProductId { get; set; }
    public int OrderId { get; set; }
}