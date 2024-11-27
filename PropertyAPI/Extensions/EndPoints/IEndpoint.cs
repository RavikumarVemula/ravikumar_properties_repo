namespace PropertyAPI.Extensions.EndPoints
{
    /// <summary>
    /// Endpoint contract
    /// </summary>
    public interface IEndpoint
    {
        void MapEndpoint(IEndpointRouteBuilder endpointRouteBuilder);
    }
}
