using FluentValidator;
using FluentValidator.Validation;

namespace ModernStore.Domain.ValueObjects
{
    public class Email : Notifiable
    {
        public Email(string address)
        {
            Address = address;

            new ValidationContract()
                .Requires()
                .IsEmail(Address, "Email.Address", "");
        }

        public string Address { get; private set; }
    }
}
