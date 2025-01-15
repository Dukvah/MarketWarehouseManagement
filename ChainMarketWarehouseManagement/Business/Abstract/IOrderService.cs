using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IOrderService
    {
        IDataResult<Order> GetById(int OrderId);
        IResult CreateOrder(Order order);
        IResult UpdateOrderStatus(int orderId, string status);
        IResult Add(OrderDetailDto order);
        IResult Update(UpdateOrderDto updateOrderDto);
    }
}
