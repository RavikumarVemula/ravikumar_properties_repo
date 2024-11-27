using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Serialization
{

    [Obsolete]
    public static class SerializerSettings
    {
        public static readonly JsonSerializerSettings Instance = new()
        {
            TypeNameHandling = TypeNameHandling.All,
            MetadataPropertyHandling = MetadataPropertyHandling.ReadAhead
        };
    }
}
