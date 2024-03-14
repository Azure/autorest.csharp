// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using _Type.Property.AdditionalProperties;

namespace _Type.Property.AdditionalProperties.Models
{
    /// <summary> The model extends from Record&lt;ModelForRecord&gt; type. </summary>
    public partial class ExtendsModelAdditionalProperties
    {
        /// <summary> Initializes a new instance of <see cref="ExtendsModelAdditionalProperties"/>. </summary>
        public ExtendsModelAdditionalProperties()
        {
            AdditionalProperties = new ChangeTrackingDictionary<string, ModelForRecord>();
        }

        /// <summary> Initializes a new instance of <see cref="ExtendsModelAdditionalProperties"/>. </summary>
        /// <param name="additionalProperties"> Additional Properties. </param>
        internal ExtendsModelAdditionalProperties(IDictionary<string, ModelForRecord> additionalProperties)
        {
            AdditionalProperties = additionalProperties;
        }

        /// <summary> Additional Properties. </summary>
        public IDictionary<string, ModelForRecord> AdditionalProperties { get; }
    }
}
