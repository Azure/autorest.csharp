// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace MgmtNonStringPathVariable.Models
{
    /// <summary> The Update Resource model definition. </summary>
    public partial class UpdateResource
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        protected internal Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="UpdateResource"/>. </summary>
        public UpdateResource()
        {
            Tags = new ChangeTrackingDictionary<string, string>();
        }

        /// <summary> Initializes a new instance of <see cref="UpdateResource"/>. </summary>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal UpdateResource(IDictionary<string, string> tags, Dictionary<string, BinaryData> rawData)
        {
            Tags = tags;
            _rawData = rawData;
        }

        /// <summary> Resource tags. </summary>
        public IDictionary<string, string> Tags { get; }
    }
}
