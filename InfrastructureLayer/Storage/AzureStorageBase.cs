using ApplicationLayer.Abstractions;
using Azure.Core.Extensions;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Storage
{
    internal abstract class AzureStorageBase
    {
        private readonly IOptions<AzureStorageOptions> _options;
        protected AzureStorageBase(IOptions<AzureStorageOptions> options)
        {
                _options = options;
        }
        
    }
}
