using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Storage
{
    public sealed class AzureStorageOptions
    {
        public string BlobUrl { get; set; }

        public string SasToken { get; set; }
    }
}
