using System;

namespace Raefftec.CatchEmAll.Entities
{
    public class UserReference : IHasIdentifier
    {
        public Guid Id { get; private set; }

        public string Username { get; private set; }

        private UserReference()
        {
            this.Username = null!;
        }

        public UserReference(string username)
        {
            this.Username = username;
        }
    }
}
