using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace Raefftec.CatchEmAll
{
    internal class CustomControllerFeatureProvider : ControllerFeatureProvider
    {
        protected override bool IsController(TypeInfo typeInfo)
        {
            var isController = !typeInfo.IsAbstract && typeof(ControllerBase).IsAssignableFrom(typeInfo);
            return isController || base.IsController(typeInfo);
        }
    }
}
