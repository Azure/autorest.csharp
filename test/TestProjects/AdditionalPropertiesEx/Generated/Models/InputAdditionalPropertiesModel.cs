// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace AdditionalPropertiesEx.Models
{
    /// <summary> The InputAdditionalPropertiesModel. </summary>
    public partial class InputAdditionalPropertiesModel
    {
        /// <summary> Initializes a new instance of <see cref="InputAdditionalPropertiesModel"/>. </summary>
        /// <param name="id"></param>
        public InputAdditionalPropertiesModel(int id)
        {
            Id = id;
            AdditionalProperties = new ChangeTrackingDictionary<string, object>();
        }

        /// <summary> Initializes a new instance of <see cref="InputAdditionalPropertiesModel"/>. </summary>
        /// <param name="id"></param>
        /// <param name="additionalProperties"> Additional Properties. </param>
        internal InputAdditionalPropertiesModel(int id, IDictionary<string, object> additionalProperties)
        {
            Id = id;
            AdditionalProperties = additionalProperties;
        }

        /// <summary> Gets the id. </summary>
        public int Id { get; }
        /// <summary> Additional Properties. </summary>
        public IDictionary<string, object> AdditionalProperties { get; }
    }
}
