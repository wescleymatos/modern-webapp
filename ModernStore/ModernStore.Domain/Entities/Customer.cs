using ModernStore.Domain.ValueObjects;
using ModernStore.Shared.Entities;
using System;

namespace ModernStore.Domain.Entities
{
    public class Customer : Entity
    {
        protected Customer() { }

        public Customer(Name name, Email email, Document document, User user)
        {
            Name = name;
            Email = email;
            Document = document;
            User = user;
            BirthDay = null;

            AddNotifications(name.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(document.Notifications);
        }

        public Name Name { get; private set; }
        public DateTime? BirthDay { get; private set; }
        public bool Active { get; private set; }
        public Email Email { get; private set; }
        public User User { get; private set; }
        public Document Document { get; private set; }

        public void Update(Name name, DateTime birthDay)
        {
            Name = name;
            BirthDay = birthDay;
        }
    }
}
