using ModernStore.Shared.Entities;

namespace ModernStore.Domain.Entities
{
    public class User : Entity
    {
        public User(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public string UserName { get; private set; }
        public string Password { get; private set; }
    }
}
