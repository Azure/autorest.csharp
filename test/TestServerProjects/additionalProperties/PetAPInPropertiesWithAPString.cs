using System.Collections.Generic;
using Azure.Core;

namespace additionalProperties.Models
{
    [CodeGenModel("PetAPInPropertiesWithAPString")]
    public partial class PetAPInPropertiesWithAPString
    {
        [CodeGenMember("$AdditionalProperties")]
        internal IDictionary<string, string> MoreAdditionalProperties { get; set; } = new Dictionary<string, string>();
    }
}