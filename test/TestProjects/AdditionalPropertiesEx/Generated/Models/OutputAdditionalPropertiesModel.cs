// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace AdditionalPropertiesEx.Models
{
    /// <summary> The OutputAdditionalPropertiesModel. </summary>
    public partial class OutputAdditionalPropertiesModel
    {
        /// <summary> Initializes a new instance of OutputAdditionalPropertiesModel. </summary>
        /// <param name="id"></param>
        internal OutputAdditionalPropertiesModel(int id)
        {
            Id = id;
            AdditionalProperties = new ChangeTrackingDictionary<string, string>();
        }

        /// <summary> Initializes a new instance of OutputAdditionalPropertiesModel. </summary>
        /// <param name="id"></param>
        /// <param name="additionalProperties"> Additional Properties. </param>
        internal OutputAdditionalPropertiesModel(int id, IReadOnlyDictionary<string, string> additionalProperties)
        {
            Id = id;
            AdditionalProperties = additionalProperties;
        }

        /// <summary> Gets the id. </summary>
        public int Id { get; }
        /// <summary> Additional Properties. </summary>
        public IReadOnlyDictionary<string, string> AdditionalProperties { get; }
    }
}
