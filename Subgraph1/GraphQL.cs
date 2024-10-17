using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using HotChocolate.AzureFunctions;
using Microsoft.Azure.Functions.Worker;

namespace Subgraph1
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
