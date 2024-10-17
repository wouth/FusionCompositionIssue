using System.Threading.Tasks;
using HotChocolate.AzureFunctions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;

namespace Gateway
{
    public class GraphQL(IGraphQLRequestExecutor executor)
    {
        [Function("GraphQL")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "graphql/{**slug}")]
            HttpRequest req
        )
        {
            return await executor.ExecuteAsync(req);
        }
    }
}