using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Raefftec.CatchEmAll.Controllers
{
    [ApiController]
    [Route("[controller]")]
    internal class TestController : ControllerBase
    {
        [HttpGet]
        [Route("public")]
        public async Task<IActionResult> Public()
        {
            var user = ControllerContext.HttpContext.User;

            return this.Ok(new
            {
                Data = "public",
                Identity = new
                {
                    user.Identity.IsAuthenticated,
                    user.Identity.Name
                },
                Claims = user.Claims
                    .Select(x => new
                    {
                        x.Type,
                        x.Value
                    })
                    .ToList()
            });
        }

        [HttpGet]
        [Route("private")]
        [Authorize]
        public async Task<IActionResult> Private()
        {
            var user = ControllerContext.HttpContext.User;

            return this.Ok(new
            {
                Data = "private",
                Identity = new
                {
                    user.Identity.IsAuthenticated,
                    user.Identity.Name
                },
                Claims = user.Claims
                    .Select(x => new
                    {
                        x.Type,
                        x.Value,
                    })
                    .ToList()
            });
        }
    }
}
