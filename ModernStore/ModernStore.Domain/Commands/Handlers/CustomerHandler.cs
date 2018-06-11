using FluentValidator;
using ModernStore.Domain.Commands.Inputs;
using ModernStore.Domain.Commands.Outputs;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModernStore.Domain.Resources;
using ModernStore.Domain.Services;
using ModernStore.Domain.ValueObjects;
using ModernStore.Shared.Commands;

namespace ModernStore.Domain.Commands.Handlers
{
    public class CustomerHandler : Notifiable, ICommandHandler<RegisterCustomerCommad>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IEmailService _emailService;

        public CustomerHandler(ICustomerRepository customerRepository, IEmailService emailService)
        {
            _customerRepository = customerRepository;
            _emailService = emailService;
        }

        public ICommandResult Handle(RegisterCustomerCommad command)
        {
            if (_customerRepository.DocumentExists(command.Document))
            {
                AddNotification("Customer", "Cliente não encontrado.");
                return null;
            }

            var name = new Name(command.FirstName, command.LastName);
            var email = new Email(command.Email);
            var document = new Document(command.Document);
            var user = new User(command.UserName, command.Password);

            var customer = new Customer(name, email, document, user);

            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(user.Notifications);
            AddNotifications(customer.Notifications);

            if (IsValid())
                _customerRepository.Save(customer);

            _emailService.Send(
                customer.Name.ToString(), 
                customer.Email.Address, 
                string.Format(EmailTemplates.WelcomeEmailTitle, customer.Name),
                string.Format(EmailTemplates.WelcomeEmailBody, customer.Name));

            return new RegisterCustomerCommadResult
            {
                Id = customer.Id,
                Name = customer.Name.ToString()
            };
        }
    }
}
