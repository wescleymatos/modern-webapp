﻿using FluentValidator;

namespace ModernStore.Domain.ValueObjects
{
    public class Name : Notifiable
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            new ValidationContract<Name>(this)
                .IsRequired(x => x.FirstName)
                .HasMaxLenght(x => x.FirstName, 60)
                .HasMinLenght(x => x.LastName, 3)
                .IsRequired(x => x.LastName)
                .HasMaxLenght(x => x.LastName, 60)
                .HasMinLenght(x => x.LastName, 3);
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
