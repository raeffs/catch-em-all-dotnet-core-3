using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Raefftec.CatchEmAll.Entities;
using Raefftec.CatchEmAll.Types;

namespace Raefftec.CatchEmAll.SearchQueries
{
    [ApiController]
    [Authorize]
    [Route("search-queries")]
    internal class Controller : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromServices] IDbContext context, [FromQuery] int pageSize = 10)
        {
            var userRef = await context.GetUserReferenceAsync(this.User);

            var result = await context.SearchQueries.AsNoTracking()
                .Where(x => x.UserId == userRef.Id)
                .Select(x => new SearchQueryInfo
                {
                    Id = x.Id,
                    Name = x.Name,
                    NumberOfResults = x.Results.Count,
                    Updated = x.UpdateInfo.Updated
                })
                .Take(pageSize)
                .ToListAsync();

            return this.Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromServices] IDbContext context, [FromBody] SearchQueryDetails model)
        {
            var userRef = await context.GetUserReferenceAsync(this.User);

            var entity = new SearchQuery(model.Name, userRef, new SearchCriteria(model.WithAllTheseWords));

            await context.SearchQueries.AddAsync(entity);

            await context.SaveAsync();

            return this.Ok(new SearchQueryDetails
            {
                Id = entity.Id,
                Name = entity.Name,
                WithAllTheseWords = entity.Criteria.WithAllTheseWords
            });
        }
    }
}
