// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace FlattenedParameters.Models
{
    /// <summary> The Paths1Ti27MtOperationnotrequiredPatchRequestbodyContentApplicationJsonSchema. </summary>
    internal partial class Paths1Ti27MtOperationnotrequiredPatchRequestbodyContentApplicationJsonSchema
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="Paths1Ti27MtOperationnotrequiredPatchRequestbodyContentApplicationJsonSchema"/>. </summary>
        public Paths1Ti27MtOperationnotrequiredPatchRequestbodyContentApplicationJsonSchema()
        {
        }

        /// <summary> Initializes a new instance of <see cref="Paths1Ti27MtOperationnotrequiredPatchRequestbodyContentApplicationJsonSchema"/>. </summary>
        /// <param name="required"></param>
        /// <param name="nonRequired"></param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal Paths1Ti27MtOperationnotrequiredPatchRequestbodyContentApplicationJsonSchema(string required, string nonRequired, Dictionary<string, BinaryData> rawData)
        {
            Required = required;
            NonRequired = nonRequired;
            _rawData = rawData;
        }

        /// <summary> Gets or sets the required. </summary>
        public string Required { get; set; }
        /// <summary> Gets or sets the non required. </summary>
        public string NonRequired { get; set; }
    }
}
