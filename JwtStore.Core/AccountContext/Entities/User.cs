using JwtStore.Core.AccountContext.ValueObjects;
using JwtStore.Core.SharedContext.Entities;

namespace JwtStore.Core.AccountContext.Entities
{
    public class User : Entity
    {
        public Email Email { get; set; }
        public string Password { get; set; }

        public User(Email email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
