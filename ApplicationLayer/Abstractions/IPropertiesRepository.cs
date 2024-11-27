using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLayer.Property.Models;

namespace ApplicationLayer.Abstractions
{
    public interface IPropertiesRepository
    {
        Task<Property.Models.Properties?> GetAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
