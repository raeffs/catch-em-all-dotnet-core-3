using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Raefftec.CatchEmAll.Entities;

namespace Raefftec.CatchEmAll
{
    internal static class ContextExtensions
    {
        public static async Task<UserReference> GetUserReferenceAsync(this IDbContext context, ClaimsPrincipal user)
        {
            if (user.Identity.Name == null)
            {
                throw new Exception();
            }

            var entity = await context.UserReferences.FirstOrDefaultAsync(x => x.Username == user.Identity.Name);

            if (entity == null)
            {
                entity = new UserReference(user.Identity.Name);
                await context.UserReferences.AddAsync(entity);
            }

            return entity;
        }
    }
}
