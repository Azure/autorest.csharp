// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace AdditionalPropertiesEx.Models
{
    /// <summary> The InputAdditionalPropertiesModel. </summary>
    public partial class InputAdditionalPropertiesModel
    {
        /// <summary> Initializes a new instance of InputAdditionalPropertiesModel. </summary>
        /// <param name="id"></param>
        public InputAdditionalPropertiesModel(int id)
        {
            Id = id;
            AdditionalProperties = new ChangeTrackingDictionary<string, object>();
        }

        /// <summary> Gets the id. </summary>
        public int Id { get; }
        /// <summary> Additional Properties. </summary>
        public IDictionary<string, object> AdditionalProperties { get; }
    }
}
