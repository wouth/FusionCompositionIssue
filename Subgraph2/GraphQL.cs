using System.Threading.Tasks;
using HotChocolate.AzureFunctions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;

namespace Subgraph2
{
    public class GraphQL(IGraphQLRequestExecutor executor)
    {
        [Function("GraphQL")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "graphql/{**slug}")]
            HttpRequest req
        ) =>
            await executor.ExecuteAsync(req);
    }
}
