using System;
using System.Collections.Generic;

namespace Builder
{
    public class OrderBuilder
    {
        private Order _order;

        public OrderBuilder(Order order)
        {
            _order = order;
        }

        public Order Build()
        {
            _order.OrderTime = DateTime.Now;
            return _order;
        }

        public OrderBuilder WithUserInfo(Userinfo userinfo)
        {
            _order.UserInfo = userinfo;
            return this;
        }

        public OrderBuilder WithShippingAddress(Address address)
        {
            _order.ShippingAddress = address;
            return this;
        }

        public OrderBuilder WithBillingAddress(Address address)
        {
            _order.BillingAddress = address;
            return this;
        }

        public OrderBuilder WithPayment(Payment payment)
        {
            _order.Payment = payment;
            return this;
        }

        public OrderBuilder WithProduct(Product product)
        {
            if (_order.Products == null)
            {
                _order.Products = new List<Product>();
            }

            _order.Products.Add(product);
            return this;
        }

        public OrderBuilder WithOrderId(int id)
        {
            _order.OrderId = id;
            return this;
        }

        public OrderBuilder WithMonthYear(string monthYear)
        {
            _order.MonthYear = monthYear;
            return this;
        }
    }
}