using Microsoft.AspNetCore.Builder;

namespace ProdutoApi.Abstractions
{
    public interface IEndpointDefinition
    {
        void RegistrarEndpoints(WebApplication app);
    }
}
