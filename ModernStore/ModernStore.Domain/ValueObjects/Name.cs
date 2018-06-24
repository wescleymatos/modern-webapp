using FluentValidator;
using FluentValidator.Validation;

namespace ModernStore.Domain.ValueObjects
{
    public class Name : Notifiable
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            new ValidationContract()
                .Requires()
                .HasMaxLen(FirstName, 60, "Name.FirstName", "")
                .HasMinLen(FirstName, 3, "Name.FirstName", "")
                .HasMaxLen(LastName, 60, "Name.LastName", "")
                .HasMinLen(LastName, 3, "Name.LastName", "");
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
