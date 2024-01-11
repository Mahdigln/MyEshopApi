namespace Application.Features.OrderItem.Commands.AddSomeOrderItems;

public class AddSomeOrderItemCommandRequestList
{
    public int Quantity { get; set; }
    public int ProductId { get; set; }
    public int OrderId { get; set; }
}