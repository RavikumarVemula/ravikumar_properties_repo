using ApplicationLayer.Abstractions;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using InfrastructureLayer.Serialization;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace InfrastructureLayer.Storage
{
    internal class StorageBlobService: AzureStorageBase , IAzureStorageService
    {
        private readonly AzureStorageOptions _azureStorageOptions;
        public StorageBlobService(IOptions<AzureStorageOptions> options): base(options) 
        {
            _azureStorageOptions = options.Value;
        }

        public async Task<T?> GetBlobDataAsync<T>(CancellationToken cancellationToken)
        {
            string blobUrl = $"{_azureStorageOptions.BlobUrl}?{_azureStorageOptions.SasToken}";
            //string blobUrl = $"https://nmrkpidev.blob.core.windows.net/dev-test/dev-test.json?sp=r&st=2024-10-28T10:35:48Z&se=2025-10-28T18:35:48Z&spr=https&sv=2022-11-02&sr=b&sig=bdeoPWtefikVgUGFCUs4ihsl22ZhQGu4%2B4cAfoMwd4k%3D";
            BlobClient blobClient = new BlobClient(new Uri(blobUrl));

            if (await blobClient.ExistsAsync())
            {
                using (Stream blobStream = await blobClient.OpenReadAsync())
                {
                    return await JsonSerializer.DeserializeAsync<T>(blobStream, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                }
            }
            else
            {
                throw new Exception("Blob File Not found");
            }
        }

    }
}
