using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureAppConfiguration((context, builder) => builder
        .SetBasePath(context.HostingEnvironment.ContentRootPath)
        .AddJsonFile("local.settings.json")
    )
    .ConfigureServices((context, services) =>
        services.AddGraphQLFunction()
            // .ModifyFunctionOptions(x =>
            // {
            //     x.Tool.Enable = true;
            // })
            .AddSubgraph1Types()
            .InitializeOnStartup())
    .UseConsoleLifetime()
    .Build();

host.Run();