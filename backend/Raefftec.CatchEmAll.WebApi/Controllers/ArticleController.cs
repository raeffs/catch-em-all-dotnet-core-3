using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Raefftec.CatchEmAll.Controllers
{
    [ApiController]
    [Route("[controller]")]
    internal class ArticleController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromServices] IDbContext context)
        {
            var entities = await context.Articles.Take(10).ToListAsync();

            return this.Ok(entities);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get([FromServices] IDbContext context, Guid id)
        {
            var entity = await context.Articles.SingleOrDefaultAsync(x => x.Id == id);

            return this.Ok(entity);
        }
    }
}
