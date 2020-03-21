using System.Collections.Generic;
using Azure.Core;

namespace additionalProperties.Models
{
    [CodeGenSchema("PetAPInPropertiesWithAPString")]
    public partial class PetAPInPropertiesWithAPString
    {
        [CodeGenSchemaMember("$AdditionalProperties")]
        internal IDictionary<string, string> MoreAdditionalProperties { get; set; } = new Dictionary<string, string>();
    }
}