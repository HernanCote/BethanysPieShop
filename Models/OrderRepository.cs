using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Models
{
    public class OrderRepository : IOrderRepository
    {
        private AppDbContext _appContext;
        private ShoppingCart _shoppingCart;

        public OrderRepository(AppDbContext appContext, ShoppingCart shoppingCart)
        {
            _appContext = appContext;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            _appContext.Orders.Add(order);

            var shoppingCartItems = _shoppingCart.ShoppingCartItems;

            foreach(var item in shoppingCartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    Amount = item.Amount,
                    PieId = item.Pie.PieId,
                    OrderId = order.OrderId,
                    Price = item.Pie.Price
                };
                _appContext.OrderDetails.Add(orderDetail);
            }

            _appContext.SaveChanges();
        }
    }
}
