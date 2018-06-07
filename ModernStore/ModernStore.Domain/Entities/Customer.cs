using FluentValidator;
using ModernStore.Shared.Entities;
using System;

namespace ModernStore.Domain.Entities
{
    public class Customer : Entity
    {
        public Customer(string firstName, string lastName, string email, User user)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            User = user;

            new ValidationContract<Customer>(this)
                .IsRequired(x => x.FirstName)
                .HasMaxLenght(x => x.FirstName, 60)
                .HasMinLenght(x => x.LastName, 3)
                .IsRequired(x => x.LastName)
                .HasMaxLenght(x => x.LastName, 60)
                .HasMinLenght(x => x.LastName, 3)
                .IsEmail(x => x.Email);
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime BirthDay { get; private set; }
        public bool Active { get; private set; }
        public string Email { get; private set; }
        public User User { get; private set; }
    }
}
