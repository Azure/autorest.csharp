// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
    }
}
