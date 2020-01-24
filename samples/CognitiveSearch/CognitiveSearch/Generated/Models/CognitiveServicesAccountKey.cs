// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace CognitiveSearch.Models
{
    /// <summary> A cognitive service resource provisioned with a key that is attached to a skillset. </summary>
    public partial class CognitiveServicesAccountKey : CognitiveServicesAccount
    {
        /// <summary> Initializes a new instance of CognitiveServicesAccountKey. </summary>
        public CognitiveServicesAccountKey()
        {
            OdataType = "#Microsoft.Azure.Search.CognitiveServicesByKey";
        }
        public string Key { get; set; }
    }
}
