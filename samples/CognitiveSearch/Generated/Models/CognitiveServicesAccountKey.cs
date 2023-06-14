// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace CognitiveSearch.Models
{
    /// <summary> A cognitive service resource provisioned with a key that is attached to a skillset. </summary>
    public partial class CognitiveServicesAccountKey : CognitiveServicesAccount
    {
        /// <summary> Initializes a new instance of CognitiveServicesAccountKey. </summary>
        /// <param name="key"> The key used to provision the cognitive service resource attached to a skillset. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public CognitiveServicesAccountKey(string key)
        {
            Argument.AssertNotNull(key, nameof(key));

            Key = key;
            OdataType = "#Microsoft.Azure.Search.CognitiveServicesByKey";
        }

        /// <summary> Initializes a new instance of CognitiveServicesAccountKey. </summary>
        /// <param name="odataType"> Identifies the concrete type of the cognitive service resource attached to a skillset. </param>
        /// <param name="description"> Description of the cognitive service resource attached to a skillset. </param>
        /// <param name="key"> The key used to provision the cognitive service resource attached to a skillset. </param>
        internal CognitiveServicesAccountKey(string odataType, string description, string key) : base(odataType, description)
        {
            Key = key;
            OdataType = odataType ?? "#Microsoft.Azure.Search.CognitiveServicesByKey";
        }

        /// <summary> The key used to provision the cognitive service resource attached to a skillset. </summary>
        public string Key { get; set; }
    }
}
