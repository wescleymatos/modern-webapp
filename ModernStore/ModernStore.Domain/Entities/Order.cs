
using FluentValidator.Validation;
using ModernStore.Domain.Enums;
using ModernStore.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ModernStore.Domain.Entities
{
    public class Order : Entity
    {
        private readonly IList<OrderItem> _items;

        public Order(Customer customer, decimal deliveryFree, decimal discount)
        {
            Customer = customer;
            CreateDate = DateTime.Now;
            Number = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
            Status = EOrderStatus.Created;
            _items = new List<OrderItem>();
            DeliveryFee = deliveryFree;
            Discount = discount;

            new ValidationContract()
                .Requires()
                .IsGreaterThan(DeliveryFee, 0, "Order.DeliveryFee", "Deve ser maior que zero")
                .IsGreaterThan(DeliveryFee, -1, "Order.DeliveryFee", "Deve ser maior que -1");
        }

        public Customer Customer { get; private set; }
        public DateTime CreateDate { get; private set; }
        public string Number { get; private set; }
        public EOrderStatus Status { get; private set; }
        public IReadOnlyCollection<OrderItem> Items => _items.ToArray();
        public decimal DeliveryFee { get; private set; }
        public decimal Discount { get; private set; }

        public decimal SubTotal() => Items.Sum(x => x.Total());
        public decimal Total() => SubTotal() + DeliveryFee - Discount;

        public void AddItem(OrderItem item)
        {
            AddNotifications(item.Notifications);

            if (item.Valid)
                _items.Add(item);
        }
    }
}
