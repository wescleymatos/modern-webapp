using ModernStore.Shared.Commands;

namespace ModernStore.Domain.Commands.Outputs
{
    public class RegisterOrderCommadResult : ICommandResult
    {
        public string Number { get; set; }
    }
}
