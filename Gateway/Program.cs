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
    {
        services.AddHttpClient("Subgraph1");
        services.AddHttpClient("Subgraph2");

        services.AddFusionGatewayServer()
            .ConfigureFromFile(@"gateway.fgp", watchFileForUpdates: true)
            .UseDefaultPipeline()
            ;
        services.AddGraphQLFunction()
            // .ModifyFunctionOptions(x =>
            // {
            //     x.Tool.Enable = true;
            // })
            ;

    })
    .UseConsoleLifetime()
    .Build();

host.Run();
