using FluentValidator.Validation;
using ModernStore.Shared.Entities;

namespace ModernStore.Domain.Entities
{
    public class OrderItem : Entity
    {
        public OrderItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
            Price = product.Price;

            new ValidationContract()
                .Requires()
                .IsGreaterThan(Quantity, 1, "OrderItem.Quantity", "Quantidade tem que ser maior que 1")
                .IsGreaterThan(Product.QuantityOnHand, Quantity + 1, "Product.QuantityOnHand", $"Não temos tantos {product.Title}(s) em estoque.");

            Product.DecreaseQuantity(quantity);
        }

        public Product Product { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }

        public decimal Total() => Price * Quantity;
    }
}
