using System;
using Microsoft.Extensions.DependencyInjection;

namespace Raefftec.CatchEmAll
{
    internal class ContextFactory : IContextFactory
    {
        private readonly IServiceProvider serviceProvider;

        public ContextFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IDbContext GetContext()
        {
            return this.serviceProvider.GetRequiredService<IDbContext>();
        }
    }
}
