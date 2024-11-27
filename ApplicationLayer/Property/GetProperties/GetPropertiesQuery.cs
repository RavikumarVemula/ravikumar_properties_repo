using ApplicationLayer.Communication;
using ApplicationLayer.Property.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Property.GetProperties
{
    public sealed record GetPropertiesQuery : IQuery<IReadOnlyCollection<Properties>>;

}
