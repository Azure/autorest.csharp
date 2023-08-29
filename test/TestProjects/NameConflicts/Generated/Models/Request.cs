// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace NameConflicts.Models
{
    /// <summary> The Request. </summary>
    public partial class Request
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="Request"/>. </summary>
        public Request()
        {
        }

        /// <summary> Initializes a new instance of <see cref="Request"/>. </summary>
        /// <param name="property"></param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal Request(string property, Dictionary<string, BinaryData> rawData)
        {
            Property = property;
            _rawData = rawData;
        }

        /// <summary> Gets or sets the property. </summary>
        public string Property { get; set; }
    }
}
