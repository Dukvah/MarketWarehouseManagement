using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _orderDal;
        private readonly IOrderItemDal _orderItemDal;
        public OrderManager(IOrderDal orderDal, IOrderItemDal orderItemDal)
        {
            _orderDal = orderDal;
            _orderItemDal = orderItemDal;
        }
        public IResult Add(OrderDetailDto order)
        {
            var newOrder = new Order();
            newOrder.Name = order.Name;
            newOrder.CustomerID = order.CustomerID;
            newOrder.CreateDate = order.CreateDate;
            newOrder.TotalAmount = order.TotalAmount;
            newOrder.Status = "Oluşturuldu";
            var result = _orderDal.Add(newOrder);
            foreach (var item in order.OrderItem)
            {
                var orderItem = new OrderItem();
                orderItem.Quantity = item.Quantity;
                orderItem.OrderID = result.Id;
                _orderItemDal.Add(orderItem);
            }
          
            return new SuccessResult(Messages.OrderAdded);
        }

        public IResult Update(UpdateOrderDto updateOrderDto)
        {
            var order = GetById(updateOrderDto.Id).Data;
            order.Name = updateOrderDto.Name;
            order.CustomerID = updateOrderDto.CustomerID;
            order.CreateDate = updateOrderDto.CreateDate;
            order.TotalAmount = updateOrderDto.TotalAmount;
            order.Status = updateOrderDto.Status;
            _orderDal.Update(order);
            return new SuccessDataResult<Order>(order, Messages.OrderUpdated);
        }

        public IDataResult<Order> GetById(int orderId)
        {
            return new SuccessDataResult<Order>(_orderDal.Get(p => p.Id == orderId));
        }
        public IResult CreateOrder(Order order)
        {
            order.Status = "Oluşturuldu";
            _orderDal.Add(order);
            return new SuccessDataResult<Order>(order, Messages.OrderCreated);
        }
        public IResult UpdateOrderStatus(int orderId, string status)
        {
            var order = GetById(orderId).Data;
            order.Status = status;
            _orderDal.Update(order);
            return new SuccessDataResult<Order>(order,Messages.OrderStatusUpdated);
        }
    }
}
