using ApplicationLayer.Abstractions;
using ApplicationLayer.Property.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Properties
{
    internal sealed class PropertiesRepository : IPropertiesRepository
    {
        public Task<ApplicationLayer.Property.Models.Properties?> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
