// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace CognitiveSearch.Models
{
    /// <summary> An empty object that represents the default cognitive service resource for a skillset. </summary>
    public partial class DefaultCognitiveServicesAccount : CognitiveServicesAccount
    {
        /// <summary> Initializes a new instance of DefaultCognitiveServicesAccount. </summary>
        public DefaultCognitiveServicesAccount()
        {
            OdataType = "#Microsoft.Azure.Search.DefaultCognitiveServices";
        }

        /// <summary> Initializes a new instance of DefaultCognitiveServicesAccount. </summary>
        /// <param name="odataType"> Identifies the concrete type of the cognitive service resource attached to a skillset. </param>
        /// <param name="description"> Description of the cognitive service resource attached to a skillset. </param>
        internal DefaultCognitiveServicesAccount(string odataType, string description) : base(odataType, description)
        {
            OdataType = odataType ?? "#Microsoft.Azure.Search.DefaultCognitiveServices";
        }
    }
}
