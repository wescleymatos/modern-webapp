using ModernStore.Domain.Entities;
using System;

namespace ModernStore.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Customer Get(Guid id);
        Customer Get(string document);
        Customer GetByUSerId(Guid id);
        void Update(Customer customer);
        void Save(Customer customer);
        bool DocumentExists(string document);
    }
}
