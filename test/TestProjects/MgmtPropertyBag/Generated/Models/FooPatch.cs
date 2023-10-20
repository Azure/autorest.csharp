// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtPropertyBag.Models
{
    /// <summary> Foo instance details. </summary>
    public partial class FooPatch
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="FooPatch"/>. </summary>
        public FooPatch()
        {
        }

        /// <summary> Initializes a new instance of <see cref="FooPatch"/>. </summary>
        /// <param name="details"> The details of the resource. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal FooPatch(string details, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Details = details;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> The details of the resource. </summary>
        public string Details { get; set; }
    }
}
