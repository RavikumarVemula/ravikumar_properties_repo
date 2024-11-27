using ApplicationLayer;
using MediatR;
using PropertyAPI.Extensions.EndPoints;
using PropertyAPI.Results;
using Microsoft.AspNetCore.Http;
using ApplicationLayer.Property.GetProperties;
using Microsoft.AspNetCore.Mvc;
using ApplicationLayer.Property.Models;


namespace PropertyAPI.Controllers
{
    public sealed class GetProperties : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {

             app.MapGet("api/properties", async ([FromServices] ISender sender) =>
             {
                 Result<IReadOnlyCollection<Properties>> result = await sender.Send(new GetPropertiesQuery());

                 return result.Match(Microsoft.AspNetCore.Http.Results.Ok , ApiResults.Problem);
             });
        }


    }
}
