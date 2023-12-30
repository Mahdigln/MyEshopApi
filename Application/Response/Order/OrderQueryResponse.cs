namespace Application.Response.Order;

public class OrderQueryResponse
{
    public int OrderId { get; set; }
    public string OrderDate { get; set; }
    public string IsFinally { get; set; }
    public decimal Sum { get; set; }

    public int CustomerId { get; set; }
}