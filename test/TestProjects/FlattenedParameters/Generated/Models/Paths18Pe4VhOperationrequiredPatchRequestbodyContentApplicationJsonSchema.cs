// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace FlattenedParameters.Models
{
    /// <summary> The Paths18Pe4VhOperationrequiredPatchRequestbodyContentApplicationJsonSchema. </summary>
    internal partial class Paths18Pe4VhOperationrequiredPatchRequestbodyContentApplicationJsonSchema
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::FlattenedParameters.Models.Paths18Pe4VhOperationrequiredPatchRequestbodyContentApplicationJsonSchema
        ///
        /// </summary>
        /// <param name="required"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="required"/> is null. </exception>
        public Paths18Pe4VhOperationrequiredPatchRequestbodyContentApplicationJsonSchema(string required)
        {
            Argument.AssertNotNull(required, nameof(required));

            Required = required;
        }

        /// <summary>
        /// Initializes a new instance of global::FlattenedParameters.Models.Paths18Pe4VhOperationrequiredPatchRequestbodyContentApplicationJsonSchema
        ///
        /// </summary>
        /// <param name="required"></param>
        /// <param name="nonRequired"></param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal Paths18Pe4VhOperationrequiredPatchRequestbodyContentApplicationJsonSchema(string required, string nonRequired, Dictionary<string, BinaryData> rawData)
        {
            Required = required;
            NonRequired = nonRequired;
            _rawData = rawData;
        }

        /// <summary> Gets the required. </summary>
        public string Required { get; }
        /// <summary> Gets or sets the non required. </summary>
        public string NonRequired { get; set; }
    }
}
