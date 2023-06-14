// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace AdditionalPropertiesEx.Models
{
    /// <summary> The OutputAdditionalPropertiesModelStruct. </summary>
    public readonly partial struct OutputAdditionalPropertiesModelStruct
    {
        /// <summary> Initializes a new instance of OutputAdditionalPropertiesModelStruct. </summary>
        /// <param name="id"></param>
        /// <param name="additionalProperties"> Additional Properties. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="additionalProperties"/> is null. </exception>
        internal OutputAdditionalPropertiesModelStruct(int id, IReadOnlyDictionary<string, string> additionalProperties)
        {
            Argument.AssertNotNull(additionalProperties, nameof(additionalProperties));

            Id = id;
            AdditionalProperties = additionalProperties;
        }

        /// <summary> Gets the id. </summary>
        public int Id { get; }
        /// <summary> Additional Properties. </summary>
        public IReadOnlyDictionary<string, string> AdditionalProperties { get; }
    }
}
