// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace MgmtParamOrdering.Models
{
    /// <summary> The LocationFormatObject. </summary>
    internal partial class LocationFormatObject
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="LocationFormatObject"/>. </summary>
        internal LocationFormatObject()
        {
        }

        /// <summary> Initializes a new instance of <see cref="LocationFormatObject"/>. </summary>
        /// <param name="stringLocation"> This location should be a string. </param>
        /// <param name="objectLocation"> This location should be an AzureLocation. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal LocationFormatObject(string stringLocation, AzureLocation? objectLocation, Dictionary<string, BinaryData> serializedAdditionalRawData)
        {
            StringLocation = stringLocation;
            ObjectLocation = objectLocation;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> This location should be a string. </summary>
        public string StringLocation { get; }
        /// <summary> This location should be an AzureLocation. </summary>
        public AzureLocation? ObjectLocation { get; }
    }
}
