using MediatR;

namespace Application.Features.OrderItem.Commands.AddSomeOrderItems;

public class AddSomeOrderItemCommandRequest : IRequest<bool>
{
    public List<AddSomeOrderItemCommandRequestList> ItemList { get; set; }

}