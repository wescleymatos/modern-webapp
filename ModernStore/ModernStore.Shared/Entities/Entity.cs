using FluentValidator;
using System;

namespace ModernStore.Shared.Entities
{
    public abstract class Entity : Notifiable
    {
        public Guid Id { get; private set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
