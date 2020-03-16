// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace CognitiveSearch.Models
{
    /// <summary> A cognitive service resource provisioned with a key that is attached to a skillset. </summary>
    public partial class CognitiveServicesAccountKey : CognitiveServicesAccount
    {
        /// <summary> Initializes a new instance of CognitiveServicesAccountKey. </summary>
        internal CognitiveServicesAccountKey()
        {
        }

        /// <summary> Initializes a new instance of CognitiveServicesAccountKey. </summary>
        /// <param name="key"> . </param>
        /// <param name="odataType"> . </param>
        /// <param name="description"> . </param>
        internal CognitiveServicesAccountKey(string key, string odataType, string description) : base(odataType, description)
        {
            Key = key;
        }

        public string Key { get; set; }
    }
}
