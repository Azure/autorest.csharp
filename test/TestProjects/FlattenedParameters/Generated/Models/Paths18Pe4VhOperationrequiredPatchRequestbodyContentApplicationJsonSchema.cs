// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace FlattenedParameters.Models
{
    /// <summary> The Paths18Pe4VhOperationrequiredPatchRequestbodyContentApplicationJsonSchema. </summary>
    internal partial class Paths18Pe4VhOperationrequiredPatchRequestbodyContentApplicationJsonSchema
    {
        /// <summary> Initializes a new instance of Paths18Pe4VhOperationrequiredPatchRequestbodyContentApplicationJsonSchema. </summary>
        /// <param name="required"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="required"/> is null. </exception>
        public Paths18Pe4VhOperationrequiredPatchRequestbodyContentApplicationJsonSchema(string required)
        {
            Argument.AssertNotNull(required, nameof(required));

            Required = required;
        }

        /// <summary> Gets the required. </summary>
        public string Required { get; }
        /// <summary> Gets or sets the non required. </summary>
        public string NonRequired { get; set; }
    }
}
