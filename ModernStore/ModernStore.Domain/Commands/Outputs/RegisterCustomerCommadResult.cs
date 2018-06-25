using ModernStore.Shared.Commands;
using System;

namespace ModernStore.Domain.Commands.Outputs
{
    public class RegisterCustomerCommadResult : ICommandResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
