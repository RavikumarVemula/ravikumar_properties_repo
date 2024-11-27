using ApplicationLayer.Abstractions;
using ApplicationLayer.Communication;
using ApplicationLayer.Property.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Property.GetProperties
{
    internal sealed class GetPropertiesHandler(IAzureStorageService azureStorageService )
    : IQueryHandler<GetPropertiesQuery, IReadOnlyCollection<Properties>>
    {
        public async Task<Result<IReadOnlyCollection<Properties>>> Handle(
            GetPropertiesQuery request,
            CancellationToken cancellationToken)
        {
            List<Properties> properties = await azureStorageService.GetBlobDataAsync<List<Properties>>(cancellationToken) ;
                //(await connection.QueryAsync<CategoryResponse>(sql, request)).AsList();

            return properties;
        }
    }
}
