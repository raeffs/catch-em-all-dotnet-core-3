using System;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Raefftec.CatchEmAll.Startup))]

namespace Raefftec.CatchEmAll
{
    internal class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddOptions<Options>().Configure<IConfiguration>((settings, configuration) =>
            {
                configuration.GetSection("Options").Bind(settings);
            });

            // todo: can we access the configuration for that too?
            string connectionString = Environment.GetEnvironmentVariable("SqlConnectionString") ?? string.Empty;
            builder.Services.AddDataAccess(connectionString);

            builder.Services.AddCrawler();
        }
    }
}
