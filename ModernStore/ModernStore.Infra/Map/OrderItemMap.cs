﻿using ModernStore.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ModernStore.Infra.Map
{
    class OrderItemMap : EntityTypeConfiguration<OrderItem>
    {
        public OrderItemMap()
        {
            ToTable("OrderItem");
            HasKey(x => x.Id);
            Property(x => x.Price).HasColumnType("money");
            Property(x => x.Quantity);
            HasRequired(x => x.Product);
        }
    }
}
