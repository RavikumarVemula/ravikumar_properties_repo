using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Abstractions
{
    public interface IAzureStorageService
    {
        Task<T> GetBlobDataAsync<T>(CancellationToken cancellationToken);
    }
}
